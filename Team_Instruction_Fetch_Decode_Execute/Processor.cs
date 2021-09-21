using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{
    class Processor
    {
        public string[] Memory { get; set; }

        public ushort Accumulator { get; set; }

        public ushort X_Register { get; set; }

        public ushort ProgramCounter { get; set; }

        public ushort StackRegister { get; set; }

        public bool NegativeFlag { get; set; }

        public bool CarryFlag { get; set; }

        public bool ZeroFlag { get; set; }

        public bool TrueFlag { get; set; }

        //keeps track of the last place memory was entered
        public int counter { get; set; }

        public Processor()
        {
            Memory = new string[1048576];
            Accumulator = 0x0000;
            X_Register = 0x0000;
            ProgramCounter = 0x0000;
            StackRegister = 0x0000;
            NegativeFlag = false;
            CarryFlag = false;
            ZeroFlag = false;
            TrueFlag = false;
        }

        public void memoryEntry(string entryCode)
        {
            char[] entryCodeArray = entryCode.ToCharArray();

            for(int i = 0; i  < entryCodeArray.Length - 3; i+=3)
            {                    
                Memory[counter] = entryCodeArray[i].ToString() + entryCodeArray[i + 1].ToString();

                counter++;
            }
        }

        public string formatMemory()
        {
            int newLineCounter = 0;
            StringBuilder formattedMem = new StringBuilder();

            for(int i = 0; i < counter; i++)
            {
                formattedMem.Append(Memory[i] + " ");
                newLineCounter++;

                if(newLineCounter >= 8)
                {
                    formattedMem.Append("\n");
                }

            }

            return formattedMem.ToString();
        }
    }
}
