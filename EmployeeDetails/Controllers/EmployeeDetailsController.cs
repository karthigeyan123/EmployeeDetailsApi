using EmployeeDetails.DAL;
using EmployeeDetails.DB_Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        [HttpPost("saveEmployeeDetails")]
        public IActionResult SaveEmployeeDetails([FromForm] EmployeeDetailsModel entity, [FromForm(Name = "files")] IFormFileCollection files)
        {
            try
            {
                var result = _daLayer.SaveEmployeeDetails(entity, files);

                if (!result)
                {
                    return StatusCode(500, "Failed to save employee details.");
                }

                return Ok(new { Success = true, Message = "Employee details saved successfully." });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        [HttpGet]
        public IActionResult Get(int inemployeeid)
        {
            List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
            MySQLConnection manageSQL = new MySQLConnection();
            sqlParameters.Add(new KeyValuePair<string, string>("@inemployeeid", Convert.ToString(inemployeeid)));
            var result = manageSQL.GetDataSetValues("getemployeeDetailsById", sqlParameters);

            if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                var employeeData = result.Tables[0].Rows[0];
                var documentsJson = employeeData["Documents"].ToString();

                var documentsArray = JArray.Parse(documentsJson);

                var documents = documentsArray
     .Where(doc =>
         doc["DocumentName"] != null &&
         doc["DocumentName"] != null &&
         doc["DocumentPath"] != null
     )
     .Select(doc =>
         new
         {
             DocumentId = doc["DocumentId"] != null ? doc["DocumentName"].ToString() : string.Empty,
             DocumentName = doc["DocumentName"] != null ? doc["DocumentName"].ToString() : string.Empty,
             DocumentPath = doc["DocumentPath"] != null ? doc["DocumentPath"].ToString() : string.Empty
         }
     )
     .ToList<dynamic>();

                // If all documents are empty, set documents to an empty array
                if (documents.All(doc => string.IsNullOrEmpty(doc.DocumentId) && string.IsNullOrEmpty(doc.DocumentName) && string.IsNullOrEmpty(doc.DocumentPath)))
                {
                    documents = new List<dynamic>();
                }

                var employeeDetails = new
                {
                    EmployeeId = Convert.ToInt32(employeeData["employeeid"]),
                    EmployeeName = employeeData["employeename"].ToString(),
                    Department = employeeData["department"].ToString(),
                    AadharNumberAsEmployeeId = employeeData["aadharnumberasemployeeid"].ToString(),
                    PhoneNumber = employeeData["phonenumber"].ToString(),
                    AlternatePhoneNumber = employeeData["alterphonenumber"].ToString(),
                    DateOfBirth = employeeData["dateofbirth"].ToString(),
                    AddressByAadhar = employeeData["addressbyaadhar"].ToString(),
                    EmergencyContactPersonName = employeeData["emergencycontactpersonname"].ToString(),
                    EmergencyContactNumber = employeeData["emergencycontactnumber"].ToString(),
                    HealthIssue = employeeData["healthissue"].ToString(),
                    TreatmentUnder = Convert.ToInt32(employeeData["treatmentunder"]),
                    EmployeeCurrentStatus = Convert.ToInt32(employeeData["employeecurrentstatus"]),
                    Documents = documents
                };

                return Ok(employeeDetails);
            }

            return NotFound();
        }



        [HttpPut("updateEmployeeDetails")]
        public IActionResult UpdateEmployeeDetails([FromForm] EmployeeDetailsUpdateModel entity, [FromForm(Name = "files")] IFormFileCollection files)
        {
            try
            {
                var result = _daLayer.UpdateEmployeeDetails(entity, files);

                return Ok(new { Success = result, Message = result ? "Employee details updated successfully." : "Failed to update employee details." });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }



        [HttpGet(nameof(GetAllEmployeeDetails))]
        public string GetAllEmployeeDetails()
        {
            var result = _daLayer.GetAllEmployeeDetails();
            return JsonConvert.SerializeObject(result);
        }


        [HttpPut(nameof(DeleteEmployee))]

        public string DeleteEmployee(DeleteemployeeEntity entity)
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

