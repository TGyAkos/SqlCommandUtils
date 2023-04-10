using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.GenerateAndWrite
{
    public class GenerateAndWriteFactory
    {
        public static IGenerateAndWrite GetGenerateAndWrite() { return new GenerateAndWrite(); }
    }
}
