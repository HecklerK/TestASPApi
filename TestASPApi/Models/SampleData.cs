namespace TestASPApi.Models
{
    public static class SampleData
    {
        public static void Initialize(EntityContext context)
        {
            if (!context.Employees.Any())
            {
                Employee test = new Employee
                {
                    Email = "test@mail.mail",
                    Gender = 0,

                };
                Employee test1 = new Employee
                {
                    Email = "test1@mail.com",
                    Gender = 1,

                };
                Employee test2 = new Employee
                {
                    Email = "test2@mail.ru",
                    Gender = 0,

                };
                Employee test3 = new Employee
                {
                    Email = "test3@yan.com",
                    Gender = 0,

                };
                Employee test4 = new Employee
                {
                    Email = "test4@mal.mail",
                    Gender = 1,

                };
                context.Employees.AddRange(test, test1, test2, test3, test4);
                if (!context.Departments.Any())
                {
                    Department developer = new Department
                    {
                        Name = "Developer"
                    };
                    Department department = new Department
                    {
                        Name = "department"
                    };
                    context.Departments.AddRange(developer, department);
                    developer.Employees.Add(test);
                    developer.Employees.Add(test1);
                    developer.Employees.Add(test4);
                    department.Employees.Add(test2);
                    department.Employees.Add(test3);
                }
            }
            context.SaveChanges();
        }
    }
}
