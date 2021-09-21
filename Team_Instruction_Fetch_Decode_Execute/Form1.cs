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

        Processor primaryProcessor; 

        public Form1()
        {
            primaryProcessor = new Processor();
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath;

            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile.FileName;

                //grab text from the file
                string text = File.ReadAllText(filePath);

                primaryProcessor.memoryEntry(text);

                BinaryTextBox.Text = primaryProcessor.formatMemory();
            }



        }
    }
}
