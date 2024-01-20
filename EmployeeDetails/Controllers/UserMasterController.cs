using EmployeeDetails.DAL;
using EmployeeDetails.DB_Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static EmployeeDetails.Model.UserMasterVm;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : Controller
    {
        private readonly UserMasterService _daLayer;
        public UserMasterController(UserMasterService daLayer)
        {
            _daLayer = daLayer;
        }
        [HttpPost(nameof(SaveUser))]
        public string SaveUser(UserMasterEntity entity)
        {
            try
            {
                MySQLConnection manageSQL = new MySQLConnection();
                var result = _daLayer.SaveUser(entity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError(ex.Message);
            }
            return "false";
        }


        [HttpGet(nameof(GetAllUserMaster))]
        public string GetAllUserMaster()
        {
            var result = _daLayer.GetAllUserMaster();
            return JsonConvert.SerializeObject(result);
        }


        [HttpGet(nameof(GetAllUserMasterByEmail))]
        public string GetAllUserMasterByEmail(string Email)
        {
            var result = _daLayer.GetAllUserMasterByEmail(Email);
            return JsonConvert.SerializeObject(result);
        }
    }
}
