using System.Data;

namespace WebAPI_MNS_Games.App_Code.Helpers
{
    public static class DbCommandHelper
    {
        public static void AddParameterWithValue(this IDbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }
    }
}
