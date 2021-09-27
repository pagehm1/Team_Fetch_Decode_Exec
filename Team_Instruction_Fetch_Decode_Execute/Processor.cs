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
                #region ADD or SUB Instruction
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
                #endregion
                #region AND or OR Instruction
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
                #endregion
                #region XOR or LDA Instruction
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
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA X";
                        Accumulator = Execute.LDA (X_Register);
                    }
                    else if (lowerNibble == 0x0A) // LDA (IMM -> A)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA " + operand.ToString() + ", imm";
                        Accumulator = Execute.LDA (operand);
                    }
                    else if (lowerNibble == 0x0B) // LDA (MEM -> A)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA " + operand.ToString() + ", mem";
                        Accumulator = Execute.LDA (Memory[operand]);
                    }

                    break;
                #endregion
                #region LDX or STA Instruction
                case 0x03: // LDX or STA Instruction
                    if (lowerNibble == 0x00) // LDX (A -> X)
                    {
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STA X";
                        X_Register = Execute.LDX (Accumulator);
                    }
                    else if (lowerNibble == 0x02) // LDX (IMM -> X)
                    {
                        operand = ConstructInstructionRep(ProgramCounter, byteToDecode, "LDA", "imm", true);

                        X_Register = Execute.LDX(operand);
                    }
                    else if (lowerNibble == 0x03) // LDX (MEM -> X)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " LDA " + operand.ToString() + ", mem";
                        X_Register = Execute.LDX (Memory[operand]);
                    }
                    else if (lowerNibble == 0x09) // STA (A -> X)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STA X, " + operand.ToString() + ", A";
                        X_Register = Execute.STA (Accumulator);
                    }
                    else if (lowerNibble == 0x0B) // STA (A -> MEM)
                    {
                        operand = FetchOperand();
                        InstructionRep = ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STA  mem" + operand.ToString() + ", A";
                        Memory[operand] = Execute.STA (Accumulator);
                    }

                    break;
                #endregion
                #region STX or BRT Instruction
                case 0x04: // STX or BRT Instruction
                    if (lowerNibble == 0x00) // STX (X -> A)
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STX A";
                    }
                    else if (lowerNibble == 0x03) // STX (X -> MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " STX " + operand.ToString() + ", mem";
                    }
                    else if (lowerNibble == 0x0B) // BRT (MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " BRT " + operand.ToString() + ", mem";
                    }

                    break;
                #endregion
                #region BRNT or CPE Instruction
                case 0x05: // BRNT or CPE Instruction
                    if (lowerNibble == 0x03) // BRNT (MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " BRNT " + operand.ToString() + ", mem";
                    }
                    else if (lowerNibble == 0x09) // CPE (A to X)
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPE X";
                    }
                    else if (lowerNibble == 0x0A) // CPE (A to IMM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPE " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x0B) // CPE (A to MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPE " + operand.ToString() + ", mem";
                    }

                    break;
                #endregion
                #region CPLT or CPLE Instruction
                case 0x06: // CPLT or CPLE Instruction
                    if (lowerNibble == 0x01) // CPLT (A to X)
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPLT X";
                    }
                    else if (lowerNibble == 0x02) // CPLT (A to IMM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPLT " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x03) // CPLT (A to MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPLT " + operand.ToString() + ", mem";
                    }
                    else if (lowerNibble == 0x09) // CPLE (A to X)
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPLE X";
                    }
                    else if (lowerNibble == 0x0A) // CPLE (A to IMM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPLE " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x0B) // CPLE (A to MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " CPLE " + operand.ToString() + ", mem";
                    }

                    break;
                #endregion
                #region CPGT or CPGE Instruction
                case 0x07: // CPGT or CPGE Instruction
                    if (lowerNibble == 0x01) // CPGT (A to X)
                    {
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + "CPGT X";
                        bool result = Execute.CPGT (Accumulator, X_Register);
                    }
                    else if (lowerNibble == 0x02) // CPGT (A to IMM)
                    {
                        operand = FetchOperand ( );
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGT " + operand.ToString ( ) + ", imm";
                        bool result = Execute.CPGT (Accumulator, operand);
                    }
                    else if (lowerNibble == 0x03) // CPGT (A to MEM)
                    {
                        operand = FetchOperand ( );
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGT " + operand.ToString ( ) + ", mem";
                        bool result = Execute.CPGT (Accumulator, Memory[operand]);
                    }
                    else if (lowerNibble == 0x09) // CPGE (A to X)
                    {
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGE X";
                        bool result = Execute.CPGE (Accumulator, X_Register);
                    }
                    else if (lowerNibble == 0x0A) // CPGE (A to IMM)
                    {
                        operand = FetchOperand ( );
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGE " + operand.ToString ( ) + ", imm";
                        bool result = Execute.CPGE (Accumulator, operand);
                    }
                    else if (lowerNibble == 0x0B) // CPGE (A to MEM)
                    {
                        operand = FetchOperand ( );
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " CPGE " + operand.ToString ( ) + ", mem";
                        bool result = Execute.CPGE (Accumulator, Memory[operand]);
                    }

                    break;
                #endregion
                #region PUSH or POP Instruction
                case 0x08: // PUSH or POP Instruction
                    if (lowerNibble == 0x00) // PUSH (A)
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " PUSH A";
                    }
                    else if (lowerNibble == 0x01) // PUSH (X)
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " PUSH X";
                    }
                    else if (lowerNibble == 0x02) // PUSH (IMM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " PUSH " + operand.ToString() + ", imm";
                    }
                    else if (lowerNibble == 0x03) // PUSH (MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " PUSH " + operand.ToString() + ", mem";
                    }
                    else if (lowerNibble == 0x08) // POP
                    {
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " POP";
                    }

                    break;
                #endregion
                #region NEG or NOT Instruction
                case 0x09: // NEG or NOT Instruction
                    if (lowerNibble == 0x00) // NEG(A)
					          {
						            InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NEG A";
                        Accumulator = Execute.NEG (Accumulator);
					          }
					          else if (lowerNibble == 0x01) // NEG(X)
                    {
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NEG X";
                        X_Register = Execute.NEG (X_Register);
                    }
                    else if (lowerNibble == 0x08) // NOT (A)
                    {
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NOT A";
                        Accumulator = Execute.NOT (Accumulator);
                    }
                    else if (lowerNibble == 0x09) // NOT (X)
                    {
                        InstructionRep = ProgramCounter.ToString ( ) + " " + byteToDecode.ToString ( ) + " NOT X";
                        X_Register = Execute.NOT (X_Register);
                    }

                    break;
                #endregion
                #region UBR Instruction
                case 0x0A: // UBR Instruction
                    if (lowerNibble == 0x03) // UBR (MEM)
                    {
                        operand = FetchOperand();
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " UBR " + operand.ToString() + ", mem";
                    }

                    break;
                #endregion
                #region YD Instruction
                case 0x0F: // YD Instruction
                    if (lowerNibble == 0x0F) // YD (None)
                    {
                        IsStopped = 1;
                        return ProgramCounter.ToString() + " " + byteToDecode.ToString() + " YD";
                    }

                    break;
                #endregion
                #region Default
                default:
                    break;
                #endregion
            }

            return " ";

            //Execute(instructionBits, addressBits);
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