using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Common
{
    public class DisplayInfo
    {
        private const int TableWidth = 100;

        /// <summary>
        /// based class to print statement of account and account information
        /// </summary>
        public static void PrintLines()
        {
            Console.WriteLine(new string('-', TableWidth));
        }
        public static void PrintHeadings(params string[] col)
        {
            int width = (TableWidth - col.Length) / col.Length;
            const string seed = "|";
            string row = col.Aggregate(seed, (seperator, colText) => seperator + GetCenterAllignedText(colText, width) + seed);
            Console.WriteLine(row);
        }
        private static string GetCenterAllignedText(string colText, int width)
        {
            colText = colText.Length > width ? colText.Substring(0, width - 3) + "..." : colText;
            return string.IsNullOrEmpty(colText) ? new string(' ', width)
                : colText.PadRight(width - ((width - colText.Length) / 2)).PadLeft(width);
        }
        
    }
}
