using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.SqlCommandCreation
{
    public class InsertSqlCommandGeneration : IInsertSqlCommandGeneration
    {
        public SqlCommand GenerateSqlCommandBase()
        {
            SqlCommand sqlCommand = new();
            return sqlCommand;
        }
        public SqlCommand GenerateFinishedSqlCommand(SqlCommand sqlCommand)
        {
            sqlCommand.SqlCommandText = $"INSERT INTO ({sqlCommand.SqlCommandColumns}) VALUES {sqlCommand.SqlCommandValues}";
            return sqlCommand;
        }

        public SqlCommand AddColumnsInBatch(SqlCommand sqlCommand, string columns)
        {
            sqlCommand.SqlCommandColumns = columns;
            return sqlCommand;
        }

        public SqlCommand AddColumn(SqlCommand sqlCommand, string column)
        {
            sqlCommand.SqlCommandColumns += $"{column}, ";
            return sqlCommand;
        }

        public SqlCommand AddValue(SqlCommand sqlCommand, string value)
        {
            sqlCommand.SqlCommandValues += $"\"{value}\", ";
            return sqlCommand;
        }
    }
}
