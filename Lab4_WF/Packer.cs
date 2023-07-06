using System;
using System.IO;

namespace Lab4_WF
{
    class Packer
    {

        public delegate void ProgressBarPacker(long progress);
        public event ProgressBarPacker pbNotifyPacker;
        public static string SourceFileName { get; set; } // путь по которому, надо открыть файл
        public static string DestFileName { get; set; } // путь по которому надо сохранить файл

        RLEPacker packer = new RLEPacker();
        RLEPacker unpacker = new RLEPacker();
        public void Pack()
        {
            Stream fileStreamReader = new FileStream(SourceFileName, FileMode.Open); // создаём поток для считывания
            Stream fileStreamWriter = new FileStream(DestFileName, FileMode.Create); // создаём поток для записи
 
            packer.pbNotifyRLEPacker += SetProgressValue;
            packer.StreamPack(fileStreamReader, fileStreamWriter);

            fileStreamReader.Close();
            fileStreamWriter.Close();
        }
        public void Unpack()
        {
            Stream fileStreamReader = new FileStream(SourceFileName, FileMode.Open); // создаём поток для считывания
            Stream fileStreamWriter = new FileStream(DestFileName, FileMode.Create); // создаём поток для записи

            unpacker.pbNotifyRLEPacker += SetProgressValue;
            //unpacker.StreamUnpack(fileStreamReader, fileStreamWriter);

            fileStreamReader.Close();
            fileStreamWriter.Close();
        }

        public long Progress { get; set; }

        private void SetProgressValue(long progress)
        {
            pbNotifyPacker?.Invoke(progress);
        }

        public void Stop() 
        {
            packer.Stop();
            unpacker.Stop();
        }
    }
}