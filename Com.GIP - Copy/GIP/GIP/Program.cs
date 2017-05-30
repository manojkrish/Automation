using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIP
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("C:\\Users\\ManojKRanganathan\\Desktop\\Testing.xls", FileMode.OpenOrCreate);
            ExcelWriteHelper writer = new ExcelWriteHelper(stream);
            writer.BeginWrite();
            writer.WriteCell(0, 0, "ExcelWriter Demo");
            writer.WriteCell(1, 0, "int");
            writer.WriteCell(1, 1, 10);
            writer.WriteCell(2, 0, "double");
            writer.WriteCell(2, 1, 1.5);
            writer.WriteCell(3, 0, "empty");
            writer.WriteCell(3, 1);
            writer.EndWrite();
            stream.Close();
        }


    }
}
