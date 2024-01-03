namespace EmployeeDetails.Model
{
    public class Employeedetails
    {
        public class EmployeeDetailsEntity
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string Department { get; set; }
            public int AadharNumber { get; set; }
            public int PhoneNumber { get; set; }
            public int AlternateNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string Address { get; set; }
            public string EmergencyContactPerson { get; set; }
            public int EmergencyContactNumber { get; set; }
            public string Relation { get; set; }
            public string HealthIssue { get; set; }
            public string BeforeTreatment { get; set; }
            public string AfterTreatment { get; set; }
            public string TreatmentUnder { get; set; }
            public string EmployeeCurrentStatus { get; set; }
            public string Document { get; set; }
        }
    }
}
