using System;

namespace NCCTestProject.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public string Gift { get; set; }
    }
}