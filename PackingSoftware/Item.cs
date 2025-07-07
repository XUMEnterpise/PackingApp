using Microsoft.VisualBasic.Devices;
using PackingSoftware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PackingSoftware
{
    public enum ItemType
    {
       PC_Order,
       PC_Prebuild,
       Laptop_Order,
       Laptop_Prebuild
    }
    public class Item
    {
        public Item(string orderId, string sku, string cpu, string gPU, string ram, string sSD, string oS, string hDD,ItemType itemType)
        {
            OrderId = orderId;
            Sku = sku;
            Cpu = cpu;
            GPU = gPU;
            Ram = ram;
            SSD = sSD;
            OS = oS;
            HDD = hDD;
            type = itemType;
        }

        public string OrderId { get; private set; }
        
        public string Sku { get; private set; }
        public string Cpu { get; private set; }
        public string GPU { get; private set; }
        public string Ram { get; private set; }
        public string SSD { get; private set; }
        public string OS { get; private set; }
        public string HDD { get; private set; }
        public ItemType type { get; private set; }
        public async Task<bool> Compare(Item prebuild)
        {
            bool skuCorrect = await checkIfPassed(prebuild);
            if (!skuCorrect) {
                MessageBox.Show($"SKUs do not match please double check.\n Order SKU is: {this.Sku}\n Prebuild SKU is:{prebuild.Sku}");
            }
            return skuCorrect;
        }
        private async Task<bool> checkIfPassed(Item prebuild)
        {
            string gpuSkuW = Regex.Replace(this.GPU, @"\s+", "");
            string gpuW = Regex.Replace(prebuild.GPU, @"\s+", "");
            bool skuTrue = true;
            bool skuCorrect = true;

            skuCorrect = Check(this.Cpu.ToUpper(), prebuild.Cpu.ToUpper(), "CPU");
            if (!skuCorrect)
            {
                skuTrue = false;
            }
            skuCorrect = Check(gpuSkuW.ToUpper(), gpuW.ToUpper(), "GPU");
            if (!skuCorrect)
            {
                skuTrue = false;
            }
            skuCorrect = Check(this.Ram,prebuild.Ram, "RAM");
            if (!skuCorrect)
            {
                skuTrue = false;
            }
            if (this.SSD.Equals("N/A") || String.IsNullOrEmpty(this.SSD) || prebuild.SSD.Equals("N/A") || String.IsNullOrEmpty(prebuild.SSD))
            {
                skuCorrect = Check(this.SSD, prebuild.SSD, "BOOT");
            }
            else
            {
                skuCorrect = Check(this.SSD, prebuild.SSD, "BOOT");
            }
            if (!skuCorrect)
            {
                skuTrue = false;
            }
            if (this.HDD.Equals("N/A") || String.IsNullOrEmpty(this.HDD) || prebuild.HDD.Equals("N/A") || String.IsNullOrEmpty(prebuild.HDD))
            {
                skuCorrect = Check(this.HDD, prebuild.HDD, "SEC");
            }
            else
            {
                skuCorrect = Check(this.HDD, prebuild.HDD, "SEC");
            }
            if (!skuCorrect)
            {
                skuTrue = false;
            }
            return skuTrue;
        }

        private bool Check(string order, string prebuild, string type)
        {
            if (type.Contains("CPU"))
            {
                try
                {
                    string[] splitSku = order.Split('-');
                    string[] splitComp = prebuild.Split('-');
                    string skuTrimmed;
                    string compTrimmed;
                    try
                    {
                        skuTrimmed = Regex.Replace(splitSku[1], "[^0-9.]", "");
                        compTrimmed = Regex.Replace(splitComp[1], "[^0-9.]", "");
                    }
                    catch (Exception)
                    {

                        skuTrimmed = Regex.Replace(splitSku[0], "[^0-9.]", "");
                        compTrimmed = Regex.Replace(splitComp[0], "[^0-9.]", "");
                    }

                    int resultSku = Int32.Parse(skuTrimmed);
                    int resultComp = Int32.Parse(compTrimmed);
                    int difference = resultComp - resultSku;
                    double ratio = (double)resultComp / (double)resultSku;
                    if (difference >= 0)
                    {
                        if (ratio >= 1 && ratio <= 1.04)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    if (order.Contains(prebuild))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }

            else if (prebuild.Contains(order))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
