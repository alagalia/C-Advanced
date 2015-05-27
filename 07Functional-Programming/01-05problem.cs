using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ClassStudent
{
    class ClassStudent
    {
        private static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("{0} {1} Age: {2}, FacultyNumber: {3}, Phone: {4},\n Email: {5}, GroupNumber: {6}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber, student.Phone, student.Email,
                    student.GroupNumber);
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            //Problem 1. Class Student
            List<Student> allStudents = new List<Student>
            {
                new Student("Marilyn", "Price", 24, 3298, "+089945", "eroseg@abv.bg", new List<int>(), 2),
                new Student("Sara", "Mills", 20, 045217, "+359888888888", "smills0@marketwatch.com", new List<int>(), 3),
                new Student("Mia", "Sole", 25, 653129, "+3598862348", "art@mach.com",new List<int>(), 2),
                new Student("Dennis", "Bennett", 17, 134009,"+359880035","dbennett3z@bv.bg", new List<int>(), 1),
                new Student("Henry","Sullivan",19, 281988, "+359667722", "hsullivan40@flickr.com",new List<int>(),2),
                new Student("Ashley","Cunningham",33, 542354, "+359000000", "acunningham47@qq.com",new List<int>(),1),
                new Student("Bennett","Sullivan",26, 345678, "+359660022", "van40@bv.bg",new List<int>(),4),
                new Student("Annet", "Holder", 29, 15237,"+35922235","haloderz@bv.bg", new List<int>(), 2),
            };

// findall //Problem 2.     Students by Group
            Console.WriteLine("Students from Group 2:");
            List<Student> studentNamesFormGroup2 = allStudents.FindAll(student => student.GroupNumber == 2);
             //OTHER WAY
            var studentQuery = allStudents
                .Where(student => student.GroupNumber == 2)
                .OrderBy(student => student.FirstName);
            foreach (var item in (studentNamesFormGroup2.OrderBy(name => name.FirstName)))
            {
                Console.WriteLine(item.FirstName+" "+item.LastName);
            }
            Console.WriteLine();


// findall //Problem 3.     Students by First and Last Name
            Console.WriteLine("Students which First is before Last Name (alphabetically):");
            foreach (var item in allStudents.FindAll(student => student.FirstName[0]<student.LastName[0]))
            {
                Console.WriteLine(item.FirstName+ " "+ item.LastName);
            }
            Console.WriteLine();
            //OTHERWAY
//Where
            var studentQuer = allStudents
                .Where(student => student.FirstName.ToCharArray()[0] < student.LastName.ToCharArray()[0]);
            foreach (var student in studentQuery)
            {
            Console.WriteLine("{0} {1}",student.FirstName, student.LastName);
            }

 // FindAll
            //Problem 4.	Students by Age
            Console.WriteLine("Students by Age between 18 and 24:");
            var studentsByAge18to24 = allStudents.FindAll(student => student.Age >= 18 && student.Age <= 24);
            foreach (var item in studentsByAge18to24)
            {
                Console.WriteLine(item.FirstName+ " "+item.LastName+" "+ item.Age);
            }
            Console.WriteLine();

//OrderBy
            //Problem 5.    Sort Students
            Console.WriteLine("Sort Students ascending:");
            foreach (var item in allStudents.OrderBy(student => student.FirstName))
            {
                Console.WriteLine(item.FirstName+ " "+item.LastName);
            }
            Console.WriteLine();

//OrderBy LINQ syntax
            Console.WriteLine("Sort Students ascending (used LINQ query syntax):");
            var sortedStudentAscendingQUERY =
                from student in allStudents
                orderby student.FirstName
                select student;
            PrintStudents(sortedStudentAscendingQUERY.ToList());

//OrderByDescending
            Console.WriteLine("Sort Students descending :");
            var sortedStudentDescending= new List<Student>() ;
            foreach (var item in allStudents.OrderByDescending(student => student.FirstName))
            {
                sortedStudentDescending.Add(item);
                Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            }
            Console.WriteLine();

//OrderByDescending LINQ syntax
            Console.WriteLine("Sort Students descending (used LINQ query syntax):");
            var ortedStudentDescendingQUERY =
                from student in allStudents
                orderby student.FirstName descending
                select student;
            foreach (var item in ortedStudentDescendingQUERY)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();
        }
    }
}
