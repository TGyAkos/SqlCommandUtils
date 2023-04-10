using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.SqlCommandCreation
{
    public class SqlCommandDataFilling : ISqlCommandDataFilling
    {
        private readonly IInsertSqlCommandGeneration IInsertSqlCommandGeneration;

        public SqlCommandDataFilling()
        {
            IInsertSqlCommandGeneration = SqlCommandGenerationFactory.GetInsertSqlCommandGeneration();
        }

        public SqlCommand GenerateSqlCommandBase()
        {
            return IInsertSqlCommandGeneration.GenerateSqlCommandBase();
        }

        public SqlCommand GenerateFinishedSqlCommand(SqlCommand sqlCommand)
        {
            return IInsertSqlCommandGeneration.GenerateFinishedSqlCommand(sqlCommand);
        }

        public SqlCommand AddColumnsInBatch(SqlCommand sqlCommand, string columns)
        {
            return IInsertSqlCommandGeneration.AddColumnsInBatch(sqlCommand, columns);
        }

        public SqlCommand AddColumns(SqlCommand sqlCommand, params string[] columns)
        {
            foreach (string column in columns)
            {
                sqlCommand = IInsertSqlCommandGeneration.AddColumn(sqlCommand, column);
            }

            return sqlCommand;
        }

        public SqlCommand AddValues(SqlCommand sqlCommand, params string[] values)
        {
            foreach (string value in values)
            {
                sqlCommand = IInsertSqlCommandGeneration.AddValue(sqlCommand, value);
            }

            return sqlCommand;
        }
    }
}
