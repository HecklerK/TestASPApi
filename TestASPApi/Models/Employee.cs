namespace TestASPApi.Models
{
    public class Employee
    {
        public int Id {  get; set; }
        public string Email {  get; set; }
        public int Gender {  get; set; }
        public List<Department> Departments {  get; set; } = new List<Department>();
    }
}
