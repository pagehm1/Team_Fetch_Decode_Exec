using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Instruction_Fetch_Decode_Execute
{
    /// <summary>
    /// Class that hold and keeps track of simulations statistics
    /// 
    /// </summary>
    public class Statistics
    {
        Form1 form;
        /// <summary>
        /// The total count of instructions in the simulation.
        /// </summary>
        public int totalInstructions { get; set; }

        /// <summary>
        /// The total count of unary instructions in the simulation.
        /// </summary>
        public int unaryInstructions { get; set; }

        /// <summary>
        /// The total count of unary instructions in the simulation. 
        /// </summary>
        public int nonUnaryInstructions { get; set; }

        /// <summary>
        /// The total count of non-unary instructions in the simulation.
        /// </summary>
        public int controlInstructions { get; set; }

        /// <summary>
        /// The total count of arithmetic instructions in the simulation. 
        /// </summary>
        public int arithmeticInstructions { get; set; }

        /// <summary>
        /// The total count of arithmetic addressing in the simulation    
        /// </summary>
        public int logicInstructions { get; set; }

        /// <summary>
        /// The total count of immediate addressing in the simulation
        /// </summary>
        public int immediateAddressing { get; set; }

        /// <summary>
        /// The total count of accumulator addressing in the simulation
        /// </summary>
        public int accumulatorAddressing { get; set; }

        /// <summary>
        /// The total count of x-register addressing in the simulation
        /// </summary>
        public int xRegisterAddressing { get; set; }

        /// <summary>
        /// The total 
        /// </summary>
        public int memoryAddressing { get; set; }

        public int noAddresssing { get; set; }

        public Statistics(Form1 form)
        {
            totalInstructions = 0;
            unaryInstructions = 0;
            nonUnaryInstructions = 0;
            controlInstructions = 0;
            arithmeticInstructions = 0;
            logicInstructions = 0;
            immediateAddressing = 0;
            accumulatorAddressing = 0;
            xRegisterAddressing = 0;
            memoryAddressing = 0;
            noAddresssing = 0;
            this.form = form;
        }

        public void formatStats()
        {
            string[] statistics = { "Total Instructions: " + totalInstructions, "Unary Instructions: " + unaryInstructions, "Non-Unary Instructions: " + nonUnaryInstructions,
                "Control Instructions: " + controlInstructions, "Arithmetic Instructions: " + arithmeticInstructions, "Logicial Instructions: " + logicInstructions };

            string[] addressing = {  "Immediate Adressing: " + immediateAddressing, "Accumulator Addressing: " + accumulatorAddressing, "X-Register Addressing: " + xRegisterAddressing ,
                "Memory Addressing: " + memoryAddressing, "No Addressing: " + noAddresssing  };

            form.populateStats(statistics);
            form.populateAddress(addressing);
        }
    }
    
}