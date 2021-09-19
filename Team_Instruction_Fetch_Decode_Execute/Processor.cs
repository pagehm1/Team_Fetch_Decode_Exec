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
    }
}
