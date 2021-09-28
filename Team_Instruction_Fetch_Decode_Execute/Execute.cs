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

		public static ushort LDA (ushort operand)
		{
			return (ushort) operand;
		}

		public static ushort LDX (ushort operand)
		{
			return (ushort) operand;
		}

		public static ushort STA (ushort operand)
		{
			return (ushort) operand;
		}

		public static bool CPGT (ushort registerOne, ushort operand)
		{
			if (registerOne > operand)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CPGE (ushort registerOne, ushort operand)
		{
			if (registerOne >= operand)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static ushort NEG (ushort register)
		{
			return (ushort) (register * -1);
		}

		public static ushort NOT (ushort register)
		{
			return (ushort) ~register;
		}
	}
}