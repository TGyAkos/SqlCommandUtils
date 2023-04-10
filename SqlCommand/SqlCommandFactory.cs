using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.SqlCommandCreation
{
    public class SqlCommandGenerationFactory
    {
        public static IInsertSqlCommandGeneration GetInsertSqlCommandGeneration() { return new InsertSqlCommandGeneration(); }
    }

    public class SqlCommandDataFillingFactory
    {
        public static ISqlCommandDataFilling GetSqlCommandDataFilling() { return new SqlCommandDataFilling(); }
    }
}
