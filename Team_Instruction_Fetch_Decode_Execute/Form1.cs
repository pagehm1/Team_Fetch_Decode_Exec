﻿using System;
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
			primaryProcessor = new Processor(this);
			position = 0;
			InitializeComponent();
		}

        public void StartProc()
        {
            while (primaryProcessor.IsStopped != 1)
            {
				try
				{
					outputListBox.Items.Add(primaryProcessor.Decode(primaryProcessor.Memory[primaryProcessor.ProgramCounter]));
				}
				catch (Exception)
                {
					MessageBox.Show("ERROR: Please load a binary file before Decoding/Executing!");

					break;
				}
			}

			primaryProcessor.ProcessorStats.formatStats();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string filePath;

			OpenFileDialog openFile = new OpenFileDialog();

			if (openFile.ShowDialog() == DialogResult.OK)
			{
				filePath = openFile.FileName;

				BinaryReader binReader = new BinaryReader(File.Open (filePath, FileMode.Open, FileAccess.Read));

				position = binReader.BaseStream.Position;

				long length = binReader.BaseStream.Length;

				for (int i = 0; i < length; i++)
				{
					byte[] instructionPiece = read(binReader);

					primaryProcessor.PopulateMemory(instructionPiece[0]);
					populateBinaryTextBox(instructionPiece[0]);
					UpdateRegisters();
					UpdateFlags();
				}

                //binaryFileMaker(filePath);
				binReader.Close();
                
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

			return(buffer);
		} // read()

		public void binaryFileMaker(string filePath)
		{
			filePath += ".bin";
			BinaryWriter binWriter = new BinaryWriter(File.Open(filePath, FileMode.Create, FileAccess.Write));

            byte[] testArray = new byte[21] { 0x2A, 0x05, 0xA3, 0x30, 0x59, 0x4B, 0x00, 0x00, 0x0D, 0x53, 0x00, 0x00, 0x14, 0x02, 0x00, 0x01, 0xA3, 0x00, 0x00, 0x04, 0xFF };

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

        private void decodeButton_Click_1(object sender, EventArgs e)
        {
            StartProc();
        }

		public void UpdateRegisters()
		{
			tbAccumulator.Text = primaryProcessor.Accumulator.ToString();
			tbXRegister.Text = primaryProcessor.X_Register.ToString();
			tbStack.Text = primaryProcessor.StackRegister.ToString();
			tbProgramCounter.Text = primaryProcessor.ProgramCounter.ToString();
		}

		public void UpdateFlags()
		{
			tbNegFlag.Text = primaryProcessor.NegativeFlag.ToString();
			tbCarryFlag.Text = primaryProcessor.CarryFlag.ToString();
			tbZeroFlag.Text = primaryProcessor.ZeroFlag.ToString();
			tbTruthFlag.Text = primaryProcessor.TrueFlag.ToString();
		}

        private void Decoding_Button_Click(object sender, EventArgs e)
        {
			StartProc();
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }

		public void populateStats(string[] str)
		{
			foreach(string s in str)
			{
				statisticsTextBox.Items.Add(s);
			}
		}

		public void populateAddress(string[] str)
		{
			foreach(string s in str)
			{
				addressingListBox.Items.Add(s);
			}
		}

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Team 3 - Instruction Set Simulation: created by Hunter Page, Zakk Trent, Micah DePetro, and Brett Hamilton.");
        }
    }
}