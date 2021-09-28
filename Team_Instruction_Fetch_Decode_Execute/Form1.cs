using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Instruction_Fetch_Decode_Execute
{
    public partial class Form1 : Form
    {

        public Processor primaryProcessor;
        public long position;

        public Form1()
        {
            primaryProcessor = new Processor();
            position = 0;
            InitializeComponent();
        }

        public void StartProc()
        {
            while (primaryProcessor.IsStopped != 1)
            {
              //ListBox.Add(primaryProcessor.Decode(primaryProcessor.Memory[primaryProcessor.ProgramCounter])); // Add string we built about instruction into list box

              //AccumulatorTextBox.Text = primaryProcessor.Accumulator;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath;

            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile.FileName;

                BinaryReader binReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read));

                position = binReader.BaseStream.Position;

                long length = binReader.BaseStream.Length;

                for(int i = 0; i < length; i++)
                {
                    byte[] instructionPiece = read(binReader);

                    primaryProcessor.PopulateMemory(instructionPiece[0]);
                    populateBinaryTextBox(instructionPiece[0]);

                }

                binaryFileMaker(filePath);

                //StartProc();
            }



        }

        /// <summary>
        /// reads a record from a binary file
        /// </summary>
        /// <param name="size">amount of bytes we are reading from the binary file</param>
        /// <returns>byte[] array, holds the bytes that we just read in</returns>
        public byte[] read(BinaryReader binInFile)
        {
            position += 1; //increases the position of where we are at in the binary file
            byte[] buffer = new byte[1];
            binInFile.Read(buffer, 0, 1);

            return (buffer);
        } // read()

        public void binaryFileMaker(string filePath)
        {

            filePath += ".bin";
            BinaryWriter binWriter = new BinaryWriter(File.Open(filePath, FileMode.Create, FileAccess.Write));

            byte[] testArray = new byte[5] {0x32, 0x29, 0x01, 0x2B, 0xFF};

            binWriter.Write(testArray);

            binWriter.Close();
        }

        public void populateBinaryTextBox(byte byteToDisplay)
        {
            if ((byteToDisplay >> 4) > 0x09)
            {
                BinaryTextBox.Text += (char)((byteToDisplay >> 4) + 0x37);
            }
            else
            {
                BinaryTextBox.Text += (char)((byteToDisplay >> 4) + 0x30);
            }

            if ((byteToDisplay & 0b00001111) > 0x09)
            {
                BinaryTextBox.Text += (char)((byteToDisplay & 0b00001111) + 0x37);
            }
            else
            {
                BinaryTextBox.Text += (char)((byteToDisplay & 0b00001111) + 0x30);
            }

            BinaryTextBox.Text += " ";
        }

        public void populateStatisticsListBox(string str)
        {
            //This will but each stat into the box on the gui, which will come from the statistics class.
        }
    }
}
