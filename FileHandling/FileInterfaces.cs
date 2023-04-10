using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.FileHandling
{
    public interface IWriteToFile : IWriteLineToFile
    {
        void WriteLine(FileData writeFileData, DataToBeWritten dataToBeWritten);

    }
    public interface IWriteLineToFile
    {
        DataToBeWritten SetDataToBeWritten(string dataToBeWritten);
    }

    public interface IOpenFile
    {
        FileData InitializeFileData(string readFilePath, string writeFilePath);
        void CreateFile(FileData writeFileData);
        StreamWriter GetStreamWriter(FileData writeFileData);
        void CloseStream(StreamWriter writerStream);
    }

    public interface IReadFile
    {
        ReadData InitializeReadData(FileData fileData);
        ReadData ReadNextLine(ReadData readData);
    }
}
