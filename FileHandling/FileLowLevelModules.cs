using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.FileHandling
{
    public class WriteLineToFile : IWriteLineToFile
    {
        public DataToBeWritten SetDataToBeWritten(string dataToBeWritten)
        {
            return new DataToBeWritten() { Data = dataToBeWritten };
        }
    }

    public class OpenFile : IOpenFile
    {
        public FileData InitializeFileData(string readFilePath, string writeFilePath)
        {
            return new FileData() { ReadFilePath = readFilePath, WriteFilePath = writeFilePath };
        }

        public void CreateFile(FileData writeFileData)
        {
            File.Create(writeFileData.WriteFilePath).Close();
        }

        public StreamWriter GetStreamWriter(FileData writeFileData)
        {
            return File.AppendText(writeFileData.WriteFilePath);
        }

        public void CloseStream(StreamWriter writerStream)
        {
            writerStream.Close();
        }
    }

    public class ReadFile : IReadFile
    {
        public ReadData InitializeReadData(FileData fileData)
        {
            return new ReadData
            {
                FileEmpty = false,
                Position = 0,
                ReadFilePath = fileData.ReadFilePath,
                Length = File.ReadAllLines(fileData.ReadFilePath).Length,
            };
        }

        public ReadData ReadNextLine(ReadData readData)
        {
            if (readData.Position == readData.Length)
            {
                readData.FileEmpty = true;
                return readData;
            }

            readData.CurrentLine = File.ReadLines(readData.ReadFilePath)
                .Skip(readData.Position)
                .Take(1)
                .First()
                .Replace("\"","")
                .Split(";");

            readData.Position += 1;

            return readData;
        }
    }
}
