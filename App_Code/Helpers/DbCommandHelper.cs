using System.Data;

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
    }
}
