using EmployeeDetails.DB_Connection;
using static EmployeeDetails.Model.UserMasterVm;
using System.Security.Claims;
using EmployeeDetails.DBL;
using System.Data;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmployeeDetails.DAL
{
    public class UserMasterService
    {
        public bool SaveUser(UserMasterEntity entity)
        {
            List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
            DbLayer manageSQL = new DbLayer();
            sqlParameters.Add(new KeyValuePair<string, string>("@inuserid", Convert.ToString(entity.Userid)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inusername", entity.Username));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemail", entity.Email));
            sqlParameters.Add(new KeyValuePair<string, string>("@inpassword", entity.Password));
            sqlParameters.Add(new KeyValuePair<string, string>("@inflag", Convert.ToString(entity.flag)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inuseraadharno", entity.Useraadharno));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemployeeid", Convert.ToString(entity.Employeeid)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemployeeuniquecode", Convert.ToString(entity.Useruniquecode)));
            return manageSQL.InsertData("insertusermaster", sqlParameters);
        }
        public DataSet GetAllUserMaster()
        {
            DbLayer manageSQL = new DbLayer();
            return manageSQL.GetDataSetValues("getusermaster");
        }
        public DataSet GetAllUserMasterByEmail(string Email)
        {
            List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
            DbLayer manageSQL = new DbLayer();
            sqlParameters.Add(new KeyValuePair<string, string>("@inemail", Convert.ToString(Email)));
            DataSet result = manageSQL.GetDataSetValues("getusermasterbyemail", sqlParameters);
            return result;
        }
        //public DataSet UserAuthication(UserAuthicationEntity entity)
        //{
        //    List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
        //    DbLayer manageSQL = new DbLayer();
        //    sqlParameters.Add(new KeyValuePair<string, string>("@inusername", entity.Username));
        //    sqlParameters.Add(new KeyValuePair<string, string>("@inpassword", entity.Password));
        //    DataSet result = manageSQL.GetDataSetValues("userauthentication", sqlParameters);
        //    return result;
        //}
    }
}   
