using System.Data;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.App_Code.Helpers
{
    public static class AppUserHelper
    {
        public static AppUser ConvertReaderToAppUser(IDataReader dataReader)
        {
            return new AppUser
            {
                ID = int.Parse(dataReader["ID"].ToString()),
                LoginNickname = dataReader["LoginNickname"].ToString(),
                LoginPassword = dataReader["LoginPassword"].ToString(),
                Email = dataReader["Email"].ToString(),
                FirstName = dataReader["FirstName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                IsAdmin = bool.Parse(dataReader["IsAdmin"].ToString()),
                StreetNumber = dataReader["StreetNumber"].ToString(),
                StreetName = dataReader["StreetName"].ToString(),
                Zipcode = dataReader["Zipcode"].ToString(),
                City = dataReader["City"].ToString(),
                Country = dataReader["Country"].ToString(),
            };
        }
    }
}
