using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.FileHandling
{
    public class WriteLineToFileFactory
    {
        public static IWriteLineToFile GetWriteLineToFile() { return new WriteLineToFile(); }
    }

    public class OpenFileFactory
    {
        public static IOpenFile GetOpenFile() { return new OpenFile(); }
    }

    public class WriteToFileFactory
    {
        public static IWriteToFile GetWriteToFile() { return new WriteToFile(); }
    }

    public class ReadFileFactory
    {
        public static IReadFile GetReadFile() { return new ReadFile(); }
    }
}
