using System.Collections.Generic;
using System.Data;
using System;
using EmployeeDetails.DBL;
using static EmployeeDetails.Model.Employeedetails;

namespace EmployeeDetails.DAL
{
    public class EmployeeDetailsService
    {
        public bool SaveEmployeeDetails(EmployeeDetailsEntity entity)
        {
            List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
            DbLayer manageSQL = new DbLayer();
            sqlParameters.Add(new KeyValuePair<string, string>("@inemployeeid", Convert.ToString(entity.EmployeeId)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemployeename", entity.EmployeeName));
            sqlParameters.Add(new KeyValuePair<string, string>("@indepartment", entity.Department));
            sqlParameters.Add(new KeyValuePair<string, string>("@inaadharnumberasemployeeid",entity.AadharNumber));
            sqlParameters.Add(new KeyValuePair<string, string>("@inphonenumber", entity.PhoneNumber));
            sqlParameters.Add(new KeyValuePair<string, string>("@inalterphonenumber", entity.AlternateNumber));
            sqlParameters.Add(new KeyValuePair<string, string>("@indateofbirth", entity.DateOfBirth));
            sqlParameters.Add(new KeyValuePair<string, string>("@inaddressbyaadhar", entity.Address));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactpersonname", entity.EmergencyContactPerson));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactnumber", entity.EmergencyContactNumber));
            //sqlParameters.Add(new KeyValuePair<string, string>("@inrelation", Convert.ToString (entity.Relation)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inhealthissue", entity.HealthIssue));
            //sqlParameters.Add(new KeyValuePair<string, string>("@inbeforetreatment", entity.BeforeTreatment));
            //sqlParameters.Add(new KeyValuePair<string, string>("@inaftertreatment", entity.AfterTreatment));
            sqlParameters.Add(new KeyValuePair<string, string>("@intreatmentunder", Convert.ToString (entity.TreatmentUnder)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemployeecurrentstatus", Convert.ToString (entity.EmployeeCurrentStatus)));
            sqlParameters.Add(new KeyValuePair<string, string>("@indocument", entity.Document));
            return manageSQL.InsertData("insertemployedetails", sqlParameters);
        }
        public bool DeleteEmployee(UpdateemployeeEntity entity)
        {
            try
            {
                DbLayer manageSQL = new DbLayer();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@inemployeeid", Convert.ToString(entity.EmployeeId)));
                var result = manageSQL.UpdateValues("deleteemployee", sqlParameters);
                return result;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError(ex.Message);
                return false;
            }

        }
        public DataSet GetAllEmployeeDetails()
        {
            DbLayer manageSQL = new DbLayer();
            return manageSQL.GetDataSetValues("getemployedetails");
        }

    }
}
