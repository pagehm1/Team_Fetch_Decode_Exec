using System;
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
                    else if(lowerNibble == 0x0A) // SUB (A - IMM)
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
                case 0x01: // AND or OR Instruction
                    if (lowerNibble == 0x01) // AND (A & X)
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + "AND X";
                    }
                    else if (lowerNibble == 0x02) // AND (A & IMM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " AND  " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x03) // AND (A & MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " AND " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x09) // OR (A | X)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " OR  X";
                    }
                    else if (lowerNibble == 0x0A) // OR (A | IMM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " OR " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x0B) // OR (A | MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " OR " + operand.ToString() + ", mem";
                    }

                    break;
                case 0x02: // XOR or LDA Instruction
                    if (lowerNibble == 0x01) // XOR (A ^ X)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " XOR X";
                    }
                    else if (lowerNibble == 0x02) // XOR (A ^ IMM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " XOR " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x03) // XOR (A ^ MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " XOR " + operand.ToString() + ", mem";
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
        
        
        public void Execute(byte instructionBits, byte addressBits)
        {

            switch(instructionBits)
            {
                case 0x00:
                    if(addressBits == 0x01)
                    {

                    }

                    break;
                default:
                    break;
                       
            }

        }
        
    }
}
