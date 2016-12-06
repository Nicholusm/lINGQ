using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //Scores and Words
            int[] scores = { 20, 50, 12, 20, 78, 63, 35, 78 ,80,85,96,87};
            string[] words = { "humpty", "dumpty", "set", "on", "a", "wall" };


            //IEnumerable<int> scoreQuery = from score in scores where score >= 80 select score;
            IEnumerable<int> scoreQuery = from score in scores select score;
            IEnumerable<string> query = from word in words where word.Length == 3 select word;

            var prosNums = from n in scores
                           orderby n
                           select n;

            //Department List
            List<DepartmentClass> departments = new List<DepartmentClass>();
            departments.Add(new DepartmentClass { DepartmentId = 1, Name = "Account" });
            departments.Add(new DepartmentClass { DepartmentId = 2, Name = "Sales" });
            departments.Add(new DepartmentClass { DepartmentId = 3, Name = "Marketing" });

            //Employees list
            List<EmployeeClass> employees = new List<EmployeeClass>();
            employees.Add(new EmployeeClass {DepartmentId=1,EmployeeId=1,EmployeeName="Nicholas"});
            employees.Add(new EmployeeClass { DepartmentId = 2, EmployeeId = 2, EmployeeName = "Miley" });
            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 3, EmployeeName = "Benjamin" });

            //Student List
            List<Student> students = new List<Student>();
            students.Add(new Student { ID = 1001, Name = "Nicholas", Surname = "Maropeng", Gender = "Male", Age = 20 });
            students.Add(new Student { ID = 1002, Name = " kamogelo", Surname = "Mpete", Gender = "Female", Age = 26 });
            students.Add(new Student { ID = 1003, Name = "Tebogo", Surname = "Msiza", Gender =    "Male", Age = 35 });
            students.Add(new Student { ID = 1004, Name = "Amogelang", Surname = "Molapo", Gender = "Female", Age = 36 });
            students.Add(new Student { ID = 1005, Name = "Kagiso", Surname = "Mpatlanyane", Gender = "Male", Age = 45 });
            students.Add(new Student { ID = 1006, Name = "Kamogelo", Surname = "Dichabe", Gender = "Male", Age = 18});
            students.Add(new Student { ID = 1001, Name = "Nicholas", Surname = "Maropeng", Gender = "Male", Age = 20 });
            students.Add(new Student { ID = 1002, Name = " kamogelo", Surname = "Mpete", Gender = "Female", Age = 26 });
            students.Add(new Student { ID = 1003, Name = "Tebogo", Surname = "Msiza", Gender = "Male", Age = 35 });
            students.Add(new Student { ID = 1004, Name = "Amogelang", Surname = "Molapo", Gender = "Female", Age = 36 });
            students.Add(new Student { ID = 1005, Name = "Kagiso", Surname = "Mpatlanyane", Gender = "Male", Age = 45 });
            students.Add(new Student { ID = 1006, Name = "Kamogelo", Surname = "Dichabe", Gender = "Male", Age = 18 });

            //Grouping students
            var groupedstudents = from e in students
                                  group e by e.Gender into eff
                                  select new
                                  {
                                      students = eff.LastOrDefault;

                                  };


            var list = (from e in employees
                        join d in departments on e.DepartmentId equals d.DepartmentId
                        select new 
                        {
                            EmployeeName = e.EmployeeName,
                            DepartmentName = d.Name,
                            DepartmentID = e.DepartmentId

                        });

            IEnumerable<Student> querys = from student in students select student;
            //Employees
            foreach (var  e in list)
            {
                Console.WriteLine("Employee Name = {0}, Deapartment Name = {1}, DepartMentId = {2}",e.EmployeeName,e.DepartmentName,e.DepartmentID);

            }

            //Scores
            foreach (var item in scoreQuery)
            {
                Console.WriteLine(item + "");
           
            }

            //Words
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            //Numbers in Order
            Console.WriteLine("Numbers in order!!");
            foreach (var item in prosNums)
            {
                Console.Write(item + "\n");

            }

            //Students
            foreach (var item in querys)
            {
                Console.WriteLine("ID : {0} Name : {1} Surname : {2} Gender : {3} Age:{4}",item.ID,item.Name,item.Surname,item.Gender,item.Age);
            }
            Console.ReadLine();
        }
    }
}
