using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlCommandUtils.FileHandling;
using SqlCommandUtils.SqlCommandCreation;

namespace SqlCommandUtils.GenerateAndWrite
{
    public class GenerateAndWrite : IGenerateAndWrite
    {
        private readonly ISqlCommandDataFilling sqlCommandDataFilling;
        private readonly IOpenFile openFile;
        private readonly IWriteToFile writeToFile;
        private readonly IReadFile readFile;

        public GenerateAndWrite()
        {
            sqlCommandDataFilling = SqlCommandDataFillingFactory.GetSqlCommandDataFilling();
            openFile = OpenFileFactory.GetOpenFile();
            writeToFile = WriteToFileFactory.GetWriteToFile();
            readFile = ReadFileFactory.GetReadFile();
        }

        public FileData SetFilePaths(string readFilePath, string writeFilePath)
        {
            return openFile.InitializeFileData(readFilePath, writeFilePath);
        }

        public void CreateFileToBeWrittenTo(FileData fileData)
        {
            openFile.CreateFile(fileData);
        }

        public void StartWriting(FileData writeFileData)
        {
            ReadData readData = readFile.InitializeReadData(writeFileData);

            readData = readFile.ReadNextLine(readData);
            SqlCommand sqlCommandBase = sqlCommandDataFilling.GenerateSqlCommandBase();

            if (readData.Position == 1) sqlCommandBase = sqlCommandDataFilling.AddColumns(sqlCommandBase, readData.CurrentLine);
            Console.WriteLine(sqlCommandBase.SqlCommandValues);
            while (!readData.FileEmpty)
            {
                readData = readFile.ReadNextLine(readData);

                SqlCommand sqlCommand = sqlCommandDataFilling.GenerateSqlCommandBase();
                sqlCommand = sqlCommandDataFilling.AddColumnsInBatch(sqlCommand, sqlCommandBase.SqlCommandColumns);
                sqlCommand = sqlCommandDataFilling.AddValues(sqlCommand, readData.CurrentLine);
                sqlCommand = sqlCommandDataFilling.GenerateFinishedSqlCommand(sqlCommand);

                DataToBeWritten dataToBeWritten = writeToFile.SetDataToBeWritten(sqlCommand.SqlCommandText);
                writeToFile.WriteLine(writeFileData, dataToBeWritten);
            }
        }
    }
}
