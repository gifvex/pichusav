using System;
using System.IO;
using System.Windows.Forms;

using RedBlue;
using Emulators;

namespace pichusav
{
    partial class FormMain
    {
        private void LoadFilePrompt()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = filterAll + filterSAV + filterState;
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                LoadFile(openFileDialog1.FileName);
        }

        private void LoadFile(string path)
        {
            byte[] data = new byte[0x8000];

            try
            {
                fileData = File.ReadAllBytes(path);

                switch (GetEmulator(Path.GetExtension(path)))
                {
                    case "GSR": GSR.DecodeSAV(fileData, data); break;
                    case "BGB": BGB.DecodeSAV(fileData, data); break;
                    default: data = fileData; break;
                }

                LoadSAV(data);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Could not load file. (" + e.Message + ")");
                return;
            }

            Text = "..." + path.Substring(Math.Max(0, path.Length - 32));
            filePath = path;
        }

        private void LoadSAV(byte[] data)
        {
            if (!Thunderstone.CheckChecksum(data))
                throw new Exception("Invalid SAV checksum");

            thunderstone.SetSAV(data);

            InitUI();
            PreviewLoad();
        }

        private void SaveFilePrompt()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filter = filterAll;

            switch (GetEmulator(Path.GetExtension(filePath)))
            {
                case "GSR": filter += filterGSR; break;
                case "BGB": filter += filterBGB; break;
                default: filter += filterSAV; break;
            }

            saveFileDialog1.Filter = filter;
            saveFileDialog1.FilterIndex = 2;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                SaveFileAs(saveFileDialog1.FileName);
        }

        private void SaveFile()
        {
            SaveFileAs(filePath);
        }

        private void SaveFileAs(string path)
        {
            byte[] data = thunderstone.GetSAV();

            try
            {
                switch (GetEmulator(Path.GetExtension(path)))
                {
                    case "GSR": GSR.EncodeSAV(data, fileData); break;
                    case "BGB": BGB.EncodeSAV(data, fileData); break;
                    default: fileData = data; break;
                }

                File.WriteAllBytes(path, fileData);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Could not save file. (" + e.Message + ")");
                return;
            }

            MessageBox.Show("File saved to " + path);
        }

        private string GetEmulator(string extension)
        {
            switch (extension)
            {
                case ".gqs":
                    return "GSR";

                case ".sna":
                case ".sn1":
                case ".sn2":
                case ".sn3":
                case ".sn4":
                case ".sn5":
                case ".sn6":
                case ".sn7":
                case ".sn8":
                case ".sn9":
                case ".sn0":
                    return "BGB";
            }

            return "";
        }
    }
}
