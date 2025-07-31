using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingSoftware
{
    public class DBManager
    {
        SqlConnection _connection;
        readonly string sql = ConfigurationManager.ConnectionStrings["BuildQtyTracker.Properties.Settings.xumlocalConnectionString"].ConnectionString;


        /// <summary>
        /// Insert update delete querries
        /// </summary>
        /// <param name="querry">Querry to execute</param>
        public bool InsertQuerry(string querry)
        {
            try
            {
                using (_connection = new SqlConnection(sql))
                using (var command = _connection.CreateCommand())
                {
                    _connection.Open();
                    command.CommandText = querry;
                    Console.WriteLine("Rows affected " + command.ExecuteNonQuery());
                    _connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// Select the whole table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataTable Select(string table)
        {
            try
            {
                DataTable dt = new DataTable();
                string querry = $"SELECT * FROM {table}";
                using (_connection = new SqlConnection(sql))
                using (SqlDataAdapter adapter = new SqlDataAdapter(querry, _connection))
                {
                    _connection.Open();
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch
            {
                return null;
            }

        }
        public DataTable SelectColumn(string table, string collumn)
        {
            try
            {
                DataTable dt = new DataTable();
                string querry = $"SELECT {collumn} FROM {table}";
                using (_connection = new SqlConnection(sql))
                using (SqlDataAdapter adapter = new SqlDataAdapter(querry, _connection))
                {
                    _connection.Open();
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch
            {
                return null;
            }

        }
        public string ReturnPackedThisHour()
        {
            string itemCount = "";

            // Get the current date and hour
            DateTime now = DateTime.Now;
            DateTime startOfHour = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            DateTime endOfHour = startOfHour.AddHours(1);

            // SQL query to count items within the current hour
            string query = $"SELECT COUNT(*) FROM History WHERE PackedDate >= @StartOfHour AND PackedDate < @EndOfHour";

            try
            {
                using (_connection = new SqlConnection(sql))
                using (var command = _connection.CreateCommand())
                {
                    _connection.Open();
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@StartOfHour", startOfHour);
                    command.Parameters.AddWithValue("@EndOfHour", endOfHour);
                    itemCount = command.ExecuteScalar().ToString();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return itemCount;
        }
        public string ReturnPackedToday()
        {
            string itemCount = "";

            // Get the current date (ignoring the time part)
            DateTime today = DateTime.Today;

            // SQL query to count items packed today
            string query = $"SELECT Count(*) FROM History where  CAST(PackedDate AS DATE) = CAST(GETDATE() AS DATE)";

            try
            {
                using (SqlConnection _connection = new SqlConnection(sql))
                using (var command = _connection.CreateCommand())
                {
                    _connection.Open();
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@Today", today);
                    itemCount = command.ExecuteScalar().ToString();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return itemCount;
        }
        public DataTable ReturnPackedTodayManifest()
        {
            DataTable dt = new DataTable();

            // Get the current date (ignoring the time part)
            DateTime today = DateTime.Today;

            // SQL query to count items packed today
            string query = "SELECT * FROM ManifestTable WHERE CAST(PackedDate AS DATE) = @Today AND NOT OrderSKU like 'L%'";

            try
            {
                using (SqlConnection _connection = new SqlConnection(sql))
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // Add the parameter to the command
                    command.Parameters.AddWithValue("@Today", today);

                    _connection.Open();
                    adapter.Fill(dt);
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }
        
        public DataTable ReturnOrdersLeftToPack()
        {
            DataTable dt = new DataTable();

            // Get the current date and 7 days ago
            DateTime today = DateTime.Today;
            DateTime sevenDaysAgo = today.AddDays(-7);

            // SQL query to get orders from the past 7 days that haven't been packed yet (PackedDate is NULL)
            // Exclude orders where Channel contains "Laptop" or "Prebuilt"
            // For PCs: SKU starts with C followed by number, but not CX
            // For Laptops: SKU starts with L followed by number, but not LX
            string query = @"SELECT 
                                h.Orderid,
                                h.SKU,
                                h.QTY,
                                h.Channel,
                                h.Date,
                                h.AssignedNumber
                            FROM History h 
                            WHERE h.PackedDate IS NULL 
                            AND CAST(h.Date AS DATE) >= @SevenDaysAgo
                            AND h.Channel NOT LIKE '%Laptop%'
                            AND h.Channel NOT LIKE '%Prebuilt%'
                            AND h.Channel NOT LIKE '%DIRECT%'
                            AND (
                                (h.SKU LIKE 'C[0-9]%' AND h.SKU NOT LIKE 'CX%') OR
                                (h.SKU LIKE 'L[0-9]%' AND h.SKU NOT LIKE 'LX%')
                            )
                            ORDER BY h.Date ASC";

            try
            {
                using (SqlConnection _connection = new SqlConnection(sql))
                using (SqlCommand command = new SqlCommand(query, _connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // Add the parameter to the command
                    command.Parameters.AddWithValue("@SevenDaysAgo", sevenDaysAgo);

                    _connection.Open();
                    adapter.Fill(dt);
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }
        
        public string ReturnOrdersLeftToPackCount()
        {
            string itemCount = "";

            // Get the current date and 7 days ago
            DateTime today = DateTime.Today;
            DateTime sevenDaysAgo = today.AddDays(-7);

            // SQL query to count orders from the past 7 days that haven't been packed yet
            // Exclude orders where Channel contains "Laptop" or "Prebuilt"
            // For PCs: SKU starts with C followed by number, but not CX
            // For Laptops: SKU starts with L followed by number, but not LX
            string query = @"SELECT COUNT(*) FROM History 
                            WHERE PackedDate IS NULL 
                            AND CAST(Date AS DATE) >= @SevenDaysAgo 
                            AND Channel NOT LIKE '%Laptop%' 
                            AND Channel NOT LIKE '%Prebuilt%'
                            AND Channel NOT LIKE '%DIRECT%'
                            AND (
                                (SKU LIKE 'C[0-9]%' AND SKU NOT LIKE 'CX%') OR
                                (SKU LIKE 'L[0-9]%' AND SKU NOT LIKE 'LX%')
                            )";

            try
            {
                using (SqlConnection _connection = new SqlConnection(sql))
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    // Add the parameter to the command
                    command.Parameters.AddWithValue("@SevenDaysAgo", sevenDaysAgo);

                    _connection.Open();
                    itemCount = command.ExecuteScalar().ToString();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                itemCount = "0";
            }

            return itemCount;
        }
        
        /// <summary>
        /// Select the table that fits the condition
        /// </summary>
        /// <param name="table">Table to select from</param>
        /// <param name="collum">Collum to apply the condition to</param>
        /// <param name="condition">Condition</param>
        /// <returns></returns>
        public DataTable SelectSpecific(string table, string collum, string condition)
        {
            try
            {
                DataTable dt = new DataTable();
                string querry = $"SELECT * FROM {table} WHERE {collum}='{condition}'";
                using (_connection = new SqlConnection(sql))
                using (SqlDataAdapter adapter = new SqlDataAdapter(querry, _connection))
                {
                    _connection.Open();
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch
            {
                return null;
            }

        }
        public DataTable SelectWild(string table, string collum, string condition)
        {
            try
            {
                DataTable dt = new DataTable();
                string querry = $"SELECT * FROM {table} WHERE {collum} LIKE '{condition}'";
                using (_connection = new SqlConnection(sql))
                using (SqlDataAdapter adapter = new SqlDataAdapter(querry, _connection))
                {
                    _connection.Open();
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// Deletes the collum on the condition
        /// </summary>
        /// <param name="table">Table to delete from</param>
        /// <param name="columnName">Name of the column to apply the condition on</param>
        /// <param name="condition">Condition</param>
        public void DeleteRow(string table, string columnName, string condition)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sql))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand($"DELETE FROM {table} WHERE {columnName}={condition}", con))
                    {
                        Console.WriteLine("Rows affected " + command.ExecuteNonQuery());
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        internal Item ReturnItem(string orderNumber)
        {
            DataRow item;
            try
            {
                item = SelectSpecific("History", "Orderid", orderNumber).Rows[^1];
            }
            catch (Exception)
            {
                orderNumber = orderNumber.Replace("P", "");
                item = SelectSpecific("History", "Orderid", orderNumber).Rows[^1];
            }
            DataRow sku = SelectSpecific("SKUS", "SKU", item[2].ToString()??"").Rows[^1];
            Item returnItem;
            if (sku != null)
            {
                // Check SKU for product type instead of non-existent ProductType column
                string channel = item[4].ToString(); // SKU column
                if (channel.Contains("Prebuilt"))
                {
                     return new Item(orderNumber, sku[0].ToString(), sku[3].ToString(), sku[5].ToString(), sku[4].ToString(), sku[7].ToString(), sku[9].ToString(), sku[6].ToString(), ItemType.PC_Prebuild);
                }else if(channel.Contains("Laptop"))
                {
                     return new Item(orderNumber, sku[0].ToString(), sku[3].ToString(), sku[5].ToString(), sku[4].ToString(), sku[7].ToString(), sku[9].ToString(), sku[6].ToString(), ItemType.Laptop_Prebuild);
                }
                else
                {
                     return  new Item(orderNumber, sku[0].ToString(), sku[3].ToString(), sku[5].ToString(), sku[4].ToString(), sku[7].ToString(), sku[9].ToString(), sku[6].ToString(), ItemType.Order);
                }
            }
            return null;
            
            
        }
    }
}