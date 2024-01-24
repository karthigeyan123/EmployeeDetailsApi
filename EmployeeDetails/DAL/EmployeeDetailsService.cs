using System.Collections.Generic;
using System.Data;
using System;
using EmployeeDetails.DBL;
using static EmployeeDetails.Model.Employeedetails;
using Newtonsoft.Json;

namespace EmployeeDetails.DAL
{
    public class EmployeeDetailsService
    {
        public bool SaveEmployeeDetails(EmployeeDetailsModel entity, IFormFileCollection files)
        {
            try
            {
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                DbLayer manageSQL = new DbLayer();
                sqlParameters.Add(new KeyValuePair<string, string>("@inemployeename", entity.EmployeeName));
                sqlParameters.Add(new KeyValuePair<string, string>("@indepartment", entity.Department));
                sqlParameters.Add(new KeyValuePair<string, string>("@inaadharnumberasemployeeid", entity.AadharNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@inphonenumber", entity.PhoneNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@inalterphonenumber", entity.AlternateNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@indateofbirth", entity.DateOfBirth));
                sqlParameters.Add(new KeyValuePair<string, string>("@inaddressbyaadhar", entity.Address));
                sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactpersonname", entity.EmergencyContactPerson));
                sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactnumber", entity.EmergencyContactNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@inhealthissue", entity.HealthIssue));
                sqlParameters.Add(new KeyValuePair<string, string>("@intreatmentunder", Convert.ToString(entity.TreatmentUnder)));
                sqlParameters.Add(new KeyValuePair<string, string>("@inemployeecurrentstatus", Convert.ToString(entity.EmployeeCurrentStatus)));
                if (files != null && files.Count > 0)
                {
                    var documents = new List<DocumentModel>();

                    foreach (var file in files)
                    {
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        var filePath = Path.Combine(Globalvariables.FolderPath, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        documents.Add(new DocumentModel
                        {
                            DocumentName = file.FileName,
                            DocumentPath = filePath
                        });
                    }

                    sqlParameters.Add(new KeyValuePair<string, string>("@indocument", JsonConvert.SerializeObject(documents)));
                }
                else
                {
                    sqlParameters.Add(new KeyValuePair<string, string>("@indocument", JsonConvert.SerializeObject(new List<DocumentModel>())));
                }
                return manageSQL.InsertData("insertemployedetails", sqlParameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateEmployeeDetails(EmployeeDetailsUpdateModel entity, IFormFileCollection files)
        {
            try
            {
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                DbLayer manageSQL = new DbLayer();

                // Add parameters to the list
                sqlParameters.Add(new KeyValuePair<string, string>("@inemployeeid", Convert.ToString(entity.EmployeeId)));
                sqlParameters.Add(new KeyValuePair<string, string>("@inemployeename", entity.EmployeeName));
                sqlParameters.Add(new KeyValuePair<string, string>("@indepartment", entity.Department));
                sqlParameters.Add(new KeyValuePair<string, string>("@inaadharnumberasemployeeid", entity.AadharNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@inphonenumber", entity.PhoneNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@inalterphonenumber", entity.AlternateNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@indateofbirth", entity.DateOfBirth));
                sqlParameters.Add(new KeyValuePair<string, string>("@inaddressbyaadhar", entity.Address));
                sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactpersonname", entity.EmergencyContactPerson));
                sqlParameters.Add(new KeyValuePair<string, string>("@inemergencycontactnumber", entity.EmergencyContactNumber));
                sqlParameters.Add(new KeyValuePair<string, string>("@inhealthissue", entity.HealthIssue));
                sqlParameters.Add(new KeyValuePair<string, string>("@intreatmentunder", Convert.ToString(entity.TreatmentUnder)));
                sqlParameters.Add(new KeyValuePair<string, string>("@inemployeecurrentstatus", Convert.ToString(entity.EmployeeCurrentStatus)));
                if (files != null && files.Count > 0)
                {
                    var documents = new List<DocumentModel>();

                    foreach (var file in files)
                    {
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        var filePath = Path.Combine(Globalvariables.FolderPath, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        documents.Add(new DocumentModel
                        {
                            DocumentName = file.FileName,
                            DocumentPath = filePath
                        });
                    }

                    sqlParameters.Add(new KeyValuePair<string, string>("@indocument", JsonConvert.SerializeObject(documents)));
                }
                else
                {
                    sqlParameters.Add(new KeyValuePair<string, string>("@indocument", JsonConvert.SerializeObject(new List<DocumentModel>())));
                }
                return manageSQL.InsertData("update_employeedetails_with_document", sqlParameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public bool DeleteEmployee(DeleteemployeeEntity entity)
        {
            try
            {
                DbLayer manageSQL = new DbLayer();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@in_employee_id", Convert.ToString(entity.EmployeeId)));
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
