using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{

    public class Statistics
    {
        public int totalInstructions { get; set; }

        public int unaryInstructions { get; set; }

        public int nonUnaryInstructions { get; set; }

        public int controlInstructions { get; set; }

        public int arithmeticInstructions { get; set; }

        public int logicInstructions { get; set; }

        public int immediateAddressing { get; set; }

        public int accumulatorAddressing { get; set; }

        public int xRegisterAddressing { get; set; }

        public int memoryAddressing { get; set; }

        public int noAddresssing { get; set; }

        public Statistics()
        {

        }
    }
    
}