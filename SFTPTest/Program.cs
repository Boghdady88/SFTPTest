using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new SFTPFilesTransfer().SendFiles(2); // transferOption = 1 Upload , 2 or else Download
        }
    }
}
