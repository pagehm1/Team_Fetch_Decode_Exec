<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{
    public class Processor
    {
        public byte[] Memory { get; set; }

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

        public int IsStopped { get; set; }

        public string InstructionRep { get; set; }

        public List<Object> updatedItems { get; set; }

        public Processor()
        {
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

        public void PopulateMemory(byte byteToInsert)
        {
            Memory[counter] = byteToInsert;
            counter++;
        }

        public void updateRegistersAndFlags()
        {

        }

        public string Decode(byte byteToDecode)
        {
            //string returnString = "";
            ushort operand;


            byte upperNibble = (byte)(byteToDecode >> 4);
            byte lowerNibble = (byte)(byteToDecode & 0b00001111);

            switch (upperNibble)
            {
                case 0x00: // ADD or SUB Instruction
                    if (lowerNibble == 0x01) // ADD (A + X)
                    {
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " ADD X";
                        Accumulator = Execute.Add(Accumulator, X_Register);
                    }
                    else if (lowerNibble == 0x02) // ADD (A + IMM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " ADD " + operand.ToString() + ", imm";
                        Accumulator = Execute.Add(Accumulator, operand);

                    }
                    else if (lowerNibble == 0x03) // ADD (A + MEM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " ADD " + operand.ToString() + ", mem";
                        Accumulator = Execute.Add(Accumulator, Memory[operand]);
                    }
                    else if (lowerNibble == 0x09) // SUB (A - X)
                    {
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " SUB X";
                        Accumulator = Execute.Sub(Accumulator, X_Register);
                    }
                    else if(lowerNibble == 0x0A) // SUB (A - IMM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " SUB " + operand.ToString() + ", imm";
                        Accumulator = Execute.Sub(Accumulator, operand);
                    }
                    else if (lowerNibble == 0x0B) // SUB (A - MEM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " SUB " + operand.ToString() + ", mem";
                        Accumulator = Execute.Sub(Accumulator, Memory[operand]);
                    }

                    break;
                case 0x01: // AND or OR Instruction
                    if (lowerNibble == 0x01) // AND (A & X)
                    {

                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + "AND X";
                        Accumulator = Execute.AND_OP(Accumulator, X_Register);
                    }
                    else if (lowerNibble == 0x02) // AND (A & IMM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " AND  " + operand.ToString() + ", imm";
                        Accumulator = Execute.AND_OP(Accumulator, operand);
                    }
                    else if (lowerNibble == 0x03) // AND (A & MEM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " AND " + operand.ToString() + ", imm";
                        Accumulator = Execute.AND_OP(Accumulator, Memory[operand]);
                    }
                    else if (lowerNibble == 0x09) // OR (A | X)
                    {
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " OR  X";
                        Accumulator = Execute.OR_OP(Accumulator, X_Register);
                    }
                    else if (lowerNibble == 0x0A) // OR (A | IMM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " OR " + operand.ToString() + ", imm";
                        Accumulator = Execute.OR_OP(Accumulator, operand);
                    }
                    else if (lowerNibble == 0x0B) // OR (A | MEM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " OR " + operand.ToString() + ", mem";
                        Accumulator = Execute.OR_OP(Accumulator, Memory[operand]);
                    }

                    break;
                case 0x02: // XOR or LDA Instruction
                    if (lowerNibble == 0x01) // XOR (A ^ X)
                    {
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " XOR X";
                        Accumulator = Execute.XOR_OP(Accumulator, X_Register);

                    }
                    else if (lowerNibble == 0x02) // XOR (A ^ IMM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " XOR " + operand.ToString() + ", imm";
                        Accumulator = Execute.XOR_OP(Accumulator, operand);
                    }
                    else if (lowerNibble == 0x03) // XOR (A ^ MEM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " XOR " + operand.ToString() + ", mem";
                        Accumulator = Execute.XOR_OP(Accumulator, Memory[operand]);
                    }
                    else if (lowerNibble == 0x09) // LDA (X -> A)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA X";
                    }
                    else if (lowerNibble == 0x0A) // LDA (IMM -> A)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x0B) // LDA (MEM -> A)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA " + operand.ToString() + ", mem";
                    }

                    break;
                case 0x03: // LDX or STA Instruction
                    if (lowerNibble == 0x00) // LDX (A -> X)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STA X";
                    }
                    else if (lowerNibble == 0x02) // LDX (IMM -> X)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x03) // LDX (MEM -> X)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA " + operand.ToString() + ", mem";
                    }
                    else if (lowerNibble == 0x09) // STA (A -> X)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STA X, " + operand.ToString() + ", A";
                    }
                    else if (lowerNibble == 0x0B) // STA (A -> MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STA  mem" + operand.ToString() + ", A";
                    }

                    break;
                case 0x04: // STX Instruction
                    if (lowerNibble == 0x00) // STX (X -> A)
                    {

                    }
                    else if (lowerNibble == 0x03) // STX (X -> MEM)
                    {

                    }

                    break;
                case 0x05: // BRNT, CPE, or BRT Instruction
                    if (lowerNibble == 0x07) // BRNT
                    {

                    }
                    else if (lowerNibble == 0x09) // CPE (A to X)
                    {

                    }
                    else if (lowerNibble == 0x0A) // CPE (A to IMM)
                    {

                    }
                    else if (lowerNibble == 0x0B) // CPE (A to MEM)
                    {

                    }
                    else if (lowerNibble == 0x0F) // BRT
                    {
                        
                    }

                    break;
                case 0x06: // CPLT or CPLE Instruction
                    if (lowerNibble == 0x01) // CPLT (A to X)
                    {

                    }
                    else if (lowerNibble == 0x02) // CPLT (A to IMM)
                    {

                    }
                    else if (lowerNibble == 0x03) // CPLT (A to MEM)
                    {

                    }
                    else if (lowerNibble == 0x09) // CPLE (A to X)
                    {

                    }
                    else if (lowerNibble == 0x0A) // CPLE (A to IMM)
                    {

                    }
                    else if (lowerNibble == 0x0B) // CPLE (A to MEM)
                    {

                    }

                    break;
                case 0x07: // CPGT or CPGE Instruction
                    if (lowerNibble == 0x01) // CPGT (A to X)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + "CPGT X";
                    }
                    else if (lowerNibble == 0x02) // CPGT(A to IMM)
                    {
                        operand = FetchOperand ( );
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGT " + operand.ToString ( ) + ", imm";
                    }
                    else if (lowerNibble == 0x03) // CPGT(A to MEM)
                    {
                        operand = FetchOperand ( );
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGT " + operand.ToString ( ) + ", mem";
                    }
                    else if (lowerNibble == 0x09) // CPGE(A to X)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGE X";
                    }
                    else if (lowerNibble == 0x0A) // CPGE(A to IMM)
                    {
                        operand = FetchOperand ( );
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGE " + operand.ToString ( ) + ", imm";
                    }
                    else if (lowerNibble == 0x0B) // CPGE (A to MEM)
                    {
                        operand = FetchOperand ( );
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGE " + operand.ToString ( ) + ", mem";
                    }

                    break;
                case 0x08: // PUSH or POP Instruction
                    if (lowerNibble == 0x00) // PUSH (A)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " PUSH A";
                    }
                    else if (lowerNibble == 0x01) // PUSH (X)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " PUSH X";
                    }
                    else if (lowerNibble == 0x02) // PUSH (IMM)
                    {
                        operand = FetchOperand ( );
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " PUSH " + operand.ToString ( ) + ", imm";
                    }
                    else if (lowerNibble == 0x03) // PUSH (MEM)
                    {
                        operand = FetchOperand ( );
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " PUSH " + operand.ToString ( ) + ", mem";
                    }
                    else if (lowerNibble == 0x08) // POP
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " POP";
                    }

                    break;
                case 0x09: // NEG or NOT Instruction
                    if (lowerNibble == 0x00) // NEG(A)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NEG A";
                    }
                    else if (lowerNibble == 0x01) // NEG(X)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NEG X";
                    }
                    else if (lowerNibble == 0x08) // NOT(A)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NOT A";
                    }
                    else if (lowerNibble == 0x09) // NOT(X)
                    {
                        return ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NOT X";
                    }

                    break;
                case 0x0F: // YD Instruction
                    if (lowerNibble == 0x0F) // YD
                    {
                        IsStopped = 1;
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " YD";
                    }

                    break;
                default:
                    break;
            }

            //Execute(instructionBits, addressBits);
        }

        /*
        public void incrementPC()
        {
            ProgramCounter++;
        }
        */

        public ushort FetchOperand() // FA 10 = 0000000011111010 -> Bitshift Right 8 -> 1111101000000000 + 10 -> ADD -> 1111101000010000 -> FA 10 as 16-bit
        {
            ushort operand = (ushort)((Memory[ProgramCounter] >> 8) + (Memory[ProgramCounter+0x1]));

            ProgramCounter+=2;

            return operand;
        }
        
        /*
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
+
                default:
                    break;
                       
            }

        */

        }
        
    }
}
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{
	public class Processor
	{
		#region Processor Properties
		public Form1 Form;

		public byte[] Memory { get; set; }

		public ushort Accumulator { get; set; }

		public ushort X_Register { get; set; }

		public ushort ProgramCounter { get; set; }

		public ushort StackRegister { get; set; }

		public bool NegativeFlag { get; set; }

		public bool CarryFlag { get; set; }

		public bool ZeroFlag { get; set; }

		public bool TrueFlag { get; set; }

		public int counter { get; set; }

		public int IsStopped { get; set; }

		public string InstructionRep { get; set; }

		public List<Object> updatedItems { get; set; }
		#endregion

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

		public void PopulateMemory(byte byteToInsert)
		{
			Memory[counter] = byteToInsert;
			counter++;
		}

		public void UpdateRegistersAndFlags()
		{
			 
		}

		public string Decode(byte byteToDecode)
		{
			//string returnString = "";
			ushort operand;

			byte upperNibble = (byte)(byteToDecode >> 4);
			byte lowerNibble = (byte)(byteToDecode & 0b00001111);

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

					break;
				#endregion
				#region LDX or STA Instruction
				case 0x03: // LDX or STA Instruction
					if (lowerNibble == 0x00) // LDX (A -> X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX A", " ", false);

						X_Register = Execute.LDX(Accumulator);
					}
					else if (lowerNibble == 0x02) // LDX (IMM -> X)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX", "imm", true);

						X_Register = Execute.LDX(operand);
					}
					else if (lowerNibble == 0x03) // LDX (MEM -> X)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDX", "mem", true);

						X_Register = Execute.LDX(Memory[operand]);
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
					}
					else if (lowerNibble == 0x0A) // CPE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE", "imm", true);
					}
					else if (lowerNibble == 0x0B) // CPE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPE", "mem", true);
					}

					break;
				#endregion
				#region CPLT or CPLE Instruction
				case 0x06: // CPLT or CPLE Instruction
					if (lowerNibble == 0x01) // CPLT (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT X", " ", false);
					}
					else if (lowerNibble == 0x02) // CPLT (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT", "imm", true);
					}
					else if (lowerNibble == 0x03) // CPLT (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLT", "mem", true);
					}
					else if (lowerNibble == 0x09) // CPLE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE X", " ", false);
					}
					else if (lowerNibble == 0x0A) // CPLE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE", "imm", true);
					}
					else if (lowerNibble == 0x0B) // CPLE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPLE", "mem", true);
					}

					break;
				#endregion
				#region CPGT or CPGE Instruction
				case 0x07: // CPGT or CPGE Instruction
					if (lowerNibble == 0x01) // CPGT (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT X", " ", false);

						bool result = Execute.CPGT(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x02) // CPGT (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT", "imm", true);

						bool result = Execute.CPGT(Accumulator, operand);
					}
					else if (lowerNibble == 0x03) // CPGT (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGT", "mem", true);

						bool result = Execute.CPGT(Accumulator, Memory[operand]);
					}
					else if (lowerNibble == 0x09) // CPGE (A to X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE X", " ", false);

						bool result = Execute.CPGE(Accumulator, X_Register);
					}
					else if (lowerNibble == 0x0A) // CPGE (A to IMM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE", "imm", true);

						bool result = Execute.CPGE(Accumulator, operand);
					}
					else if (lowerNibble == 0x0B) // CPGE (A to MEM)
					{
						operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "CPGE", "mem", true);

						bool result = Execute.CPGE(Accumulator, Memory[operand]);
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
					}
					else if (lowerNibble == 0x01) // NEG (X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NEG X", " ", false);

						X_Register = Execute.NEG(X_Register);
					}
					else if (lowerNibble == 0x08) // NOT (A)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NOT A", " ", false);

						Accumulator = Execute.NOT(Accumulator);
					}
					else if (lowerNibble == 0x09) // NOT (X)
					{
						ConstructInstructionRep(ProgramCounter, byteToDecode, "NOT X", " ", false);

						X_Register = Execute.NOT(X_Register);
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

			Form.UpdateRegisters();
			Form.UpdateFlags();
			
			return " ";
		}

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
>>>>>>> bb4bf3c795e5f70388ee6473aeb592bcce805232
