using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlCommandUtils.FileHandling;
using SqlCommandUtils.GenerateAndWrite;

namespace SqlCommandUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            IGenerateAndWrite generateAndWrite = GenerateAndWriteFactory.GetGenerateAndWrite();

            FileData filedata = generateAndWrite.SetFilePaths(@"C:\Users\user\Desktop\ugyfelek.csv", @"C:\Users\user\Desktop\ugyfelek.sql");
            generateAndWrite.CreateFileToBeWrittenTo(filedata);
            generateAndWrite.StartWriting(filedata);
        }
    }
}
    