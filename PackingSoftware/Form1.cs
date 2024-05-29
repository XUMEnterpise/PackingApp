using System.Data;

namespace PackingSoftware
{
    public partial class Form1 : Form
    {
        DBManager dbManager = new DBManager();
        public Form1()
        {
            InitializeComponent();
            orderNumberTextBox.Focus();
        }
        private bool checkIfExists(string itemToLook, string table, string column)
        {
            bool exists = false;
            DataTable dt = dbManager.SelectColumn(table, column);

            foreach (DataRow item in dt.Rows)
            {
                if (item[0].ToString().Trim(' ').Contains(itemToLook))
                {
                    exists = true;
                }
            }
            return exists;
        }

        private async void orderNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string orderNumber = orderNumberTextBox.Text;
            if (e.KeyCode == Keys.Enter)
            {
                if (checkIfExists(orderNumber, "History", "OrderID"))
                {
                    DataRow item = dbManager.SelectSpecific("History", "OrderID", orderNumber).Rows[^1];
                    if (item.ItemArray[4].ToString().Contains("Prebuilt") || item.ItemArray[4].ToString().Contains("Laptop"))
                    {
                        label2.Visible = true;
                        secondTextBox.Visible = true;
                        secondTextBox.Focus();
                    }
                    else
                    {
                        staffTextBox.Focus();
                    }
                }
                else
                {
                    ShowErrorAsync(label1, orderNumberTextBox);
                }
            }
        }
        private async void ShowErrorAsync(Label label, TextBox textBox)
        {
            // Save the original color of the label
            var originalColor = label.ForeColor;

            // Change the label color to red
            label.ForeColor = System.Drawing.Color.Red;
            textBox.ForeColor = Color.Red;

            // Wait for 5 seconds
            await Task.Delay(5000);

            // Revert the label color to its original color
            label.ForeColor = originalColor;
            textBox.ForeColor = originalColor;
        }

        private void OnEnterSecondTextBox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (orderNumberTextBox.Text == secondTextBox.Text)
                {
                    staffTextBox.Focus();
                }
                else
                {
                    dbManager.InsertQuerry($"UPDATE History SET AssignedNumber='{orderNumberTextBox.Text}' where OrderId='{secondTextBox.Text}'");
                    dbManager.InsertQuerry($"UPDATE History SET AssignedNumber='{secondTextBox.Text}' where OrderId='{orderNumberTextBox.Text}'");
                    staffTextBox.Focus();
                }
            }
        }

        private void OnEnterStaff(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
                string staffName = dbManager.SelectSpecific("StaffTable", "StaffNumber", staffTextBox.Text).Rows[^1].ItemArray[1].ToString();
                dbManager.InsertQuerry($"UPDATE History SET PackedBy='{staffName}', PackedDate='{formattedTime}' where OrderId='{orderNumberTextBox.Text}'");
                reset();
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
