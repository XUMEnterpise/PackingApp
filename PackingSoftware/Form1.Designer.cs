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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 35);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Order Number";
            // 
            // orderNumberTextBox
            // 
            orderNumberTextBox.Location = new Point(59, 53);
            orderNumberTextBox.Name = "orderNumberTextBox";
            orderNumberTextBox.Size = new Size(100, 23);
            orderNumberTextBox.TabIndex = 1;
            orderNumberTextBox.KeyDown += orderNumberTextBox_KeyDown;
            // 
            // secondTextBox
            // 
            secondTextBox.Location = new Point(224, 53);
            secondTextBox.Name = "secondTextBox";
            secondTextBox.Size = new Size(100, 23);
            secondTextBox.TabIndex = 3;
            secondTextBox.Visible = false;
            secondTextBox.KeyDown += OnEnterSecondTextBox;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 35);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 2;
            label2.Text = "Order Number";
            label2.Visible = false;
            // 
            // staffTextBox
            // 
            staffTextBox.Location = new Point(59, 118);
            staffTextBox.Name = "staffTextBox";
            staffTextBox.Size = new Size(100, 23);
            staffTextBox.TabIndex = 5;
            staffTextBox.KeyDown += OnEnterStaff;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 100);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 4;
            label3.Text = "Staff Code";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 170);
            Controls.Add(staffTextBox);
            Controls.Add(label3);
            Controls.Add(secondTextBox);
            Controls.Add(label2);
            Controls.Add(orderNumberTextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Packing Software";
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
    }
}
