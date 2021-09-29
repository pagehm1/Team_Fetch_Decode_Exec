using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{
    class Statistics

    {
        Form1 form = new Form1();
        public int totalInstructions { get; set; }
        public int unaryInstructions { get; set; }
        public int nonUnaryInstructions { get; set; }
        public int controlFlowInstructions { get; set; }
        public int arithmeticInstructions { get; set; }
        public int logicInstructions { get; set; }
        public int memoryInstructions { get; set; }
        public int immediateAddressing { get; set; }
        public int accumulatorAddressing { get; set; }
        public int xRegisterAddressing { get; set; }
        public int memoryAddressing { get; set; }
        public Statistics()
        {
            totalInstructions = 0;
            unaryInstructions = 0;
            nonUnaryInstructions = 0;
            controlFlowInstructions = 0;
            logicInstructions = 0;
            memoryInstructions = 0;
            immediateAddressing = 0;
            accumulatorAddressing = 0;
            xRegisterAddressing = 0;
            memoryAddressing = 0;
        }

       public void formatStats()
        {

            string[] stats = { "Total Instructions: " + totalInstructions, "Unary Instructions: " + unaryInstructions, "Non-Unary Instructions: " 
                                    + nonUnaryInstructions, "Control Instructions: " + controlFlowInstructions, "Logic Instructions: " + logicInstructions, "Memory Instructions: " + memoryAddressing};
            form.populateStatisticsListBox(stats);

            string[] aStats = { "Immediate Addressing: " + immediateAddressing, "Accumulator Addressing: " + accumulatorAddressing, "X-Register Addresssing: " 
                                    + xRegisterAddressing, "Memory Addressing: " + memoryAddressing};
            form.populateAddressingListBox(aStats);
        }

    }
}
