using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using WebAPI_MNS_Games.Abstractions;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.App_Code.Helpers
{
    public static class DbCommandHelper
    {

        public static void SetStoredProcedureName(IDbCommand sqlCommand, string storedProcedureName)
        {
            sqlCommand.CommandText = storedProcedureName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public static void AddParameterWithValue(this IDbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.Value = parameterValue;
            parameter.ParameterName = parameterName;
            command.Parameters.Add(parameter);
        }
        
        public static IDbDataParameter AddOutputParameter(this IDbCommand command, string parameterName, DbType dbType ,int dbParameterSize = 50)
        {
            IDbDataParameter returnCodeParameter = command.CreateParameter();
            returnCodeParameter.ParameterName = $"@{parameterName}";
            returnCodeParameter.Direction = ParameterDirection.Output;
            returnCodeParameter.DbType = dbType;
            returnCodeParameter.Size = dbParameterSize;
            command.Parameters.Add(returnCodeParameter);

            return returnCodeParameter;
        }

        public static void SetProcedureParameters(AbstractDatabaseTable table, IDbCommand sqlCommand)
        {
            PropertyInfo[] properties = table.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if(property.Name != "ID" && property.Name != "IsAdmin")
                {
                    AddParameterWithValue(sqlCommand, $"@{property.Name}", property.GetValue(table));
                }
            }
        }
    }
}
