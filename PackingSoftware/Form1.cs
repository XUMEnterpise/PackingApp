using System.Data;


namespace PackingSoftware
{
    public partial class Form1 : Form
    {
        DBManager dbManager = new DBManager();
        private Item Prebuild;
        private Item Order;
        private int lastHour;
        
        // Modern UI colors
        private readonly Color primaryColor = Color.FromArgb(0, 150, 255);
        private readonly Color successColor = Color.FromArgb(0, 255, 150);
        private readonly Color errorColor = Color.FromArgb(255, 100, 100);
        private readonly Color warningColor = Color.FromArgb(255, 193, 7);
        
        public Form1()
        {
            InitializeComponent();
            
            // Configure DataGridView for modern look
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            
            // Initialize statistics
            hourQTY.Text = dbManager.ReturnPackedThisHour();
            PackedTodayCountLabel.Text = dbManager.ReturnPackedToday();
            dataGridView1.DataSource = dbManager.ReturnOrdersLeftToPack();
            
            // Initialize orders left count
            ordersLeftValue.Text = dbManager.ReturnOrdersLeftToPackCount();
            
            // Setup timer for clock and hourly updates
            lastHour = DateTime.Now.Hour;
            System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer()
            {
                Interval = 1000   // milliseconds
            };
            myTimer.Tick += Tmr_Tick;
            myTimer.Start();
            
            // Set focus to first input
            orderNumberTextBox.Focus();
            
            // Add modern styling
            ApplyModernStyling();
        }
        
        private void ApplyModernStyling()
        {
            // Add subtle animations and modern effects
            foreach (TextBox textBox in new[] { orderNumberTextBox, secondTextBox, staffTextBox })
            {
                textBox.Enter += (s, e) => {
                    textBox.BackColor = Color.FromArgb(80, 80, 80);
                    textBox.BorderStyle = BorderStyle.Fixed3D;
                };
                
                textBox.Leave += (s, e) => {
                    textBox.BackColor = Color.FromArgb(60, 60, 60);
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                };
            }
        }

        private int refreshCounter = 0;
        
        private void Tmr_Tick(object? sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            ClockLabel.Text = now.ToString("F");

            // Check if the hour has changed
            if (now.Hour != lastHour)
            {
                // Hour has changed
                OnHourChanged();
                lastHour = now.Hour; // Update the lastHour to the current hour
            }
            
            // Refresh orders list every 30 seconds (timer runs every 1 second)
            refreshCounter++;
            if (refreshCounter >= 30)
            {
                RefreshOrdersList();
                refreshCounter = 0;
            }
        }
        
        private void RefreshOrdersList()
        {
            dataGridView1.DataSource = dbManager.ReturnOrdersLeftToPack();
            ordersLeftValue.Text = dbManager.ReturnOrdersLeftToPackCount();
        }

        private void OnHourChanged()
        {
            hourQTY.Text = dbManager.ReturnPackedThisHour();
        }

        private bool checkIfExists(string itemToLook, string table, string column)
        {
            bool exists = false;
            DataTable dt = dbManager.SelectSpecific(table,column,itemToLook);

            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item[column]);
                if (item[column].ToString().Trim(' ').Contains(itemToLook))
                {
                    exists = true;
                }
            }
            return exists;
        }

        private async void orderNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string orderNumber = orderNumberTextBox.Text.ToUpper();
                if (CheckOrderNumber(orderNumber))
                {
                    Item temp = dbManager.ReturnItem(orderNumber);
                    if (temp != null)
                    {
                        if (temp.type == ItemType.PC_Prebuild || temp.type == ItemType.Laptop_Prebuild)
                        {
                            Prebuild = temp;
                            label2.Visible = true;
                            secondTextBox.Visible = true;
                            secondTextBox.Focus();
                            
                            // Visual feedback for prebuild
                            ShowSuccessFeedback("Prebuild detected - Scan order number");
                        }
                        else
                        {
                            Order = temp;
                            staffTextBox.Visible = true;
                            staffTextBox.Focus();
                            label3.Visible = true;
                            
                            // Visual feedback for order
                            ShowSuccessFeedback("Order detected - Enter staff code");
                        }
                    }
                }
                else
                {
                    ShowErrorAsync(label1);
                }
            }
        }
        
        private void ShowSuccessFeedback(string message)
        {
            // Create a temporary success message
            var successLabel = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = successColor,
                BackColor = Color.FromArgb(45, 45, 45),
                AutoSize = true,
                Location = new Point(inputPanel.Location.X, inputPanel.Location.Y - 30)
            };
            
            this.Controls.Add(successLabel);
            
            // Remove after 3 seconds
            var timer = new System.Windows.Forms.Timer { Interval = 3000 };
            timer.Tick += (s, e) => {
                this.Controls.Remove(successLabel);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
        
        private async void ShowErrorAsync(Label label)
        {
            // Save the original color of the label
            var originalColor = label.ForeColor;

            // Change the label color to red for modern UI
            label.ForeColor = errorColor;

            // Wait for 5 seconds
            await Task.Delay(5000);

            // Revert the label color to its original color
            label.ForeColor = originalColor;
        }

        private async void OnEnterSecondTextBox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string orderNumber = secondTextBox.Text.ToUpper();
                if (CheckOrderNumber(orderNumber))
                {
                    Order = dbManager.ReturnItem(orderNumber);

                    if (Order.OrderId == Prebuild.OrderId)
                    {
                        staffTextBox.Focus();
                        ShowSuccessFeedback("Same order - Enter staff code");
                    }
                    else
                    {
                        if (Order != null)
                        {
                            dbManager.InsertQuerry($"UPDATE History SET AssignedNumber='{Prebuild.OrderId}' where OrderId='{Order.OrderId}'");
                            bool correct = await Order.Compare(Prebuild);
                            if (correct) {
                                orderNumber = secondTextBox.Text;
                                staffTextBox.Focus();
                                ShowSuccessFeedback("Specifications match - Enter staff code");
                            }
                            else
                            {
                                ShowErrorAsync(label2);
                            }
                        }
                    }
                }
                else
                {
                    ShowErrorAsync(label2);
                }
            }
        }

        public bool CheckOrderNumber(string orderNumber)
        {
            bool exists;

            if (orderNumber.StartsWith("P"))
            {
                // Check with "P" removed
                string modifiedOrderNumber = orderNumber.Replace("P", "");
                exists = checkIfExists(modifiedOrderNumber, "History", "Orderid");

                // If it does not exist, check with the original order number
                if (!exists)
                {
                    exists = checkIfExists(orderNumber, "History", "Orderid");
                }
            }
            else
            {
                // Directly check the order number
                exists = checkIfExists(orderNumber, "History", "Orderid");
            }

            return exists;
        }
        
        private void OnEnterStaff(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkIfExists(staffTextBox.Text, "StaffTable", "StaffNumber"))
                {
                    DateTime currentTime = System.DateTime.Now;
                    string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
                    string staffName = dbManager.SelectSpecific("StaffTable", "StaffNumber", staffTextBox.Text).Rows[^1].ItemArray[1].ToString();
                    
                    dbManager.InsertQuerry($"UPDATE History SET PackedBy='{staffName}', PackedDate='{formattedTime}' where Orderid='{Order.OrderId}'");
                    if (Prebuild != null)
                    {
                        if (checkIfExists(Prebuild.OrderId, "ManifestTable", "Prebuild"))
                        {
                            dbManager.InsertQuerry($"UPDATE ManifestTable SET OrderNumber='{Order.OrderId}', OrderSKU='{Order.Sku}',PackedDate='{formattedTime}' where Prebuild='{Prebuild.OrderId}'");
                        }
                        else
                        {
                            dbManager.InsertQuerry($"INSERT INTO ManifestTable (Prebuild,PrebuildSKU,OrderNumber,OrderSKU) " +
                                $"VALUES ('{Prebuild.OrderId}','{Prebuild.Sku}','{Order.OrderId}','{Order.Sku}')");
                        }
                    }
                    

                    // Update UI
                    dataGridView1.DataSource = dbManager.ReturnOrdersLeftToPack();
                    hourQTY.Text = dbManager.ReturnPackedThisHour();
                    PackedTodayCountLabel.Text = dbManager.ReturnPackedToday();
                    ordersLeftValue.Text = dbManager.ReturnOrdersLeftToPackCount();
                    
                    // Show completion feedback
                    ShowSuccessFeedback($"Item packed successfully by {staffName}");
                    
                    reset();
                }
                else
                {
                    ShowErrorAsync(label3);
                }
            }
        }
        
        private void reset()
        {
            label2.Visible = false;
            secondTextBox.Visible = false;
            secondTextBox.Text = "";
            orderNumberTextBox.Text = "";
            staffTextBox.Text = "";
            orderNumberTextBox.Focus();
        }
    }
}
