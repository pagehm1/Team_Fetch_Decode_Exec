///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:           Project 1 - Instruction Set
//	File Name:         Processor.cs
//	Description:       Emulates a computer processor that reads in and executes instructions.
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
	/// Emulates a computer processor.
	/// </summary>
	public class Processor
	{
		#region Processor Properties
		/// <summary>
		/// Instance of Windows form.
		/// </summary>
		public Form1 Form;

		/// <summary>
		/// Byte array the represents computer memory.
		/// </summary>
		public byte[] Memory { get; set; }

		/// <summary>
		/// Accumulator register.
		/// </summary>
		public ushort Accumulator { get; set; }

		/// <summary>
		/// X register.
		/// </summary>
		public ushort X_Register { get; set; }

		/// <summary>
		/// Program counter for the CPU.
		/// </summary>
		public ushort ProgramCounter { get; set; }

		/// <summary>
		/// Stack register.
		/// </summary>
		public ushort StackRegister { get; set; }

		/// <summary>
		/// Boolean representing negative flag for results.
		/// </summary>
		public bool NegativeFlag { get; set; }

		/// <summary>
		/// Boolean representing carry flag for results.
		/// </summary>
		public bool CarryFlag { get; set; }

		/// <summary>
		/// Boolean representing zero flag for results.
		/// </summary>
		public bool ZeroFlag { get; set; }

		/// <summary>
		/// True or false based on comparison results.
		/// </summary>
		public bool TrueFlag { get; set; }

		/// <summary>
		/// Counter variable.
		/// </summary>
		public int counter { get; set; }

		/// <summary>
		/// Represents if CPU is stopped or not.
		/// </summary>
		public int IsStopped { get; set; }

		/// <summary>
		/// Represents string of instruction to be displayed.
		/// </summary>
		public string InstructionRep { get; set; }

		/// <summary>
		/// List for updated items.
		/// </summary>
		public List<Object> updatedItems { get; set; }
		#endregion

		/// <summary>
		/// Constructor that makes a new processor with a Form.
		/// </summary>
		/// <param name="form">The GUI Form.</param>
		public Processor(Form1 form)
		{
			Form = form;
			Memory = new byte[1048576];
			Accumulator = 0x0000;
			X_Register = 0x0000;
			ProgramCounter = 0x0000;
			StackRegister = 0x0000;
			NegativeFlag = false;
			CarryFlag = false;
			ZeroFlag = false;
			TrueFlag = false;
		}

		/// <summary>
		/// Fills the memory array.
		/// </summary>
		/// <param name="byteToInsert">Byte going into memory.</param>
		public void PopulateMemory(byte byteToInsert)
		{
			Memory[counter] = byteToInsert;
			counter++;
		}

		/// <summary>
		/// Decodes a byte into opcode instructions.
		/// </summary>
		/// <param name="byteToDecode">Byte to be decoded.</param>
		/// <returns>String representation.</returns>
		public string Decode(byte byteToDecode)
		{
			//string returnString = "";
			ushort operand;

			byte upperNibble = (byte)(byteToDecode >> 4);
			byte lowerNibble = (byte)(byteToDecode & 0b00001111);

			// Decodes the byte based on upper and lower nibbles
			switch (upperNibble)
			{
				#region ADD or SUB Instruction
				case 0x00: // ADD or SUB Instruction
					if (lowerNibble == 0x01) // ADD (A + X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "ADD X", " ", false);

						Accumulator = Execute.Add(Accumulator, X_Register);
						
					}
					else if (lowerNibble == 0x02) // ADD (A + IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "ADD", "imm", true);

						Accumulator = Execute.Add(Accumulator, operand);

					}
					else if (lowerNibble == 0x03) // ADD (A + MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "ADD", "mem", true);

						Accumulator = Execute.Add(Accumulator, Memory[operand]);
					}
					else if (lowerNibble == 0x09) // SUB (A - X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "SUB X", " ", false);

						Accumulator = Execute.Sub(Accumulator, X_Register);
					}
					else if(lowerNibble == 0x0A) // SUB (A - IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "SUB", "imm", true);

						Accumulator = Execute.Sub(Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // SUB (A - MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "SUB", "mem", true);

						Accumulator = Execute.Sub(Accumulator, Memory[operand]);
					}

					if ((short) Accumulator < 0)
					{
						NegativeFlag = true;
					}
					else if ((short) Accumulator == 0)
					{
						ZeroFlag = true;
					}

					break;
				#endregion
				#region AND or OR Instruction
				case 0x01: // AND or OR Instruction
					if (lowerNibble == 0x01) // AND (A & X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "AND X", " ", false);

						Accumulator = Execute.AND_OP(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // AND (A & IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "AND", "imm", true);

						Accumulator = Execute.AND_OP(Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // AND (A & MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "AND", "mem", true);

						Accumulator = Execute.AND_OP(Accumulator, Memory[operand]);
					}
					else if (lowerNibble == 0x09) // OR (A | X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "OR X", " ", false);

						Accumulator = Execute.OR_OP(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // OR (A | IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "OR", "imm", true);

						Accumulator = Execute.OR_OP(Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // OR (A | MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "OR", "mem", true);

						Accumulator = Execute.OR_OP(Accumulator, Memory[operand]);
					}

					if ((short) Accumulator < 0)
					{
						NegativeFlag = true;
					}
					else if ((short) Accumulator == 0)
					{
						ZeroFlag = true;
					}


					break;
				#endregion
				#region XOR or LDA Instruction
				case 0x02: // XOR or LDA Instruction
					if (lowerNibble == 0x01) // XOR (A ^ X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "XOR X", " ", false);

						Accumulator = Execute.XOR_OP(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // XOR (A ^ IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "XOR", "imm", true);

						Accumulator = Execute.XOR_OP(Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // XOR (A ^ MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "XOR", "mem", true);

						Accumulator = Execute.XOR_OP(Accumulator, Memory[operand]);
					}
					else if (lowerNibble == 0x09) // LDA (X -> A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "LDA X", " ", false);

						Accumulator = Execute.LDA(X_Register);
					}
					else if (lowerNibble == 0x0A) // LDA (IMM -> A)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDA", "imm", true);

						Accumulator = Execute.LDA(operand);
					}
					else if (lowerNibble == 0x0B) // LDA (MEM -> A)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDA", "mem", true);

						Accumulator = Execute.LDA(Memory[operand]);
					}

					if ((short) Accumulator < 0)
					{
						NegativeFlag = true;
					}
					else if ((short) Accumulator == 0)
					{
						ZeroFlag = true;
					}

					break;
				#endregion
				#region LDX or STA Instruction
				case 0x03: // LDX or STA Instruction
					if (lowerNibble == 0x00) // LDX (A -> X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX A", " ", false);

						X_Register = Execute.LDX(Accumulator);

						if ((short) X_Register < 0)
						{
							NegativeFlag = true;
						}
						else if ((short) X_Register == 0)
						{
							ZeroFlag = true;
						}
					}
					else if (lowerNibble == 0x02) // LDX (IMM -> X)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX", "imm", true);

						X_Register = Execute.LDX(operand);

						if ((short) X_Register < 0)
						{
							NegativeFlag = true;
						}
						else if ((short) X_Register == 0)
						{
							ZeroFlag = true;
						}
					}
					else if (lowerNibble == 0x03) // LDX (MEM -> X)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX", "mem", true);

						X_Register = Execute.LDX(Memory[operand]);

						if ((short) X_Register < 0)
						{
							NegativeFlag = true;
						}
						else if ((short) X_Register == 0)
						{
							ZeroFlag = true;
						}
					}
					else if (lowerNibble == 0x09) // STA (A -> X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "STA X", " ", false);

						X_Register = Execute.STA(Accumulator);
					}
					else if (lowerNibble == 0x0B) // STA (A -> MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "STA", "mem", true);

						//Memory[operand] = Execute.STA(Accumulator);
					}

					break;
				#endregion
				#region STX or BRT Instruction
				case 0x04: // STX or BRT Instruction
					if (lowerNibble == 0x00) // STX (X -> A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "STX A", " ", false);
					}
					else if (lowerNibble == 0x03) // STX (X -> MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "STX", "mem", true);
					}
					else if (lowerNibble == 0x0B) // BRT (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "BRT", "mem", true);
					}

					break;
				#endregion
				#region BRNT or CPE Instruction
				case 0x05: // BRNT or CPE Instruction
					if (lowerNibble == 0x03) // BRNT (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "BRNT", "mem", true);
					}
					else if (lowerNibble == 0x09) // CPE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE X", " ", false);
						TrueFlag = Execute.CPE (Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // CPE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE", "imm", true);
						TrueFlag = Execute.CPE (Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // CPE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE", "mem", true);
						TrueFlag = Execute.CPE (Accumulator, operand);
					}

					break;
				#endregion
				#region CPLT or CPLE Instruction
				case 0x06: // CPLT or CPLE Instruction
					if (lowerNibble == 0x01) // CPLT (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT X", " ", false);
						TrueFlag = Execute.CPLT (Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // CPLT (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT", "imm", true);
						TrueFlag = Execute.CPLT (Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // CPLT (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT", "mem", true);
						TrueFlag = Execute.CPLT (Accumulator, operand);
					}
					else if (lowerNibble == 0x09) // CPLE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE X", " ", false);
						TrueFlag = Execute.CPLE (Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // CPLE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE", "imm", true);
						TrueFlag = Execute.CPLE (Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // CPLE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE", "mem", true);
						TrueFlag = Execute.CPLE (Accumulator, operand);
					}

					break;
				#endregion
				#region CPGT or CPGE Instruction
				case 0x07: // CPGT or CPGE Instruction
					if (lowerNibble == 0x01) // CPGT (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT X", " ", false);

						TrueFlag = Execute.CPGT(Accumulator, X_Register);

					}
					else if (lowerNibble == 0x02) // CPGT (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT", "imm", true);

						TrueFlag = Execute.CPGT(Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // CPGT (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT", "mem", true);

						TrueFlag = Execute.CPGT(Accumulator, Memory[operand]);
					}
					else if (lowerNibble == 0x09) // CPGE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE X", " ", false);

						TrueFlag = Execute.CPGE(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // CPGE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE", "imm", true);

						TrueFlag = Execute.CPGE(Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // CPGE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE", "mem", true);

						TrueFlag = Execute.CPGE(Accumulator, Memory[operand]);
					}

					break;
				#endregion
				#region PUSH or POP Instruction
				case 0x08: // PUSH or POP Instruction
					if (lowerNibble == 0x00) // PUSH (A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH A", " ", false);
					}
					else if (lowerNibble == 0x01) // PUSH (X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH X", " ", false);
					}
					else if (lowerNibble == 0x02) // PUSH (IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH", "imm", true);
					}
					else if (lowerNibble == 0x03) // PUSH (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH", "mem", true);
					}
					else if (lowerNibble == 0x08) // POP
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "POP", " ", false);
					}

					break;
				#endregion
				#region NEG or NOT Instruction
				case 0x09: // NEG or NOT Instruction
					if (lowerNibble == 0x00) // NEG (A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NEG A", " ", false);

						Accumulator = Execute.NEG(Accumulator);

						if ((short) Accumulator < 0)
						{
							NegativeFlag = true;
						}
						else if ((short) Accumulator == 0)
						{
							ZeroFlag = true;
						}
					}
					else if (lowerNibble == 0x01) // NEG (X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NEG X", " ", false);

						X_Register = Execute.NEG(X_Register);

						if ((short) X_Register < 0)
						{
							NegativeFlag = true;
						}
						else if ((short) X_Register == 0)
						{
							ZeroFlag = true;
						}
					}
					else if (lowerNibble == 0x08) // NOT (A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NOT A", " ", false);

						Accumulator = Execute.NOT(Accumulator);

						if ((short) Accumulator < 0)
						{
							NegativeFlag = true;
						}
						else if ((short) Accumulator == 0)
						{
							ZeroFlag = true;
						}
					}
					else if (lowerNibble == 0x09) // NOT (X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NOT X", " ", false);

						X_Register = Execute.NOT(X_Register);

						if ((short) X_Register < 0)
						{
							NegativeFlag = true;
						}
						else if ((short) X_Register == 0)
						{
							ZeroFlag = true;
						}
					}

					break;
				#endregion
				#region UBR Instruction
				case 0x0A: // UBR Instruction
					if (lowerNibble == 0x03) // UBR (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "UBR", "mem", true);
					}

					break;
				#endregion
				#region YD Instruction
				case 0x0F: // YD Instruction
					if (lowerNibble == 0x0F) // YD (None)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "YD", " ", false);

						IsStopped = 1;
					}

					break;
				#endregion
				#region Default
				default:
					// Insert code to handle bad instruction opcode?
					break;
				#endregion
			}

			// Update GUI
			Form.UpdateRegisters();
			Form.UpdateFlags();
			
			return " ";
		}

		/// <summary>
		/// Get the operand from memory for the instruction.
		/// </summary>
		/// <returns>The operand in memory.</returns>
		public ushort FetchOperand()
		{
			ProgramCounter++; // Increment the program counter

			ushort operand = (ushort)(Memory[ProgramCounter]); // Load in the first byte of the 16-bit operand

			operand <<= 8; // Perform a left shift 8 times to move the first byte to the upper bits of the operand

			ProgramCounter++; // Increment the program counter

			operand += (ushort)(Memory[ProgramCounter]); // Load in the second byte of the 16-bit operand to the lower bits of the operand

			ProgramCounter++; // Increment the program counter

			return operand; // Return the constructed 16-bit operand
		}

		/// <summary>
		/// Creates the string representation of instruction.
		/// </summary>
		/// <param name="currentPC">Program counter.</param>
		/// <param name="instructionOpcode">Instruction opcode.</param>
		/// <param name="instructionName">Name of instruction.</param>
		/// <param name="addressingName">Addressing mode.</param>
		/// <param name="hasOperand">True if operand is present.</param>
		/// <returns>Operand if needed.</returns>
		public ushort ConstructInstructionRep(ushort currentPC, byte instructionOpcode, string instructionName, string addressingName, bool hasOperand)
		{
			ushort operand;
			string tempInstructionRep;

			tempInstructionRep = currentPC.ToString() + " " + instructionOpcode.ToString() + " " + instructionName + " ";

			if (hasOperand)
			{
				operand = FetchOperand();

				tempInstructionRep += operand.ToString() + ", " + addressingName;

				InstructionRep = tempInstructionRep;

				return operand;
			}
			else
			{
				InstructionRep = tempInstructionRep;

				return 0;
			}
		}

		/*
		public void incrementPC()
		{
			ProgramCounter++;
		}

		public void Execute(byte byteToDecode)
		{
			//string returnString = "";
			ushort operand;

			byte upperNibble = (byte)(byteToDecode >> 4);
			byte lowerNibble = (byte)(byteToDecode & 0b00001111);

			switch (instructionBits)
			{
				case 0x00:
					if (lowerNibble == 0x01) // ADD (A + X)
					{
						return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " ADD X";
					}
					else if (lowerNibble == 0x02) // ADD (A + IMM)
					{
						operand = FetchOperand();
						return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " ADD " + operand.ToString() + ", imm";
					}
					else if (lowerNibble == 0x03) // ADD (A + MEM)
					{
						operand = FetchOperand();
						return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " ADD " + operand.ToString() + ", mem";
					}
					else if (lowerNibble == 0x09) // SUB (A - X)
					{
						return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " SUB X";
					}
					else if (lowerNibble == 0x0A) // SUB (A - IMM)
					{
						operand = FetchOperand();
						return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " SUB " + operand.ToString() + ", imm";
					}
					else if (lowerNibble == 0x0B) // SUB (A - MEM)
					{
						operand = FetchOperand();
						return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " SUB " + operand.ToString() + ", mem";
					}

					break;
				default:
					break;           
		}
		*/
	}
}