using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.FileHandling
{
    public class WriteToFile : IWriteToFile
    {
        private readonly IWriteLineToFile writeLineToFile;
        private readonly IOpenFile openFile;

        public WriteToFile()
        {
            writeLineToFile = WriteLineToFileFactory.GetWriteLineToFile();
            openFile = OpenFileFactory.GetOpenFile();
        }

        public DataToBeWritten SetDataToBeWritten(string data)
        {
            return writeLineToFile.SetDataToBeWritten(data);
        }

        public void WriteLine(FileData writeFileData, DataToBeWritten dataToBeWritten)
        {
            StreamWriter streamWriter = openFile.GetStreamWriter(writeFileData);
            streamWriter.WriteLine(dataToBeWritten.Data);
            openFile.CloseStream(streamWriter);
        }
    }
}
