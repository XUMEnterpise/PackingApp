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
        public PackedEntry(Item Prebuild, Item Order)
        {
            this.Prebuild = Prebuild;
            this.Order = Order;
        }

        public Item Prebuild { get; }
        public Item Order { get; }

        public List<string> toArray()
        {
            return [Prebuild.OrderId, Prebuild.Sku, Order.OrderId, Order.Sku];
        }
        public ListViewItem[] returnItem()
        {
            ListViewItem item1 = new ListViewItem();
            ListViewItem item2 = new ListViewItem();
            ListViewItem item3 = new ListViewItem();
            ListViewItem item4 = new ListViewItem();
            item1.SubItems.Add(Prebuild.OrderId);
            item2.SubItems.Add(Prebuild.Sku);
            item3.SubItems.Add(Order.OrderId);
            item4.SubItems.Add(Order.Sku);
            return [item1, item2, item3, item4];
        }
        public override string ToString()
        {
            return $"{Prebuild.OrderId} | {Prebuild.Sku} | {Order.OrderId} | {Order.Sku}";
        }
    }
}
