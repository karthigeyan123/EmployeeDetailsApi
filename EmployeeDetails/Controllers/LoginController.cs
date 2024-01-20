using EmployeeDetails.DAL;
using EmployeeDetails.DB_Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using static EmployeeDetails.Model.LoginVm;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginService _daLayer;

        public LoginController(LoginService daLayer)
        {
            _daLayer = daLayer;
        }


        [HttpPost(nameof(UserAuthication))]
        public IActionResult UserAuthication(UserAuthicationEntity entity)
        {
            try
            {
                MySQLConnection manageSQL = new MySQLConnection();
                var result = _daLayer.UserAuthication(entity);

                if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                {
                    var userData = result.Tables[0].Rows[0].ItemArray;
                    var userObject = new ExpandoObject() as IDictionary<string, object>;

                    for (int i = 0; i < result.Tables[0].Columns.Count; i++)
                    {
                        userObject[result.Tables[0].Columns[i].ColumnName] = userData[i];
                    }
                    return Ok(JsonConvert.SerializeObject(userObject));
                }
                else
                {
                    return StatusCode(500, "Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                AuditLog.WriteError(ex.Message);
                return StatusCode(500, "An error occurred while processing your request");
            }
        }



    }
}
