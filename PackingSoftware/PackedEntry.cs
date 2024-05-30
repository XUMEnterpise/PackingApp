using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingSoftware
{
    public class PackedEntry
    {
        public PackedEntry(string prebuildNumber, string prebuildSku, string orderNumber, string orderSku)
        {
            this.prebuildNumber = prebuildNumber;
            this.prebuildSku = prebuildSku;
            this.orderNumber = orderNumber;
            this.orderSku = orderSku;
        }

        public string prebuildNumber { get; }
        public string prebuildSku { get; }
        public string orderNumber { get; }
        public string orderSku { get; }

        public List<string> toArray()
        {
            return [prebuildNumber, prebuildSku, orderNumber, orderSku];
        }
        public ListViewItem[] returnItem()
        {
            ListViewItem item1 = new ListViewItem();
            ListViewItem item2 = new ListViewItem();
            ListViewItem item3 = new ListViewItem();
            ListViewItem item4 = new ListViewItem();
            item1.SubItems.Add(prebuildNumber);
            item2.SubItems.Add(prebuildSku);
            item3.SubItems.Add(orderNumber);
            item4.SubItems.Add(orderSku);
            return [item1, item2, item3, item4];
        }
        public override string ToString()
        {
            return $"{prebuildNumber} | {prebuildSku} | {orderNumber} | {orderSku}";
        }
    }
}
