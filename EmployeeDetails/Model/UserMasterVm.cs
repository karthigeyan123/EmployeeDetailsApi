namespace EmployeeDetails.Model
{
    public class UserMasterVm
    {
        public class UserMasterEntity
        {
            public int Userid { get; set; }

            public string Username { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public int flag { get; set; }

            public string Useraadharno { get; set; }
            public string Useruniquecode { get; set; }

            public int Employeeid { get; set; }
        }

        public class UserMasterByEmailEntity
        {
            public string Email { get; set; }
        }
    }
}
