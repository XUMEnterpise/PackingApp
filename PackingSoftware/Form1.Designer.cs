namespace PackingSoftware
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            orderNumberTextBox = new TextBox();
            secondTextBox = new TextBox();
            label2 = new Label();
            staffTextBox = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            label12 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            Instructions = new Label();
            label13 = new Label();
            hourQTY = new Label();
            PackedTodayCountLabel = new Label();
            label16 = new Label();
            ClockLabel = new Label();
            label19 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 22);
            label1.Name = "label1";
            label1.Size = new Size(179, 15);
            label1.TabIndex = 0;
            label1.Text = "Step 1 :Prebuild or order number";
            // 
            // orderNumberTextBox
            // 
            orderNumberTextBox.Location = new Point(18, 40);
            orderNumberTextBox.Name = "orderNumberTextBox";
            orderNumberTextBox.Size = new Size(179, 23);
            orderNumberTextBox.TabIndex = 1;
            orderNumberTextBox.KeyDown += orderNumberTextBox_KeyDown;
            // 
            // secondTextBox
            // 
            secondTextBox.Location = new Point(210, 40);
            secondTextBox.Name = "secondTextBox";
            secondTextBox.Size = new Size(192, 23);
            secondTextBox.TabIndex = 3;
            secondTextBox.Visible = false;
            secondTextBox.KeyDown += OnEnterSecondTextBox;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(210, 22);
            label2.Name = "label2";
            label2.Size = new Size(192, 15);
            label2.TabIndex = 2;
            label2.Text = "Step 2: Scan again or order number";
            label2.Visible = false;
            // 
            // staffTextBox
            // 
            staffTextBox.Location = new Point(18, 105);
            staffTextBox.Name = "staffTextBox";
            staffTextBox.Size = new Size(100, 23);
            staffTextBox.TabIndex = 5;
            staffTextBox.KeyDown += OnEnterStaff;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 87);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 4;
            label3.Text = "Step 3: Staff code";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(Instructions);
            panel1.Location = new Point(859, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(333, 338);
            panel1.TabIndex = 6;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(24, 233);
            label12.Name = "label12";
            label12.Size = new Size(203, 15);
            label12.TabIndex = 16;
            label12.Text = " otherwise it will just skip to next step";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 262);
            label8.Name = "label8";
            label8.Size = new Size(115, 15);
            label8.TabIndex = 15;
            label8.Text = "3. Scan staff number";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 209);
            label9.Name = "label9";
            label9.Size = new Size(228, 15);
            label9.TabIndex = 14;
            label9.Text = "2. If had prebuild scan order number next ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 179);
            label10.Name = "label10";
            label10.Size = new Size(312, 15);
            label10.TabIndex = 13;
            label10.Text = "1. Scan prebuild number first, if don't have one scan order";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 144);
            label11.Name = "label11";
            label11.Size = new Size(123, 15);
            label11.TabIndex = 12;
            label11.Text = "Instructions for orders";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 106);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 11;
            label7.Text = "3. Scan staff number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 74);
            label6.Name = "label6";
            label6.Size = new Size(141, 15);
            label6.TabIndex = 10;
            label6.Text = "2. Scan the number again";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 59);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 44);
            label4.Name = "label4";
            label4.Size = new Size(136, 15);
            label4.TabIndex = 8;
            label4.Text = "1. Scan prebuild number";
            // 
            // Instructions
            // 
            Instructions.AutoSize = true;
            Instructions.Location = new Point(14, 9);
            Instructions.Name = "Instructions";
            Instructions.Size = new Size(134, 15);
            Instructions.TabIndex = 7;
            Instructions.Text = "Instructions for prebuild";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 15F);
            label13.Location = new Point(859, 392);
            label13.Name = "label13";
            label13.Size = new Size(159, 28);
            label13.TabIndex = 17;
            label13.Text = "Packed this hour:";
            // 
            // hourQTY
            // 
            hourQTY.AutoSize = true;
            hourQTY.Font = new Font("Segoe UI", 15F);
            hourQTY.Location = new Point(859, 430);
            hourQTY.Name = "hourQTY";
            hourQTY.Size = new Size(48, 28);
            hourQTY.TabIndex = 18;
            hourQTY.Text = "N/A";
            // 
            // PackedTodayCountLabel
            // 
            PackedTodayCountLabel.AutoSize = true;
            PackedTodayCountLabel.Font = new Font("Segoe UI", 15F);
            PackedTodayCountLabel.Location = new Point(859, 517);
            PackedTodayCountLabel.Name = "PackedTodayCountLabel";
            PackedTodayCountLabel.Size = new Size(48, 28);
            PackedTodayCountLabel.TabIndex = 20;
            PackedTodayCountLabel.Text = "N/A";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 15F);
            label16.Location = new Point(859, 479);
            label16.Name = "label16";
            label16.Size = new Size(138, 28);
            label16.TabIndex = 19;
            label16.Text = "Packed today: ";
            // 
            // ClockLabel
            // 
            ClockLabel.AutoSize = true;
            ClockLabel.Font = new Font("Segoe UI", 15F);
            ClockLabel.Location = new Point(859, 364);
            ClockLabel.Name = "ClockLabel";
            ClockLabel.Size = new Size(80, 28);
            ClockLabel.TabIndex = 22;
            ClockLabel.Text = "HH:MM";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 15F);
            label19.Location = new Point(18, 165);
            label19.Name = "label19";
            label19.Size = new Size(129, 28);
            label19.TabIndex = 24;
            label19.Text = "Packed today";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 25;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Location = new Point(29, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(771, 311);
            dataGridView1.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 575);
            Controls.Add(dataGridView1);
            Controls.Add(label19);
            Controls.Add(ClockLabel);
            Controls.Add(PackedTodayCountLabel);
            Controls.Add(label16);
            Controls.Add(hourQTY);
            Controls.Add(label13);
            Controls.Add(panel1);
            Controls.Add(staffTextBox);
            Controls.Add(label3);
            Controls.Add(secondTextBox);
            Controls.Add(label2);
            Controls.Add(orderNumberTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Packing Software";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox orderNumberTextBox;
        private TextBox secondTextBox;
        private Label label2;
        private TextBox staffTextBox;
        private Label label3;
        private Panel panel1;
        private Label label4;
        private Label Instructions;
        private Label label12;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label13;
        private Label hourQTY;
        private Label PackedTodayCountLabel;
        private Label label16;
        private Label ClockLabel;
        private Label label19;
        private DataGridView dataGridView1;
    }
}
