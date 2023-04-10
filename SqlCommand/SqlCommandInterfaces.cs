using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandUtils.SqlCommandCreation
{
    public interface ISqlCommandGeneration
    {
        SqlCommand GenerateSqlCommandBase();
        SqlCommand GenerateFinishedSqlCommand(SqlCommand sqlCommand);
    }

    public interface IInsertSqlCommandGeneration : ISqlCommandGeneration
    {
        SqlCommand AddColumnsInBatch(SqlCommand sqlCommand, string columns);
        SqlCommand AddColumn(SqlCommand sqlCommand, string column);
        SqlCommand AddValue(SqlCommand sqlCommand, string value);

    }

    public interface ISqlCommandDataFilling : ISqlCommandGeneration
    {
        SqlCommand AddColumnsInBatch(SqlCommand sqlCommand, string columns);
        SqlCommand AddColumns(SqlCommand sqlCommand, params string[] columns);
        SqlCommand AddValues(SqlCommand sqlCommand, params string[] values);

    }
}
