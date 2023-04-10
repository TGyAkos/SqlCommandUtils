using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.FileHandling
{
    public class FileData
    {
        public string? ReadFilePath { get; set; }
        public string? WriteFilePath { get; set; }

    }

    public class ReadData : FileData
    {
        public int? Length { get; set; }
        public int Position { get; set; }
        public bool FileEmpty { get; set; }
        public string[]? CurrentLine { get; set; }
    }

    public class DataToBeWritten
    {
        private string? _data;
        private byte[]? _dataBytes;
        public string? Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
                _dataBytes = new UTF8Encoding().GetBytes(value);
            }
        }
        public byte[]? DataBytes
        {
            get
            {
                return _dataBytes;
            }
        }
    }
}
