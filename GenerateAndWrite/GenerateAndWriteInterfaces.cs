using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlCommandUtils.FileHandling;

namespace SqlCommandUtils.GenerateAndWrite
{
    public interface IGenerateAndWrite
    {
        FileData SetFilePaths(string readFilePath, string writeFilePath);
        void StartWriting(FileData writeFileData);
        void CreateFileToBeWrittenTo(FileData fileData);
    }
}
