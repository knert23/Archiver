using System;
using System.IO;
using System.Text;

namespace Lab4_WF
{
    class RLEPacker
    {
        public delegate void ProgressBarRLEPacker(long progress);
        public event ProgressBarRLEPacker pbNotifyRLEPacker;

        bool StopClicked { set; get; } = false; // состояние нажатия кнопки Stop

        // два символа, которые постоянно будут сравниваться
        int FirstSymbol;
        int SecondSymbol;

        // счетчики количества одинаковых/неодинаковых символов
        public long CountSimilarSymbols { get; set; } = 1;
        public int CountDissimilarSymbols { get; set; } = 2;


        byte[] bufArrCount; //массив байтов для записи в файл числа повторяющихся/неповторяющихся символов
        byte[] arrBytesWrite = new byte[255]; // массив байтов для записи в файл

        long DataLength;
        internal void StreamPack(Stream source, Stream dest)
        {
            Progress = 0;

            DataLength = source.Seek(0, SeekOrigin.End); // количество символов в файле

            pbNotifyRLEPacker?.Invoke(Progress);

            source.Seek(0, SeekOrigin.Begin); // ставим курсор на начало файла

            FirstSymbol = source.ReadByte();
            if (FirstSymbol == -1) throw new Exception("Пустой файл");

            Progress = source.Position * 100 / DataLength;
            pbNotifyRLEPacker?.Invoke(Progress);
            while (source.Position != source.Length)
            {
                SecondSymbol = source.ReadByte();

                if (StopClicked == true) break;
                
                if (FirstSymbol == SecondSymbol)
                {
                    CountSimilarSymbols++;
                    SecondSymbol = source.ReadByte();
                    while (FirstSymbol == SecondSymbol & SecondSymbol != -1)
                    {
                        if (StopClicked == true) break;
                        if (CountSimilarSymbols == 255)
                        {
                            CountDissimilarSymbols--;
                            source.Seek(source.Position - 1, SeekOrigin.Begin);
                            break;
                        }
                        CountSimilarSymbols++;
                        SecondSymbol = source.ReadByte();
                    }
                    bufArrCount = Encoding.Default.GetBytes(CountSimilarSymbols.ToString());
                    dest.Write(bufArrCount, 0, bufArrCount.Length);
                    dest.WriteByte((byte)FirstSymbol);

                    // если есть еще 1 уже другой символ в конце
                    if (source.Position == source.Length & SecondSymbol != FirstSymbol)
                    {
                        dest.WriteByte(49);
                        dest.WriteByte((byte)SecondSymbol);
                    }

                    FirstSymbol = SecondSymbol;

                    CountSimilarSymbols = 1;

                    Progress = source.Position * 100 / DataLength;
                    pbNotifyRLEPacker?.Invoke(Progress);

                    continue;
                }

                if (FirstSymbol != SecondSymbol)
                {
                    arrBytesWrite[0] = (byte)FirstSymbol;
                    arrBytesWrite[1] = (byte)SecondSymbol;

                    SecondSymbol = source.ReadByte();

                    int i = 2; // iterator
                    while (SecondSymbol != arrBytesWrite[CountDissimilarSymbols - 1] && SecondSymbol != -1)
                    {
                        if (i == 255) break; // чтобы не выходило за границы массива
                        CountDissimilarSymbols++;
                        arrBytesWrite[i] = (byte)SecondSymbol; 

                        SecondSymbol = source.ReadByte();

                        i++;
                    }
                    if (StopClicked == true) break;
                    if (SecondSymbol == arrBytesWrite[CountDissimilarSymbols - 1])
                    {
                        CountDissimilarSymbols--;
                        source.Seek(source.Position - 1, SeekOrigin.Begin);
                    }

                    bufArrCount = Encoding.Default.GetBytes(CountDissimilarSymbols.ToString());
                    dest.WriteByte(3); // null по кодировке ASCII
                    dest.Write(bufArrCount, 0, bufArrCount.Length);
                    dest.WriteByte(3); // null по кодировке ASCII
                    dest.Write(arrBytesWrite, 0, CountDissimilarSymbols);

                    Progress = source.Position * 100 / DataLength;
                    pbNotifyRLEPacker?.Invoke(Progress);

                    CountDissimilarSymbols = 2;
                    FirstSymbol = SecondSymbol;
                }

            }
        }

        internal void StreamUnpack(Stream source, Stream dest)
        {
            Progress = 0;
            pbNotifyRLEPacker?.Invoke(Progress);
            DataLength = source.Seek(0, SeekOrigin.End);

            source.Seek(0, SeekOrigin.Begin); // ставим курсор на начало файла

            FirstSymbol = source.ReadByte();
            byte[] buffer = new byte[4];
            int iterator;

            while (source.Position != source.Length)
            {
                if(FirstSymbol != 3)
                {
                    //находим количество повторющихся символов
                    iterator = 0;
                    while (FirstSymbol != 3 & FirstSymbol != -1)
                    {
                        buffer[iterator] = (byte)FirstSymbol;
                        FirstSymbol = source.ReadByte();
                        iterator++;
                    }
                    CountSimilarSymbols = countSymbols(buffer, iterator - 1);
                    //записываем в файл повторяющиеся символы
                    for (int i = 0; i < CountSimilarSymbols; i++)
                    {
                        dest.WriteByte(buffer[iterator - 1]);
                    }
                    Progress = source.Position / DataLength * 100;
                    pbNotifyRLEPacker?.Invoke(Progress);
                }

                if (FirstSymbol == 3)
                {
                    iterator = 0;
                    FirstSymbol = source.ReadByte();
                    while (FirstSymbol != 3)
                    {
                        buffer[iterator] = (byte)FirstSymbol;
                        FirstSymbol = source.ReadByte();
                        iterator++;
                    }
                    CountDissimilarSymbols = countSymbols(buffer, iterator);
                    for (int i = 0; i < CountDissimilarSymbols; i++)
                    {
                        dest.WriteByte((byte)source.ReadByte());
                    }
                    FirstSymbol = source.ReadByte();
                    Progress = source.Position / DataLength * 100;
                    pbNotifyRLEPacker?.Invoke(Progress);
                }
                if (StopClicked == true) break;
            }
        }

        internal int countSymbols(byte[] buffer, int countDigits)
        {
            /*byte[] bufferDecimal = new byte[4];
            for (int i = 0; i < iterator; i++)
            {
                bufferDecimal[i] = buffer[i];
            }

            return BitConverter.ToInt32(bufferDecimal, 0);*/
            // если countDigits == 3, то первые три символа в массиве - количество повторяющихся/неповторяющихся символов
            // аналогично для остальных случаев
            switch (countDigits)
            {
                case 3:
                    return (buffer[0] - 48) * 100 + (buffer[1] - 48) * 10 + buffer[2] - 48;
                case 2:
                    return (buffer[0] - 48) * 10 + (buffer[1] - 48);
                default:
                    return buffer[0] - 48;
            }
        }

        public long Progress { get; set; }
        
        public void Stop()
        {
            StopClicked = true;
        }
    }
}
