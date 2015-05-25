/* Create a class StudentSpecialty that holds specialty name and faculty number. Create a list of student specialties, where each specialty corresponds to a certain student (via the faculty number). Print all student names alphabetically along with their faculty number and specialty name. Use the "join" LINQ operator. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
namespace _12StudentsSpecialties
{
    class Program
    {
        class FacNumName
        {
            public int FacNum { get; set;}
            public string name { get; set; }
        }

        class StudentSpecialtyClass
        {
            public string SpecialtyName { get; set; }
            public int FacultyNumber { get; set; }
            
        }
        
        static void Main(string[] args)
        {
            List<StudentSpecialtyClass> allStudent = new List<StudentSpecialtyClass>
            { 
                new StudentSpecialtyClass {SpecialtyName = "Web Developer", FacultyNumber= 203314},
                new StudentSpecialtyClass {SpecialtyName = "Web Developer", FacultyNumber= 203114},
                new StudentSpecialtyClass {SpecialtyName = "PHP Developer",FacultyNumber=  203814},
                new StudentSpecialtyClass {SpecialtyName = "PHP Developer", FacultyNumber= 203914},
                new StudentSpecialtyClass {SpecialtyName = "QA Engineer", FacultyNumber= 203314},
                new StudentSpecialtyClass {SpecialtyName = "Web Developer", FacultyNumber= 203914},
            };

            List <FacNumName> nameForJoin = new List <FacNumName>
            {
                new FacNumName { FacNum = 215314, name= "Milena Kirova"},
                new FacNumName { FacNum =203114, name= "Stefan Popov"},
                new FacNumName { FacNum =203314, name= "Asya Manova"},
                new FacNumName { FacNum =203914,name= "Diana Petrova"},
                new FacNumName { FacNum =203814,name= "Ivan Ivanov"}
            };

            var result =
                from n in nameForJoin
                join a in allStudent on n.FacNum equals a.FacultyNumber
                select new { n.name, n.FacNum, a.SpecialtyName };

            var sorted = result.OrderBy(x => x.name);

            foreach (var item in sorted)
            {
                Console.WriteLine(item.name+ " "+item.FacNum+" "+ item.SpecialtyName);  
            }
        }
    }
}
