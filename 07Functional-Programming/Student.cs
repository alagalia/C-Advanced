using System.Collections.Generic;
namespace _01ClassStudent
{
    public class Student
    {
        public Student(string FirstName, string LastName, int Age, int FacultyNumber, string Phone, string Email, IList<int> Marks, int GroupNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.FacultyNumber = FacultyNumber;
            this.Phone = Phone;
            this.Email = Email;
            this.Marks = Marks;
            this.GroupNumber = GroupNumber;
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<int> Marks { get; set; }
        public int GroupNumber { get; set; }
    }
}
