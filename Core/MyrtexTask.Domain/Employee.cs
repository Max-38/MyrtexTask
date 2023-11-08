namespace MyrtexTask.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Department { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public decimal Salary { get; set; }

        public Employee (Guid id, string department, string fullName, DateTime dateOfBirth, DateTime dateOfEmployment, decimal salary)
        {
            Id = id;
            Department = department;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            DateOfEmployment = dateOfEmployment;
            Salary = salary;
        }
    }
}
