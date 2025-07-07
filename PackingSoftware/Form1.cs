using System.Data;


namespace PackingSoftware
{
    public partial class Form1 : Form
    {
        DBManager dbManager = new DBManager();
        private Item Prebuild;
        private Item Order;
        private int lastHour;
        public Form1()
        {
            
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            hourQTY.Text = dbManager.ReturnPackedThisHour();
            PackedTodayCountLabel.Text= dbManager.ReturnPackedToday();
            dataGridView1.DataSource = dbManager.ReturnPackedTodayManifest();
            lastHour = DateTime.Now.Hour;
            System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer()
            {
                Interval = 1000   // milliseconds
            };
            myTimer.Tick += Tmr_Tick;  // set handler
            myTimer.Start();
            orderNumberTextBox.Focus();
        }

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
                    Item temp=dbManager.ReturnItem(orderNumber);
                    if (temp != null)
                    {
                        if (temp.type == ItemType.PC_Prebuild || temp.type==ItemType.Laptop_Prebuild)
                        {
                            Prebuild = temp;
                            label2.Visible = true;
                            secondTextBox.Visible = true;
                            secondTextBox.Focus();
                        }
                        else
                        {
                            Order = temp;
                            staffTextBox.Visible = true;
                            staffTextBox.Focus();
                            label3.Visible = true;
                        }
                    }
                }
                else
                {
                    ShowErrorAsync(label1);
                }
            }
        }
        private async void ShowErrorAsync(Label label)
        {
            // Save the original color of the label
            var originalColor = label.ForeColor;

            // Change the label color to red
            label.ForeColor = System.Drawing.Color.Red;

            // Wait for 5 seconds
            await Task.Delay(5000);

            // Revert the label color to its original color
            label.ForeColor = originalColor;
        }

        private async void OnEnterSecondTextBox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                string orderNumber=secondTextBox.Text.ToUpper();
                if (CheckOrderNumber(orderNumber))
                {
                    Order = dbManager.ReturnItem(orderNumber);


                    if (Order.OrderId==Prebuild.OrderId)
                    {
                        staffTextBox.Focus();
                    }
                    else
                    {
                        if (Order != null)
                        {
                            //dbManager.InsertQuerry($"UPDATE History SET AssignedNumber='{Order.OrderId}' where OrderId='{Prebuild.OrderId}'");
                            dbManager.InsertQuerry($"UPDATE History SET AssignedNumber='{Prebuild.OrderId}' where OrderId='{Order.OrderId}'");
                            bool correct=await Order.Compare(Prebuild);
                            if (correct) {
                                orderNumber = secondTextBox.Text;
                                staffTextBox.Focus();
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
                exists = checkIfExists(modifiedOrderNumber, "History", "OrderID");

                // If it does not exist, check with the original order number
                if (!exists)
                {
                    exists = checkIfExists(orderNumber, "History", "OrderID");
                }
            }
            else
            {
                // Directly check the order number
                exists = checkIfExists(orderNumber, "History", "OrderID");
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
                    dbManager.InsertQuerry($"UPDATE History SET PackedBy='{staffName}', PackedDate='{formattedTime}' where OrderId='{Order.OrderId}'");
                    if (checkIfExists(Prebuild.OrderId, "ManifestTable", "Prebuild"))
                    {
                        dbManager.InsertQuerry($"UPDATE ManifestTable SET OrderNumber='{Order.OrderId}', OrderSKU='{Order.Sku}',PackedDate='{formattedTime}' where Prebuild='{Prebuild.OrderId}'");
                    }
                    else
                    {
                        dbManager.InsertQuerry($"INSERT INTO ManifestTable (Prebuild,PrebuildSKU,OrderNumber,OrderSKU) " +
                            $"VALUES ('{Prebuild.OrderId}','{Prebuild.Sku}','{Order.OrderId}','{Order.Sku}')");
                    }

                    dataGridView1.DataSource = dbManager.ReturnPackedTodayManifest();
                    hourQTY.Text = dbManager.ReturnPackedThisHour();
                    PackedTodayCountLabel.Text = dbManager.ReturnPackedToday();
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
