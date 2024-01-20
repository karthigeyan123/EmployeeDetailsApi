using crypto;
using EmployeeDetails.DBL;
using Newtonsoft.Json;
using System.Data;
using static EmployeeDetails.Model.LoginVm;

namespace EmployeeDetails.DAL
{
    public class LoginService
    {
        public DataSet UserAuthication(UserAuthicationEntity entity)
        {
            List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
            DbLayer manageSQL = new DbLayer();
            sqlParameters.Add(new KeyValuePair<string, string>("@inusername", entity.Username));
            sqlParameters.Add(new KeyValuePair<string, string>("@inpassword", entity.Password));
            DataSet result = manageSQL.GetDataSetValues("userauthentication", sqlParameters);
            return result;
        }
    }
}
