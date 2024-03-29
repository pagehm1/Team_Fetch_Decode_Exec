﻿
namespace Team_Instruction_Fetch_Decode_Execute
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BinaryTextBox = new System.Windows.Forms.TextBox();
            this.outputListBox = new System.Windows.Forms.ListBox();
            this.statisticsTextBox = new System.Windows.Forms.ListBox();
            this.addressingListBox = new System.Windows.Forms.ListBox();
            this.tbTruthFlag = new System.Windows.Forms.TextBox();
            this.tbZeroFlag = new System.Windows.Forms.TextBox();
            this.tbCarryFlag = new System.Windows.Forms.TextBox();
            this.tbNegFlag = new System.Windows.Forms.TextBox();
            this.tbProgramCounter = new System.Windows.Forms.TextBox();
            this.tbStack = new System.Windows.Forms.TextBox();
            this.tbXRegister = new System.Windows.Forms.TextBox();
            this.tbAccumulator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.binaryInputLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.statisticsLabel = new System.Windows.Forms.Label();
            this.addressingLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Decoding_Button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // BinaryTextBox
            // 
            this.BinaryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BinaryTextBox.Location = new System.Drawing.Point(16, 320);
            this.BinaryTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.BinaryTextBox.Multiline = true;
            this.BinaryTextBox.Name = "BinaryTextBox";
            this.BinaryTextBox.Size = new System.Drawing.Size(259, 274);
            this.BinaryTextBox.TabIndex = 2;
            // 
            // outputListBox
            // 
            this.outputListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.ItemHeight = 18;
            this.outputListBox.Location = new System.Drawing.Point(301, 320);
            this.outputListBox.Margin = new System.Windows.Forms.Padding(4);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(259, 274);
            this.outputListBox.TabIndex = 3;
            // 
            // statisticsTextBox
            // 
            this.statisticsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsTextBox.FormattingEnabled = true;
            this.statisticsTextBox.ItemHeight = 18;
            this.statisticsTextBox.Location = new System.Drawing.Point(587, 320);
            this.statisticsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.statisticsTextBox.Name = "statisticsTextBox";
            this.statisticsTextBox.Size = new System.Drawing.Size(259, 346);
            this.statisticsTextBox.TabIndex = 4;
            // 
            // addressingListBox
            // 
            this.addressingListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressingListBox.FormattingEnabled = true;
            this.addressingListBox.ItemHeight = 18;
            this.addressingListBox.Location = new System.Drawing.Point(879, 320);
            this.addressingListBox.Margin = new System.Windows.Forms.Padding(4);
            this.addressingListBox.Name = "addressingListBox";
            this.addressingListBox.Size = new System.Drawing.Size(259, 346);
            this.addressingListBox.TabIndex = 5;
            // 
            // tbTruthFlag
            // 
            this.tbTruthFlag.Location = new System.Drawing.Point(559, 223);
            this.tbTruthFlag.Margin = new System.Windows.Forms.Padding(4);
            this.tbTruthFlag.Name = "tbTruthFlag";
            this.tbTruthFlag.Size = new System.Drawing.Size(204, 22);
            this.tbTruthFlag.TabIndex = 6;
            // 
            // tbZeroFlag
            // 
            this.tbZeroFlag.Location = new System.Drawing.Point(559, 176);
            this.tbZeroFlag.Margin = new System.Windows.Forms.Padding(4);
            this.tbZeroFlag.Name = "tbZeroFlag";
            this.tbZeroFlag.Size = new System.Drawing.Size(204, 22);
            this.tbZeroFlag.TabIndex = 7;
            // 
            // tbCarryFlag
            // 
            this.tbCarryFlag.Location = new System.Drawing.Point(559, 129);
            this.tbCarryFlag.Margin = new System.Windows.Forms.Padding(4);
            this.tbCarryFlag.Name = "tbCarryFlag";
            this.tbCarryFlag.Size = new System.Drawing.Size(204, 22);
            this.tbCarryFlag.TabIndex = 8;
            // 
            // tbNegFlag
            // 
            this.tbNegFlag.Location = new System.Drawing.Point(559, 86);
            this.tbNegFlag.Margin = new System.Windows.Forms.Padding(4);
            this.tbNegFlag.Name = "tbNegFlag";
            this.tbNegFlag.Size = new System.Drawing.Size(204, 22);
            this.tbNegFlag.TabIndex = 9;
            // 
            // tbProgramCounter
            // 
            this.tbProgramCounter.Location = new System.Drawing.Point(143, 223);
            this.tbProgramCounter.Margin = new System.Windows.Forms.Padding(4);
            this.tbProgramCounter.Name = "tbProgramCounter";
            this.tbProgramCounter.Size = new System.Drawing.Size(235, 22);
            this.tbProgramCounter.TabIndex = 10;
            // 
            // tbStack
            // 
            this.tbStack.Location = new System.Drawing.Point(143, 176);
            this.tbStack.Margin = new System.Windows.Forms.Padding(4);
            this.tbStack.Name = "tbStack";
            this.tbStack.Size = new System.Drawing.Size(235, 22);
            this.tbStack.TabIndex = 11;
            // 
            // tbXRegister
            // 
            this.tbXRegister.Location = new System.Drawing.Point(143, 129);
            this.tbXRegister.Margin = new System.Windows.Forms.Padding(4);
            this.tbXRegister.Name = "tbXRegister";
            this.tbXRegister.Size = new System.Drawing.Size(235, 22);
            this.tbXRegister.TabIndex = 12;
            // 
            // tbAccumulator
            // 
            this.tbAccumulator.Location = new System.Drawing.Point(143, 86);
            this.tbAccumulator.Margin = new System.Windows.Forms.Padding(4);
            this.tbAccumulator.Name = "tbAccumulator";
            this.tbAccumulator.Size = new System.Drawing.Size(235, 22);
            this.tbAccumulator.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Registers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Accumulator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "X(Secondary)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Stack";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Program Counter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(487, 226);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Truth";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(491, 176);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Zero";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(488, 129);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Carry";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(463, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Negative";
            // 
            // binaryInputLabel
            // 
            this.binaryInputLabel.AutoSize = true;
            this.binaryInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binaryInputLabel.Location = new System.Drawing.Point(90, 296);
            this.binaryInputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.binaryInputLabel.Name = "binaryInputLabel";
            this.binaryInputLabel.Size = new System.Drawing.Size(98, 20);
            this.binaryInputLabel.TabIndex = 23;
            this.binaryInputLabel.Text = "Binary Input";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.Location = new System.Drawing.Point(396, 296);
            this.outputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(59, 20);
            this.outputLabel.TabIndex = 24;
            this.outputLabel.Text = "Output";
            // 
            // statisticsLabel
            // 
            this.statisticsLabel.AutoSize = true;
            this.statisticsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsLabel.Location = new System.Drawing.Point(631, 296);
            this.statisticsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statisticsLabel.Name = "statisticsLabel";
            this.statisticsLabel.Size = new System.Drawing.Size(155, 20);
            this.statisticsLabel.TabIndex = 25;
            this.statisticsLabel.Text = "Summary Statistics";
            // 
            // addressingLabel
            // 
            this.addressingLabel.AutoSize = true;
            this.addressingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressingLabel.Location = new System.Drawing.Point(913, 296);
            this.addressingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.addressingLabel.Name = "addressingLabel";
            this.addressingLabel.Size = new System.Drawing.Size(183, 20);
            this.addressingLabel.TabIndex = 26;
            this.addressingLabel.Text = "Adressing Modes Used";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(463, 49);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "Flags:";
            // 
            // Decoding_Button
            // 
            this.Decoding_Button.Location = new System.Drawing.Point(179, 618);
            this.Decoding_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Decoding_Button.Name = "Decoding_Button";
            this.Decoding_Button.Size = new System.Drawing.Size(200, 50);
            this.Decoding_Button.TabIndex = 28;
            this.Decoding_Button.Text = "Decode/Execute";
            this.Decoding_Button.UseVisualStyleBackColor = true;
            this.Decoding_Button.Click += new System.EventHandler(this.Decoding_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 692);
            this.Controls.Add(this.Decoding_Button);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.addressingLabel);
            this.Controls.Add(this.statisticsLabel);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.binaryInputLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAccumulator);
            this.Controls.Add(this.tbXRegister);
            this.Controls.Add(this.tbStack);
            this.Controls.Add(this.tbProgramCounter);
            this.Controls.Add(this.tbNegFlag);
            this.Controls.Add(this.tbCarryFlag);
            this.Controls.Add(this.tbZeroFlag);
            this.Controls.Add(this.tbTruthFlag);
            this.Controls.Add(this.addressingListBox);
            this.Controls.Add(this.statisticsTextBox);
            this.Controls.Add(this.outputListBox);
            this.Controls.Add(this.BinaryTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team 3 - Instruction Set Simulation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox BinaryTextBox;
        private System.Windows.Forms.ListBox outputListBox;
        private System.Windows.Forms.ListBox statisticsTextBox;
        private System.Windows.Forms.ListBox addressingListBox;
        private System.Windows.Forms.TextBox tbTruthFlag;
        private System.Windows.Forms.TextBox tbZeroFlag;
        private System.Windows.Forms.TextBox tbCarryFlag;
        private System.Windows.Forms.TextBox tbNegFlag;
        private System.Windows.Forms.TextBox tbProgramCounter;
        private System.Windows.Forms.TextBox tbStack;
        private System.Windows.Forms.TextBox tbXRegister;
        private System.Windows.Forms.TextBox tbAccumulator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label binaryInputLabel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label statisticsLabel;
        private System.Windows.Forms.Label addressingLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Button Decoding_Button;
    }
}

