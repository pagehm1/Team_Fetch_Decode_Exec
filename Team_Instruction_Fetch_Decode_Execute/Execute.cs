///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:           Project 1 - Instruction Set
//	File Name:         Execute.cs
//	Description:       Execute methods for the Processor to use
//	Course:            CSCI 4717 - Computer Architecture	
//	Author:            Hunter Page, pagehm1@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, September 13, 2021
//	Copyright:         Hunter Page, Zakk Trent, Micah DePetro, and Brett Hamilton, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{
	/// <summary>
	/// Collection of Execute methods the Processor can use based on opcodes decoded.
	/// </summary>
	public static class Execute
	{
		/// <summary>
		/// Adds operand to register.
		/// </summary>
		/// <param name="registerOne">Register holding first operand.</param>
		/// <param name="operand">Operand to add to register.</param>
		/// <returns>Sum of register and operand.</returns>
		public static ushort Add(ushort registerOne, uint operand)
		{
			return (ushort)(registerOne + operand);
		}

		/// <summary>
		/// Subtracts operand to register.
		/// </summary>
		/// <param name="registerOne">Register holding first operand.</param>
		/// <param name="operand">Operand to sub from register.</param>
		/// <returns>Sub result of register and operand.</returns>
		public static ushort Sub(ushort registerOne, uint operand)
		{
			return (ushort)(registerOne - operand);
		}

		/// <summary>
		/// Bitwise AND operation between a register and operand.
		/// </summary>
		/// <param name="registerOne">Register holding first operand.</param>
		/// <param name="operand">Operand to AND with register.</param>
		/// <returns>AND-ed result of register and operand.</returns>
		public static ushort AND_OP(ushort registerOne, uint operand)
		{
			return (ushort)(registerOne & operand);
		}

		/// <summary>
		/// Bitwise OR operation between a register and operand.
		/// </summary>
		/// <param name="registerOne">Register holding first operand.</param>
		/// <param name="operand">Operand to OR with register.</param>
		/// <returns>OR-ed result of register and operand.</returns>
		public static ushort OR_OP(ushort registerOne, uint operand)
		{
			return (ushort)(registerOne | operand);
		}

		/// <summary>
		/// Bitwise XOR operation between a register and operand.
		/// </summary>
		/// <param name="registerOne">Register holding first operand.</param>
		/// <param name="operand">Operand to XOR with register.</param>
		/// <returns>XOR-ed result of register and operand.</returns>
		public static ushort XOR_OP(ushort registerOne, uint operand)
		{
			return (ushort)(registerOne ^ operand);
		}

		/// <summary>
		/// Loads an operand into Accumulator register.
		/// </summary>
		/// <param name="operand">Value to load in Accumulator.</param>
		/// <returns>Value to load in Accumulator.</returns>
		public static ushort LDA(uint operand)
		{
			return (ushort) operand;
		}

		/// <summary>
		/// Loads an operand into X register.
		/// </summary>
		/// <param name="operand">Value to load in X Register.</param>
		/// <returns>Value to load in X Register.</returns>
		public static ushort LDX(uint operand)
		{
			return (ushort) operand;
		}

		/// <summary>
		/// Stores an operand into Accumulator register.
		/// </summary>
		/// <param name="operand">Value to store in Accumulator Register.</param>
		/// <returns>Value to store in X Register.</returns>
		public static ushort STA(uint operand)
		{
			return (ushort) operand;
		}

		/// <summary>
		/// Compares if operand is equal to a register's value.
		/// </summary>
		/// <param name="registerOne">The register to compare to.</param>
		/// <param name="operand">The operand to compare to the register.</param>
		/// <returns>True if equal, false otherwise.</returns>
		public static bool CPE (ushort registerOne, uint operand)
		{
			if (registerOne == operand)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Compares if operand is less than to a register's value.
		/// </summary>
		/// <param name="registerOne">The register to compare to.</param>
		/// <param name="operand">The operand to compare to the register.</param>
		/// <returns>True if register value is less than operator, false otherwise.</returns>
		public static bool CPLT (ushort registerOne, uint operand)
		{
			if (registerOne < operand)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Compares if operand is less than or equal to a register's value.
		/// </summary>
		/// <param name="registerOne">The register to compare to.</param>
		/// <param name="operand">The operand to compare to the register.</param>
		/// <returns>True if register value is less than or equal to operator, false otherwise.</returns>
		public static bool CPLE (ushort registerOne, uint operand)
		{
			if (registerOne <= operand)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Compares if operand is greater than a register's value.
		/// </summary>
		/// <param name="registerOne">The register to compare to.</param>
		/// <param name="operand">The operand to compare to the register.</param>
		/// <returns>True if register value is greater than operator, false otherwise.</returns>
		public static bool CPGT(ushort registerOne, uint operand)
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

		/// <summary>
		/// Compares if operand is greater than or equal to a register's value.
		/// </summary>
		/// <param name="registerOne">The register to compare to.</param>
		/// <param name="operand">The operand to compare to the register.</param>
		/// <returns>True if register value is greater than or equal to operator, false otherwise.</returns>
		public static bool CPGE(ushort registerOne, uint operand)
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

		/// <summary>
		/// Negates the value in a register.
		/// </summary>
		/// <param name="register">Register holding the value.</param>
		/// <returns>Negated value.</returns>
		public static ushort NEG(ushort register)
		{
			return (ushort) (register * -1);
		}

		/// <summary>
		/// Performs bitwise NOT on register value.
		/// </summary>
		/// <param name="register">Register holding the value.</param>
		/// <returns>NOT-ed value.</returns>
		public static ushort NOT(ushort register)
		{
			return (ushort) ~register;
		}
	}
}