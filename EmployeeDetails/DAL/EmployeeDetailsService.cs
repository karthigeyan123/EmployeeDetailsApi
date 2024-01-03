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
            sqlParameters.Add(new KeyValuePair<string, string>("@inaadharnumberasemployeeid", Convert.ToString(entity.AadharNumber)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inphonenumber", Convert.ToString(entity.PhoneNumber)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inalterphonenumber", Convert.ToString(entity.AlternateNumber)));
            sqlParameters.Add(new KeyValuePair<string, string>("@indateofbirth", entity.DateOfBirth));
            sqlParameters.Add(new KeyValuePair<string, string>("@inaddressbyaadhar", entity.Address));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactpersonname", entity.EmergencyContactPerson));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactnumber", Convert.ToString(entity.EmergencyContactNumber)));
            sqlParameters.Add(new KeyValuePair<string, string>("@inrelation", entity.Relation));
            sqlParameters.Add(new KeyValuePair<string, string>("@inhealthissue", entity.HealthIssue));
            sqlParameters.Add(new KeyValuePair<string, string>("@inbeforetreatment", entity.BeforeTreatment));
            sqlParameters.Add(new KeyValuePair<string, string>("@inaftertreatment", entity.AfterTreatment));
            sqlParameters.Add(new KeyValuePair<string, string>("@intreatmentunder", entity.TreatmentUnder));
            sqlParameters.Add(new KeyValuePair<string, string>("@inemployeecurrentstatus", entity.EmployeeCurrentStatus));
            sqlParameters.Add(new KeyValuePair<string, string>("@indocument", entity.Document));
            return manageSQL.InsertData("insertemployedetails", sqlParameters);
        }
        public DataSet GetAllEmployeeDetails()
        {
            DbLayer manageSQL = new DbLayer();
            return manageSQL.GetDataSetValues("getemployedetails");
        }
    }
}
