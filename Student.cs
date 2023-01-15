using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5BAyala
{
    class Student
    {
        //Variables
        public string nameStudent { get => nameStudent1; private set => nameStudent1 = value; }
        private string ageStudent;
        private string cityStudent;
        private string nameStudent1;
        public string id { get => id1; private set => id1 = value; }
        private string id1;

        public Student()
        {
            ageStudent = "";
            nameStudent1 = "";
            cityStudent = "";
            id1 = "";
        }
        public Student(string name, int age, string city, string id)
        {
            ageStudent = age.ToString();
            nameStudent1 = name;
            cityStudent = city;
            id1 = id;

        }

        public void EditStudentInformation(string name, int age, string city, string id1)
        {
            ageStudent = age.ToString();
            nameStudent1 = name;
            cityStudent = city;
            this.id1 = id;

        }


        public String DisplayStudentInformation()
        {
            return "Student Info:\nStudent Name: " + nameStudent1 + "\nStudent Age: " + ageStudent + "\nStudent live in: " + cityStudent;
        }
    }
}
