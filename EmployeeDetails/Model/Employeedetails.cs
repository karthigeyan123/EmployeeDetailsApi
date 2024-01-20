namespace EmployeeDetails.Model
{
    public class Employeedetails
    {
<<<<<<< HEAD
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
               // public int Relation { get; set; }
                public string HealthIssue { get; set; }
                //public string BeforeTreatment { get; set; }
               // public string AfterTreatment { get; set; }
                public int TreatmentUnder { get; set; }
                public int EmployeeCurrentStatus { get; set; }
                public string? Document { get; set; }
=======
        public class EmployeeDetailsModel
        {
            public string EmployeeName { get; set; }
            public string Department { get; set; }
            public string AadharNumber { get; set; }
            public string PhoneNumber { get; set; }
            public string AlternateNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string Address { get; set; }
            public string EmergencyContactPerson { get; set; }
            public string EmergencyContactNumber { get; set; }
            public string HealthIssue { get; set; }
            public int TreatmentUnder { get; set; }
            public int EmployeeCurrentStatus { get; set; }
            public List<DocumentModel> Documents { get; set; }
>>>>>>> 5d3be88dfd2a6cd78f6ff71abb5f43a2f759b3cb
        }

        public class DocumentModel
        {
            public string DocumentName { get; set; }
            public string DocumentPath { get; set; }
        }
        public class EmployeeDetailsUpdateModel
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
            public string HealthIssue { get; set; }
            public int TreatmentUnder { get; set; }
            public int EmployeeCurrentStatus { get; set; }
            public List<DocumentModelUpdate> Documents { get; set; }
        }

        public class DocumentModelUpdate
        {
            public string DocumentName { get; set; }
            public string DocumentPath { get; set; }
        }


        public class UpdateemployeeEntity
        {
            public int EmployeeId { get; set; }
        }
    }
}
