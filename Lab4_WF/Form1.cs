using System;
using System.IO;
using System.Windows.Forms;

namespace Lab4_WF
{
    public partial class Form1 : Form
    {
        Packer packer = new Packer();
        public Form1()
        {
            InitializeComponent();
        }


        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            openFileDialog.InitialDirectory = @"C:\"; // директория по умолчанию
            if (openFileDialog.FileName != "")
            {
                sourceFileNameTextBox.Text = openFileDialog.FileName;
                Packer.SourceFileName = openFileDialog.FileName;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            saveFileDialog.InitialDirectory = @"C:\"; // директория по умолчанию
            if (saveFileDialog.FileName != "")
            {
                destFileNameTextBox.Text = saveFileDialog.FileName;
                Packer.DestFileName = saveFileDialog.FileName;
            }
        }

        private void SetProgressValue(long progress)
        {
            progressBar.Value = (int) progress;
            Application.DoEvents();
        }

        private void packButton_Click(object sender, EventArgs e)
        {
            progressBar.Maximum = 100;

            packer.pbNotifyPacker += SetProgressValue;

            packer.Pack();

            // удаление файла, если была нажата кнопка стоп
            if (StopIsClicked == true) File.Delete(destFileNameTextBox.Text);
        }

        private void unpackButton_Click(object sender, EventArgs e)
        {
            progressBar.Maximum = 100;

            packer.pbNotifyPacker += SetProgressValue;

            packer.Unpack();

            // удаление файла, если была нажата кнопка стоп
            if (StopIsClicked == true) File.Delete(destFileNameTextBox.Text);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            packer.Stop();

            StopIsClicked = true;
        }

        bool StopIsClicked { get; set; } = false;
    }
}