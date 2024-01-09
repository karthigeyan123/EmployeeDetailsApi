using EmployeeDetails.DAL;
using EmployeeDetails.DB_Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using static EmployeeDetails.Model.Employeedetails;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : Controller
    {
        private readonly EmployeeDetailsService _daLayer;

        public EmployeeDetailsController(EmployeeDetailsService daLayer)
        {
            _daLayer = daLayer;
        }
        [HttpPost(nameof(SaveEmployeeDetails))]
        public string SaveEmployeeDetails(EmployeeDetailsEntity entity)
        {
            try
            {
                MySQLConnection manageSQL = new MySQLConnection();
                var result = _daLayer.SaveEmployeeDetails(entity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError(ex.Message);
            }
            return "false";
        }


        [HttpGet(nameof(GetAllEmployeeDetails))]
        public string GetAllEmployeeDetails()
        {
            var result = _daLayer.GetAllEmployeeDetails();
            return JsonConvert.SerializeObject(result);
        }
        [HttpPut(nameof(DeleteEmployee))]

        public string DeleteEmployee(UpdateemployeeEntity entity)
        {
            try
            {
                MySQLConnection manageSQL = new MySQLConnection();
                var result = _daLayer.DeleteEmployee(entity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
}

