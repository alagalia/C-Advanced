using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06FilterStudentsEmailDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> allStudents = new List<Student>
            {
                new Student("Marilyn", "Price", 24, 32981400, "+028994566", "eroseg@abv.bg", new List<int>{2,5,3,3,2}, "Alfa"),
                new Student("Sara", "Mills", 20, 14521417, "+3592888888888", "smills0@marketwatch.com", new List<int>{4,3,4,5,4}, "Beta"),
                new Student("Mia", "Sole", 25, 65311429, "+359 28862348", "art@mach.com",new List<int>{6,4,3,4,5}, "Omega"),
                new Student("Dennis", "Bennett", 17, 13401409,"+359880035","dbennett3z@abv.bg", new List<int>{2,4,3,4,2}, "Zed"),
                new Student("Henry","Sullivan",19, 28198800, "+359667722", "hsullivan40@flickr.com",new List<int>{3,4,3,4,6},"Alfa"),
                new Student("Ashley","Cunningham",33, 54235400, "+359000000", "acunningham47@qq.com",new List<int>{6,4,3,4,5},"Omega"),
                new Student("Bennett","Sullivan",26, 34567800, "+359660022", "van40@abv.bg",new List<int>{4,3,4,5,4},"Beta"),
                new Student("Annet", "Holder", 29, 1523700,"+35922235","haloderz@abv.bg", new List<int>{2,5,3,3,2},"Alfa"),
            };
//where LINQ
            //Problem 6.	Filter Students by Email Domain
            var findStudentByMail =
            from student in allStudents
            where student.Email.Contains("@abv.bg")
            select student;
            //OTHER WAY
            var studentQuery = allStudents
                .Where(student => student.Email.Contains("abv"));

//where LINQ
            //Problem 7.	Filter Students by Phone from Sofia
            var findStudentBySofiaPhone =
                from student in allStudents
                where student.Phone.Contains("+02") || student.Phone.Contains("+3592") || student.Phone.Contains("+359 2")
                select student;
            //OTHER WAY
            var studentQuer = allStudents
                .Where(student => student.Phone.Contains("+3592") || student.Phone.Contains("02") || student.Phone.Contains("+359 2"));

//Select    Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new anonymous class that                   holds { FullName + Marks}.
             //Problem 8.	Excellent Students
            Console.WriteLine("Excellent Students");
            var excelenteStudent = (allStudents.Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks })).Where(w => w.Marks.Contains(6));
            foreach (var item in excelenteStudent)
            {
                Console.Write(item.FullName + " ");
                    foreach (var item1 in item.Marks)
                    {
                        Console.Write(item1 + " ");
                    }
                    Console.WriteLine();
            }
            Console.WriteLine();

            //OTHER WAY
            var studentQu = allStudents
                .Where(student => student.Marks.Contains(6))
                .Select(student => new { student.FirstName, student.LastName, student.Marks });


//FindAll   Problem 9.	Weak Students
            var weekStudents = new List<Student>();
            foreach (var item in allStudents.FindAll(x => x.Marks.Contains(2)))
            {
                if (item.Marks.ToList().CountSpecifiedElement(2)==2)//extention method CountSpecifiedElement (за обект List и връща Int)
                {
                    weekStudents.Add(item);
                }
            }

            //OTHER WAY
            var studentQ= allStudents
               .Where(student => student.Marks.Count(mark => mark == 2) == 2)
               .Select(student => new { student.FirstName, student.LastName, student.Marks });

//FinfAll
            //Problem 10.	Students Enrolled in 2014
            var students2014 = new List<Student>();
            Console.WriteLine("Students Enrolled in 2014");
            foreach (var item in allStudents.FindAll(student => student.FacultyNumber.ToString().Substring(4, 2) == "14"))
            {
                students2014.Add(item);
                Console.WriteLine(item.FirstName + " " + item.LastName + "-> FacultyNumber:" + item.FacultyNumber);
            }
//group LINQ            Add a GroupName property to Student. Write a program that extracts all students grouped by GroupName and then prints
//                      them on the console. Print all group names along with the students in each group. Use the "group by into" LINQ                               operator.
            //Problem 11.	* Students by Groups
            var studentByGroup =
                from student in allStudents
                group student by student.GroupName;

            foreach (var student in studentByGroup)
            {
                Console.WriteLine("Group name:"+student.Key);
                foreach (var item1 in student)
                {
                    Console.WriteLine(item1.FirstName);
                } 
                Console.WriteLine();
            }
            //OTHERWAY
            var studentQueryy =allStudents.
                Select(student => new { student.FirstName, student.LastName, GroupNumber = student.GroupName })
                .GroupBy(student => student.GroupNumber)
                .OrderBy(studentGroup => studentGroup.Key);

        }
    }
}
