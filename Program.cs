/*
 * Program ID: StudentRecord
 * 
 * Prupose: To create a DB of students
 * 
 * Revision history:
 * Bryan Ayala November 29,2022
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5BAyala
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            bool keepGoing;
            string option;
            string id;
            string name;
            int age;
            string city;
            Student studentInfo;
            bool enteredCatch;
            // string option;

            //initialize variables
            keepGoing = true;
            option = " ";
            id = "";
            name = " ";
            age = 0;
            city = " ";
            enteredCatch = false;

            List<Student> storeData = new List<Student>();
            var studentDisplay = new Student();

            Console.WriteLine("This program create and record information for a stundent");

            //Menu of options:

            do
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine();
                Console.WriteLine("A. Add a new student\nB. edit an existing student record\nC. Display the name, age, and address city of the student(if one already exists)\nD. Exit the program");
                Console.WriteLine("");
                Console.WriteLine("Please choice one of the above options: ");
                option = Console.ReadLine();
                Console.WriteLine();

                if (option == "A")
                {
                    //ID input
                    Console.WriteLine("Enter the Student ID (e.g. 1 , 2 , 3 , 4): ");

                    id = Console.ReadLine();

                    //Validation if the student already exist
                    var studentValidation = storeData.Where(x => x.id == id).FirstOrDefault();

                    if (studentValidation!=null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error. Student info already exist");
                    }

                    else if (studentValidation==null)
                    {
                        name = StudentName();

                        age = StudentAge();

                        city = StudentCity();

                        studentInfo = new Student(name,age,city,id);

                        storeData.Add(studentInfo);

                        Console.WriteLine();
                        Console.WriteLine("The student info saved correctly!!!");
                        Console.WriteLine();
                    }

                    
                }
                
                else if (option == "B")
                {
                    Console.WriteLine("Please Enter the unique identifier (ID) of the student: ");
                    id = Console.ReadLine();
                    Console.WriteLine();

                    //Validation if the student already exist
                    var studentValidation = storeData.Where(x => x.id == id).FirstOrDefault();

                    if (studentValidation==null)
                    {
                        Console.WriteLine("Error. No Student Record Exist");

                    }
                    else if(studentValidation!=null)
                    {

                        Console.WriteLine("Record founded\nThe actual information is:");

                        Console.WriteLine(studentValidation.DisplayStudentInformation());
                        Console.WriteLine();
                        Console.WriteLine("If you want to continue editing Enter 'Y' ; otherwise Enter 'N'");
                        option = Console.ReadLine();

                        if (option == "Y")
                        {

                            Console.WriteLine();
                            Console.WriteLine("The new information for the Student is: ");
                            Console.WriteLine();

                            Console.WriteLine("Please Enter the unique identifier (ID) of the student: ");
                            id = Console.ReadLine();
                            Console.WriteLine();
                            name = StudentName();
                            age = StudentAge();
                            city = StudentCity();

                            studentValidation.EditStudentInformation(name, age, city,id);

                            Console.WriteLine();
                            Console.WriteLine("The Record was edit");
                        }
                    }

                }

                else if (option == "C")
                {
                    Console.WriteLine("To display de Student info follow the next instructions:\nIf you want to return at Main Menu Enter 'QUIT' ");
                    name = StudentName();

                    //Validation if the student already exists
                    if (name != "QUIT")
                    {
                        while (keepGoing)
                        {
                            try
                            {

                                studentDisplay = storeData.Where(x => x.nameStudent == name).FirstOrDefault();

                                if (studentDisplay == null)
                                {
                                    throw new FormatException();

                                }
                                enteredCatch = false;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Error. No Student Record Exist. Try again or Enter QUIT to return at Main Menu:");
                                name = StudentName();
                                enteredCatch = true;
                            }

                            if (!enteredCatch)
                            {
                                keepGoing = false;
                            }

                            if(name=="QUIT")
                            {
                                keepGoing = false;
                            }

                        }
                    }
                    //Normalize variable
                    keepGoing = true;

                    if(name!="QUIT")
                    {
                        Console.WriteLine();
                        Console.WriteLine(studentDisplay.DisplayStudentInformation()); 

                        Console.WriteLine();
                        
                       
                    }


                }

                else if (option == "D")
                {

                    Console.WriteLine();
                    Console.WriteLine("You are leaving the program\nBye!!!");

                    keepGoing = false;

                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR. The Entered option isn't correct. Try again.");
                }

            } while (keepGoing);

            Console.ReadKey();

        }

        static String StudentName()
        {
            //variables
            string name;


            //initialize variables
            name = " ";

            //name input
            Console.WriteLine("Enter the Student Name: ");

            name = Console.ReadLine();

            return name;
        }

        static int StudentAge()
        {

            //variables
            bool keepGoing;
            int age;
            string ageString;
            bool enteredTheCatch;

            //initialize variables
            keepGoing = true;
            age = 0;
            enteredTheCatch = false;

            //age input
            Console.WriteLine("Enter the Student age: ");
            ageString = Console.ReadLine();

            //Validation of the age
            while (keepGoing)
            {
                try
                {
                    age = int.Parse(ageString);
                    if (age < 1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    enteredTheCatch = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR. The entered age isn't valid. Try again:");
                    Console.WriteLine("Enter Student Age:");
                    ageString = Console.ReadLine();
                    enteredTheCatch = true;
                }

                if (enteredTheCatch == false)
                {
                    keepGoing = false;
                }
            }

            //normalize variable
            keepGoing = true;

            return age;

        }

        static String StudentCity()
        {
            string city;

            //City input
            Console.WriteLine("Enter in what city live the Student: ");

            city = Console.ReadLine();

            return city;
        }

    }
}
