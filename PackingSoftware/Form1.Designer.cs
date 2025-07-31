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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            titleLabel = new Label();
            clockLabel = new Label();
            mainPanel = new Panel();
            inputPanel = new Panel();
            step1Label = new Label();
            orderNumberTextBox = new TextBox();
            step2Label = new Label();
            secondTextBox = new TextBox();
            step3Label = new Label();
            staffTextBox = new TextBox();
            statsPanel = new Panel();
            statsTitleLabel = new Label();
            hourQtyLabel = new Label();
            hourQtyValue = new Label();
            todayLabel = new Label();
            todayValue = new Label();
            ordersLeftLabel = new Label();
            ordersLeftValue = new Label();
            instructionsPanel = new Panel();
            instructionsTitleLabel = new Label();
            prebuildInstructionsLabel = new Label();
            orderInstructionsLabel = new Label();
            gridPanel = new Panel();
            gridTitleLabel = new Label();
            dataGridView1 = new DataGridView();
            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            inputPanel.SuspendLayout();
            statsPanel.SuspendLayout();
            instructionsPanel.SuspendLayout();
            gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(45, 45, 45);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(clockLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(20);
            headerPanel.Size = new Size(1184, 80);
            headerPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(0, 150, 255);
            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(340, 45);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "PACKING SOFTWARE";
            // 
            // clockLabel
            // 
            clockLabel.AutoSize = true;
            clockLabel.Font = new Font("Segoe UI", 12F);
            clockLabel.ForeColor = Color.White;
            clockLabel.Location = new Point(200, 30);
            clockLabel.Name = "clockLabel";
            clockLabel.Size = new Size(163, 21);
            clockLabel.TabIndex = 1;
            clockLabel.Text = "31 July 2025 14:36:24";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(32, 32, 32);
            mainPanel.Controls.Add(inputPanel);
            mainPanel.Controls.Add(statsPanel);
            mainPanel.Controls.Add(instructionsPanel);
            mainPanel.Controls.Add(gridPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 80);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(1184, 654);
            mainPanel.TabIndex = 0;
            // 
            // inputPanel
            // 
            inputPanel.BackColor = Color.FromArgb(45, 45, 45);
            inputPanel.Controls.Add(step1Label);
            inputPanel.Controls.Add(orderNumberTextBox);
            inputPanel.Controls.Add(step2Label);
            inputPanel.Controls.Add(secondTextBox);
            inputPanel.Controls.Add(step3Label);
            inputPanel.Controls.Add(staffTextBox);
            inputPanel.Location = new Point(20, 20);
            inputPanel.Name = "inputPanel";
            inputPanel.Padding = new Padding(20);
            inputPanel.Size = new Size(400, 200);
            inputPanel.TabIndex = 0;
            // 
            // step1Label
            // 
            step1Label.AutoSize = true;
            step1Label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            step1Label.ForeColor = Color.FromArgb(0, 150, 255);
            step1Label.Location = new Point(20, 6);
            step1Label.Name = "step1Label";
            step1Label.Size = new Size(305, 19);
            step1Label.TabIndex = 0;
            step1Label.Text = "STEP 1: SCAN PREBUILD OR ORDER NUMBER";
            // 
            // orderNumberTextBox
            // 
            orderNumberTextBox.BackColor = Color.FromArgb(60, 60, 60);
            orderNumberTextBox.BorderStyle = BorderStyle.FixedSingle;
            orderNumberTextBox.Font = new Font("Segoe UI", 12F);
            orderNumberTextBox.ForeColor = Color.White;
            orderNumberTextBox.Location = new Point(20, 28);
            orderNumberTextBox.Name = "orderNumberTextBox";
            orderNumberTextBox.Size = new Size(360, 29);
            orderNumberTextBox.TabIndex = 1;
            orderNumberTextBox.KeyDown += orderNumberTextBox_KeyDown;
            // 
            // step2Label
            // 
            step2Label.AutoSize = true;
            step2Label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            step2Label.ForeColor = Color.FromArgb(0, 150, 255);
            step2Label.Location = new Point(20, 63);
            step2Label.Name = "step2Label";
            step2Label.Size = new Size(306, 19);
            step2Label.TabIndex = 2;
            step2Label.Text = "STEP 2: SCAN ORDER NUMBER (IF PREBUILD)";
            step2Label.Visible = false;
            // 
            // secondTextBox
            // 
            secondTextBox.BackColor = Color.FromArgb(60, 60, 60);
            secondTextBox.BorderStyle = BorderStyle.FixedSingle;
            secondTextBox.Font = new Font("Segoe UI", 12F);
            secondTextBox.ForeColor = Color.White;
            secondTextBox.Location = new Point(20, 85);
            secondTextBox.Name = "secondTextBox";
            secondTextBox.Size = new Size(360, 29);
            secondTextBox.TabIndex = 3;
            secondTextBox.Visible = false;
            secondTextBox.KeyDown += OnEnterSecondTextBox;
            // 
            // step3Label
            // 
            step3Label.AutoSize = true;
            step3Label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            step3Label.ForeColor = Color.FromArgb(0, 150, 255);
            step3Label.Location = new Point(20, 123);
            step3Label.Name = "step3Label";
            step3Label.Size = new Size(187, 19);
            step3Label.TabIndex = 4;
            step3Label.Text = "STEP 3: ENTER STAFF CODE";
            // 
            // staffTextBox
            // 
            staffTextBox.BackColor = Color.FromArgb(60, 60, 60);
            staffTextBox.BorderStyle = BorderStyle.FixedSingle;
            staffTextBox.Font = new Font("Segoe UI", 12F);
            staffTextBox.ForeColor = Color.White;
            staffTextBox.Location = new Point(20, 148);
            staffTextBox.Name = "staffTextBox";
            staffTextBox.Size = new Size(200, 29);
            staffTextBox.TabIndex = 5;
            staffTextBox.KeyDown += OnEnterStaff;
            // 
            // statsPanel
            // 
            statsPanel.BackColor = Color.FromArgb(45, 45, 45);
            statsPanel.Controls.Add(statsTitleLabel);
            statsPanel.Controls.Add(hourQtyLabel);
            statsPanel.Controls.Add(hourQtyValue);
            statsPanel.Controls.Add(todayLabel);
            statsPanel.Controls.Add(todayValue);
            statsPanel.Controls.Add(ordersLeftLabel);
            statsPanel.Controls.Add(ordersLeftValue);
            statsPanel.Location = new Point(440, 20);
            statsPanel.Name = "statsPanel";
            statsPanel.Padding = new Padding(20);
            statsPanel.Size = new Size(300, 200);
            statsPanel.TabIndex = 1;
            // 
            // statsTitleLabel
            // 
            statsTitleLabel.AutoSize = true;
            statsTitleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            statsTitleLabel.ForeColor = Color.FromArgb(0, 150, 255);
            statsTitleLabel.Location = new Point(20, 20);
            statsTitleLabel.Name = "statsTitleLabel";
            statsTitleLabel.Size = new Size(113, 25);
            statsTitleLabel.TabIndex = 0;
            statsTitleLabel.Text = "STATISTICS";
            // 
            // hourQtyLabel
            // 
            hourQtyLabel.AutoSize = true;
            hourQtyLabel.Font = new Font("Segoe UI", 12F);
            hourQtyLabel.ForeColor = Color.White;
            hourQtyLabel.Location = new Point(20, 60);
            hourQtyLabel.Name = "hourQtyLabel";
            hourQtyLabel.Size = new Size(132, 21);
            hourQtyLabel.TabIndex = 1;
            hourQtyLabel.Text = "Packed This Hour:";
            // 
            // hourQtyValue
            // 
            hourQtyValue.AutoSize = true;
            hourQtyValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            hourQtyValue.ForeColor = Color.FromArgb(0, 255, 150);
            hourQtyValue.Location = new Point(20, 85);
            hourQtyValue.Name = "hourQtyValue";
            hourQtyValue.Size = new Size(33, 37);
            hourQtyValue.TabIndex = 2;
            hourQtyValue.Text = "0";
            // 
            // todayLabel
            // 
            todayLabel.AutoSize = true;
            todayLabel.Font = new Font("Segoe UI", 12F);
            todayLabel.ForeColor = Color.White;
            todayLabel.Location = new Point(20, 120);
            todayLabel.Name = "todayLabel";
            todayLabel.Size = new Size(105, 21);
            todayLabel.TabIndex = 3;
            todayLabel.Text = "Packed Today:";
            // 
            // todayValue
            // 
            todayValue.AutoSize = true;
            todayValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            todayValue.ForeColor = Color.FromArgb(0, 255, 150);
            todayValue.Location = new Point(20, 145);
            todayValue.Name = "todayValue";
            todayValue.Size = new Size(33, 37);
            todayValue.TabIndex = 4;
            todayValue.Text = "0";
            // 
            // ordersLeftLabel
            // 
            ordersLeftLabel.AutoSize = true;
            ordersLeftLabel.Font = new Font("Segoe UI", 12F);
            ordersLeftLabel.ForeColor = Color.White;
            ordersLeftLabel.Location = new Point(168, 60);
            ordersLeftLabel.Name = "ordersLeftLabel";
            ordersLeftLabel.Size = new Size(91, 21);
            ordersLeftLabel.TabIndex = 5;
            ordersLeftLabel.Text = "Orders Left:";
            // 
            // ordersLeftValue
            // 
            ordersLeftValue.AutoSize = true;
            ordersLeftValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            ordersLeftValue.ForeColor = Color.FromArgb(255, 193, 7);
            ordersLeftValue.Location = new Point(168, 85);
            ordersLeftValue.Name = "ordersLeftValue";
            ordersLeftValue.Size = new Size(33, 37);
            ordersLeftValue.TabIndex = 6;
            ordersLeftValue.Text = "0";
            // 
            // instructionsPanel
            // 
            instructionsPanel.BackColor = Color.FromArgb(45, 45, 45);
            instructionsPanel.Controls.Add(instructionsTitleLabel);
            instructionsPanel.Controls.Add(prebuildInstructionsLabel);
            instructionsPanel.Controls.Add(orderInstructionsLabel);
            instructionsPanel.Location = new Point(760, 20);
            instructionsPanel.Name = "instructionsPanel";
            instructionsPanel.Padding = new Padding(20);
            instructionsPanel.Size = new Size(400, 200);
            instructionsPanel.TabIndex = 2;
            // 
            // instructionsTitleLabel
            // 
            instructionsTitleLabel.AutoSize = true;
            instructionsTitleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            instructionsTitleLabel.ForeColor = Color.FromArgb(0, 150, 255);
            instructionsTitleLabel.Location = new Point(20, 0);
            instructionsTitleLabel.Name = "instructionsTitleLabel";
            instructionsTitleLabel.Size = new Size(150, 25);
            instructionsTitleLabel.TabIndex = 0;
            instructionsTitleLabel.Text = "INSTRUCTIONS";
            // 
            // prebuildInstructionsLabel
            // 
            prebuildInstructionsLabel.AutoSize = true;
            prebuildInstructionsLabel.Font = new Font("Segoe UI", 10F);
            prebuildInstructionsLabel.ForeColor = Color.White;
            prebuildInstructionsLabel.Location = new Point(20, 28);
            prebuildInstructionsLabel.Name = "prebuildInstructionsLabel";
            prebuildInstructionsLabel.Size = new Size(158, 76);
            prebuildInstructionsLabel.TabIndex = 1;
            prebuildInstructionsLabel.Text = "PREBUILD PROCESS:\n1. Scan prebuild number\n2. Scan order number\n3. Enter staff code";
            // 
            // orderInstructionsLabel
            // 
            orderInstructionsLabel.AutoSize = true;
            orderInstructionsLabel.Font = new Font("Segoe UI", 10F);
            orderInstructionsLabel.ForeColor = Color.White;
            orderInstructionsLabel.Location = new Point(20, 110);
            orderInstructionsLabel.Name = "orderInstructionsLabel";
            orderInstructionsLabel.Size = new Size(141, 57);
            orderInstructionsLabel.TabIndex = 2;
            orderInstructionsLabel.Text = "ORDER PROCESS:\n1. Scan order number\n2. Enter staff code";
            // 
            // gridPanel
            // 
            gridPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPanel.BackColor = Color.FromArgb(45, 45, 45);
            gridPanel.Controls.Add(gridTitleLabel);
            gridPanel.Controls.Add(dataGridView1);
            gridPanel.Location = new Point(12, 241);
            gridPanel.Name = "gridPanel";
            gridPanel.Padding = new Padding(20);
            gridPanel.Size = new Size(1148, 400);
            gridPanel.TabIndex = 3;
            // 
            // gridTitleLabel
            // 
            gridTitleLabel.AutoSize = true;
            gridTitleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            gridTitleLabel.ForeColor = Color.FromArgb(0, 150, 255);
            gridTitleLabel.Location = new Point(20, 20);
            gridTitleLabel.Name = "gridTitleLabel";
            gridTitleLabel.Size = new Size(213, 25);
            gridTitleLabel.TabIndex = 0;
            gridTitleLabel.Text = "ORDERS LEFT TO PACK";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(60, 60, 60);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.FromArgb(80, 80, 80);
            dataGridView1.Location = new Point(20, 50);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1100, 330);
            dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1184, 734);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            MinimumSize = new Size(1000, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Packing Software - Modern Edition";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            statsPanel.ResumeLayout(false);
            statsPanel.PerformLayout();
            instructionsPanel.ResumeLayout(false);
            instructionsPanel.PerformLayout();
            gridPanel.ResumeLayout(false);
            gridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            
            // Map new modern components to original variable names for compatibility
            this.ClockLabel = clockLabel;
            this.hourQTY = hourQtyValue;
            this.PackedTodayCountLabel = todayValue;
            this.label1 = step1Label;
            this.label2 = step2Label;
            this.label3 = step3Label;
            this.label19 = gridTitleLabel;
            this.orderNumberTextBox = orderNumberTextBox;
            this.secondTextBox = secondTextBox;
            this.staffTextBox = staffTextBox;
            this.dataGridView1 = dataGridView1;
            
            ResumeLayout(false);
        }

        #endregion

        // Modern UI components
        private Panel headerPanel;
        private Label titleLabel;
        private Label clockLabel;
        private Panel mainPanel;
        private Panel inputPanel;
        private Label step1Label;
        private Label step2Label;
        private Label step3Label;
        private Panel statsPanel;
        private Label statsTitleLabel;
        private Label hourQtyLabel;
        private Label hourQtyValue;
        private Label todayLabel;
        private Label todayValue;
        private Label ordersLeftLabel;
        private Label ordersLeftValue;
        private Panel instructionsPanel;
        private Label instructionsTitleLabel;
        private Label prebuildInstructionsLabel;
        private Label orderInstructionsLabel;
        private Panel gridPanel;
        private Label gridTitleLabel;
        
        // Original components (for compatibility)
        private Label label1;
        private TextBox orderNumberTextBox;
        private TextBox secondTextBox;
        private Label label2;
        private TextBox staffTextBox;
        private Label label3;
        private Label label19;
        private DataGridView dataGridView1;
        private Label ClockLabel;
        private Label hourQTY;
        private Label PackedTodayCountLabel;
    }
}
