namespace ST10090990_Part2.Models
{
    public class Employees
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePassword { get; set; }

        public Employees()
        {

        }

        public Employees(string employeeID, string employeeName, string employeePassword)
        {
            EmployeeID= employeeID;
            EmployeeName= employeeName;
            EmployeePassword= employeePassword;
        }
    }
}

