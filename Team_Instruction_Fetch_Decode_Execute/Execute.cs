using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{
    public static class Execute
    {
        //class for if a method is used often for more than one exec instruction)

        public static ushort Add(ushort registerOne, ushort operand)
        {
            return (ushort)(registerOne + operand);
        }

        public static ushort Sub(ushort registerOne, ushort operand)
        {
            return (ushort)(registerOne - operand);
        }

        public static ushort AND_OP(ushort registerOne, ushort operand)
        {
            return (ushort)(registerOne & operand);
        }

        public static ushort OR_OP(ushort registerOne, ushort operand)
        {
            return (ushort)(registerOne | operand);
        }

        public static ushort XOR_OP(ushort registerOne, ushort operand)
        {
            return (ushort)(registerOne ^ operand);
        }
    }
}
