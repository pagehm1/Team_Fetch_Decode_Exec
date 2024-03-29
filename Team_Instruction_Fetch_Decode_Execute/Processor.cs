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
		public Form1 Form;

		public byte[] Memory { get; set; }

		public ushort Accumulator { get; set; }

		public ushort X_Register { get; set; }

		public uint ProgramCounter { get; set; }

		public uint StackRegister { get; set; } 

		public bool NegativeFlag { get; set; }

		public bool CarryFlag { get; set; }

		public bool ZeroFlag { get; set; }

		public bool TrueFlag { get; set; }

		public int counter { get; set; }

		public int IsStopped { get; set; }

		public string InstructionRep { get; set; }

		public List<Object> updatedItems { get; set; }  

		public Statistics ProcessorStats { get; set; }
		#endregion

		/// <summary>
		/// Constructor that makes a new processor with a Form.
		/// </summary>
		/// <param name="form">The GUI Form.</param>
		public Processor (Form1 form)
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

			ProcessorStats = new Statistics(form);
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

			uint operand;

			byte upperNibble = (byte)(byteToDecode >> 4);
			byte lowerNibble = (byte)(byteToDecode & 0b00001111);

			switch (upperNibble)
			{
				#region ADD or SUB Instruction
				case 0x00: // ADD or SUB Instruction
					if (lowerNibble == 0x01) // ADD (A + X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "ADD X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
						
						Accumulator = Execute.Add(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // ADD (A + IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "ADD", "imm", true, false);
						ProcessorStats.immediateAddressing++;

						Accumulator = Execute.Add(Accumulator, operand);

					}
					else if (lowerNibble == 0x03) // ADD (A + MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "ADD", "mem", true, true);

						Accumulator = Execute.Add(Accumulator, Memory[operand]);
						ProcessorStats.memoryAddressing++;
					}
					else if (lowerNibble == 0x09) // SUB (A - X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "SUB X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
						
						Accumulator = Execute.Sub(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // SUB (A - IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "SUB", "imm", true, false);
						ProcessorStats.immediateAddressing++;
						
						Accumulator = Execute.Sub(Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // SUB (A - MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "SUB", "mem", true, true);

						Accumulator = Execute.Sub(Accumulator, Memory[operand]);

						ProcessorStats.memoryAddressing++;
					}

					ProcessorStats.nonUnaryInstructions++;
					ProcessorStats.arithmeticInstructions++;

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
						ConstructInstructionRep(ProgramCounter, byteToDecode, "AND X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;

						Accumulator = Execute.AND_OP(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // AND (A & IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "AND", "imm", true, false);
						ProcessorStats.immediateAddressing++;

						Accumulator = Execute.AND_OP(Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // AND (A & MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "AND", "mem", true, true);

						Accumulator = Execute.AND_OP(Accumulator, Memory[operand]);
						ProcessorStats.memoryAddressing++;
					}
					else if (lowerNibble == 0x09) // OR (A | X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "OR X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;

						Accumulator = Execute.OR_OP(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // OR (A | IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "OR", "imm", true, false);
						ProcessorStats.immediateAddressing++;

						Accumulator = Execute.OR_OP(Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // OR (A | MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "OR", "mem", true, true);

						Accumulator = Execute.OR_OP(Accumulator, Memory[operand]);
						ProcessorStats.memoryAddressing++;

					}
					ProcessorStats.nonUnaryInstructions++;
					ProcessorStats.arithmeticInstructions++;
					ProcessorStats.logicInstructions++;

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
						ConstructInstructionRep(ProgramCounter, byteToDecode, "XOR X", " ", false, false);
						Accumulator = Execute.XOR_OP (Accumulator, X_Register);
						ProcessorStats.xRegisterAddressing++;
						Accumulator = Execute.XOR_OP(Accumulator, X_Register);
						ProcessorStats.arithmeticInstructions++;
						ProcessorStats.logicInstructions++;


					}
					else if (lowerNibble == 0x02) // XOR (A ^ IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "XOR", "imm", true, false);
						Accumulator = Execute.XOR_OP (Accumulator, operand);
						ProcessorStats.immediateAddressing++;
						Accumulator = Execute.XOR_OP(Accumulator, operand);
						ProcessorStats.arithmeticInstructions++;
						ProcessorStats.logicInstructions++;
					}
					else if (lowerNibble == 0x03) // XOR (A ^ MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "XOR", "mem", true, true);

						Accumulator = Execute.XOR_OP(Accumulator, Memory[operand]);
						ProcessorStats.arithmeticInstructions++;
						ProcessorStats.logicInstructions++;
						ProcessorStats.memoryAddressing++;

					}
					else if (lowerNibble == 0x09) // LDA (X -> A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "LDA X", " ", false, false);

						Accumulator = Execute.LDA (X_Register);
						ProcessorStats.accumulatorAddressing++;
					}
					else if (lowerNibble == 0x0A) // LDA (IMM -> A)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDA", "imm", true, false);

						Accumulator = Execute.LDA(operand);
						ProcessorStats.accumulatorAddressing++;
					}
					else if (lowerNibble == 0x0B) // LDA (MEM -> A)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDA", "mem", true, true);

						Accumulator = Execute.LDA(Memory[operand]);
						ProcessorStats.accumulatorAddressing++;
						ProcessorStats.memoryAddressing++;
					}
					
					ProcessorStats.nonUnaryInstructions++;
					
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
						ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX A", " ", false, false);
						ProcessorStats.xRegisterAddressing++;

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
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX", "imm", true, false);
						ProcessorStats.xRegisterAddressing++;

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
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX", "mem", true, true);
						ProcessorStats.xRegisterAddressing++;
						X_Register = Execute.LDX(Memory[operand]);
						ProcessorStats.memoryAddressing++;

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
						ConstructInstructionRep(ProgramCounter, byteToDecode, "STA X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;

						X_Register = Execute.STA(Accumulator);
					}
					else if (lowerNibble == 0x0B) // STA (A -> MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "STA", "mem", true, true);

						//Memory[operand] = Execute.STA(Accumulator);
						ProcessorStats.memoryAddressing++;

					}
					ProcessorStats.nonUnaryInstructions++; 
					break;
				#endregion
				#region STX or BRT Instruction
				case 0x04: // STX or BRT Instruction
					if (lowerNibble == 0x00) // STX (X -> A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "STX A", " ", false, false);
						ProcessorStats.nonUnaryInstructions++;
						ProcessorStats.accumulatorAddressing++;
					}
					else if (lowerNibble == 0x03) // STX (X -> MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "STX", "mem", true, true);
						ProcessorStats.nonUnaryInstructions++;
						ProcessorStats.memoryAddressing++;

					}
					else if (lowerNibble == 0x0B) // BRT (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "BRT", "mem", true, true);

						if (TrueFlag)
                        {
							ProgramCounter = operand;
						}

						ProcessorStats.unaryInstructions++;
						ProcessorStats.controlInstructions++;
						ProcessorStats.memoryAddressing++;
					}

					break;
				#endregion
				#region BRNT or CPE Instruction
				case 0x05: // BRNT or CPE Instruction
					if (lowerNibble == 0x03) // BRNT (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "BRNT", "mem", true, true);

						if (!TrueFlag)
						{
							ProgramCounter = operand;
						}

						ProcessorStats.nonUnaryInstructions++;
						ProcessorStats.controlInstructions++;
						ProcessorStats.memoryAddressing++;

					}
					else if (lowerNibble == 0x09) // CPE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE X", " ", false, false);
						TrueFlag = Execute.CPE (Accumulator, X_Register);
						ProcessorStats.xRegisterAddressing++;
						ProcessorStats.nonUnaryInstructions++;
					}
					else if (lowerNibble == 0x0A) // CPE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE", "imm", true, false);
						TrueFlag = Execute.CPE (Accumulator, operand);
						ProcessorStats.nonUnaryInstructions++;
						ProcessorStats.immediateAddressing++;
					}
					else if (lowerNibble == 0x0B) // CPE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE", "mem", true, true);
						TrueFlag = Execute.CPE (Accumulator, operand);
						ProcessorStats.nonUnaryInstructions++;
						ProcessorStats.memoryAddressing++;
					}

					break;
				#endregion
				#region CPLT or CPLE Instruction
				case 0x06: // CPLT or CPLE Instruction
					if (lowerNibble == 0x01) // CPLT (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
						TrueFlag = Execute.CPLT (Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // CPLT (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT", "imm", true, false);
						ProcessorStats.immediateAddressing++;
						TrueFlag = Execute.CPLT (Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // CPLT (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT", "mem", true, true);
						ProcessorStats.memoryAddressing++;
						TrueFlag = Execute.CPLT (Accumulator, operand);

					}
					else if (lowerNibble == 0x09) // CPLE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
						TrueFlag = Execute.CPLE (Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // CPLE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE", "imm", true, false);
						ProcessorStats.immediateAddressing++;
						TrueFlag = Execute.CPLE (Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // CPLE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE", "mem", true, true);
						ProcessorStats.memoryAddressing++;
						TrueFlag = Execute.CPLE (Accumulator, operand);

					}
					ProcessorStats.nonUnaryInstructions++; 
					break;
				#endregion
				#region CPGT or CPGE Instruction
				case 0x07: // CPGT or CPGE Instruction
					if (lowerNibble == 0x01) // CPGT (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;

						TrueFlag = Execute.CPGT (Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // CPGT (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT", "imm", true, false);
						ProcessorStats.immediateAddressing++;

						TrueFlag = Execute.CPGT (Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // CPGT (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT", "mem", true, true);

						TrueFlag = Execute.CPGT (Accumulator, Memory[operand]);
						ProcessorStats.memoryAddressing++;

					}
					else if (lowerNibble == 0x09) // CPGE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
						TrueFlag = Execute.CPGE (Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // CPGE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE", "imm", true, false);
						ProcessorStats.immediateAddressing++;
						TrueFlag = Execute.CPGE (Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // CPGE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE", "mem", true, true);

						TrueFlag = Execute.CPGE (Accumulator, Memory[operand]);
						ProcessorStats.memoryAddressing++;

					}
					ProcessorStats.nonUnaryInstructions++;
					break;
				#endregion
				#region PUSH or POP Instruction
				case 0x08: // PUSH or POP Instruction
					if (lowerNibble == 0x00) // PUSH (A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH A", " ", false, false);

						ushort value = Accumulator;

						byte upperByte = (byte)(value >> 8);
						byte lowerByte = (byte)(value & 0b11111111);

						Memory[524288 + StackRegister] = upperNibble;
						StackRegister++;
						Memory[524288 + StackRegister] = lowerNibble;
						StackRegister++;

						ProcessorStats.accumulatorAddressing++;
					}
					else if (lowerNibble == 0x01) // PUSH (X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
						ushort value = X_Register;

						byte upperByte = (byte)(value >> 8);
						byte lowerByte = (byte)(value & 0b11111111);

						Memory[524288 + StackRegister] = upperByte;
						StackRegister++;
						Memory[524288 + StackRegister] = lowerByte;
						StackRegister++;
					}
					else if (lowerNibble == 0x02) // PUSH (IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH", "imm", true, false);

						byte upperByte = (byte)(operand >> 8);
						byte lowerByte = (byte)(operand & 0b11111111);

						ProcessorStats.immediateAddressing++;

						Memory[524288 + StackRegister] = upperByte;
						StackRegister++;
						Memory[524288 + StackRegister] = lowerByte;
						StackRegister++;
					}
					else if (lowerNibble == 0x03) // PUSH (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "PUSH", "mem", true, true);

						byte upperByte = (byte)(operand >> 8);
						byte lowerByte = (byte)(operand & 0b11111111);

						Memory[524288 + StackRegister] = upperByte;
						StackRegister++;
						Memory[524288 + StackRegister] = lowerByte;
						StackRegister++;

						ProcessorStats.memoryAddressing++;

					}
					else if (lowerNibble == 0x08) // POP (A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "POP", " ", false, false);

						Accumulator = Memory[524288 + StackRegister];

						Accumulator <<= 8;
						StackRegister--;
						Accumulator += Memory[524288 + StackRegister];
						Accumulator = (ushort)((Accumulator << 8) | (Accumulator >> (16 - 8)));
						StackRegister--;
						ProcessorStats.accumulatorAddressing++;

					}
					ProcessorStats.unaryInstructions++;
					break;
				#endregion
				#region NEG or NOT Instruction
				case 0x09: // NEG or NOT Instruction
					if (lowerNibble == 0x00) // NEG (A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NEG A", " ", false, false);

						Accumulator = Execute.NEG(Accumulator);
						ProcessorStats.accumulatorAddressing++;

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
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NEG X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
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
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NOT A", " ", false, false);

						Accumulator = Execute.NOT(Accumulator);
						ProcessorStats.accumulatorAddressing++;

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
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NOT X", " ", false, false);
						ProcessorStats.xRegisterAddressing++;
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
					ProcessorStats.unaryInstructions++;
					break;
				#endregion
				#region UBR Instruction
				case 0x0A: // UBR Instruction
					if (lowerNibble == 0x03) // UBR (MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "UBR", "mem", true, true);

						ProgramCounter = operand;
					}
					ProcessorStats.controlInstructions++;
					ProcessorStats.unaryInstructions++;
					break;
				#endregion
				#region YD Instruction
				case 0x0F: // YD Instruction
					if (lowerNibble == 0x0F) // YD (None)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "YD", " ", false, false);
						ProcessorStats.noAddresssing++;
						IsStopped = 1;
						ProcessorStats.unaryInstructions++;
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

			ProcessorStats.totalInstructions++;

			return InstructionRep;
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

		public uint FetchMemoryOperand()
		{
			ProgramCounter++; // Increment the program counter

			uint operand = (uint)(Memory[ProgramCounter]); // Load in the first byte of the 16-bit operand

			operand <<= 8; // Perform a left shift 8 times to move the first byte to the upper bits of the operand

			ProgramCounter++; // Increment the program counter

			operand += (uint)(Memory[ProgramCounter]); // Load in the second byte of the 16-bit operand to the lower bits of the operand

			operand <<= 8; // Perform a left shift 8 times to move the first byte to the upper bits of the operand

			ProgramCounter++; // Increment the program counter

			operand += (uint)(Memory[ProgramCounter]); // Load in the second byte of the 16-bit operand to the lower bits of the operand

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
		public uint ConstructInstructionRep(uint currentPC, byte instructionOpcode, string instructionName, string addressingName, bool hasOperand, bool isMemoryAddress)
		{
			uint operand;
			string tempInstructionRep;

			tempInstructionRep = currentPC.ToString() + " " + instructionOpcode.ToString() + " " + instructionName + " ";

			if (hasOperand)
			{
				if (isMemoryAddress)
				{
					operand = FetchMemoryOperand();

					tempInstructionRep += operand.ToString() + ", " + addressingName;

					InstructionRep = tempInstructionRep;

					return operand;
				}
				else
				{
					operand = FetchOperand();

					tempInstructionRep += operand.ToString() + ", " + addressingName;

					InstructionRep = tempInstructionRep;

					return operand;
				}
			}
			else
			{
				InstructionRep = tempInstructionRep;
				ProgramCounter++;
				return 0;
			}
		}
	}
}