namespace EmployeeDetails.Model
{
    public class Employeedetails
    {
        public class EmployeeDetailsEntity
            {
                public int EmployeeId { get; set; }
                public string EmployeeName { get; set; }
                public string Department { get; set; }
                public string AadharNumber { get; set; }
                public string PhoneNumber { get; set; }
                public string AlternateNumber { get; set; }
                public string DateOfBirth { get; set; }
                public string Address { get; set; }
                public string EmergencyContactPerson { get; set; }
                public string EmergencyContactNumber { get; set; }
                public int Relation { get; set; }
                public string HealthIssue { get; set; }
                public string BeforeTreatment { get; set; }
                public string AfterTreatment { get; set; }
                public int TreatmentUnder { get; set; }
                public int EmployeeCurrentStatus { get; set; }
                public string? Document { get; set; }
        }
        public class UpdateemployeeEntity
        {
            public int EmployeeId { get; set; }
        }
    }
}
