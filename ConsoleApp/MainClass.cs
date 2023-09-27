using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class MainClass
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("\t\t\t\t\tWelcome to Assignment 3 (ADO.NET)\n");
            Console.WriteLine("Work by Dnyaneshwar Chaudhary");

            while (true)
            {
                
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Edit Course");
                Console.WriteLine("4. Edit Student");
                Console.WriteLine("5. Search Course");
                Console.WriteLine("6. Search Student");   
                Console.WriteLine("7. Delete Course");
                Console.WriteLine("8. Delete Student");
                Console.WriteLine("9. Show All Courses");
                Console.WriteLine("10. Show All Students");
                Console.WriteLine("11. Show Students in a Particular Course");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1: //Add Course

                            Console.WriteLine("Enter the Course Name to add : ");
                            string coursename = Console.ReadLine();

                            Console.WriteLine("Enter the Course Start Date (YYYY-MM_-DD) to Add : ");
                            string date = Console.ReadLine();

                            Console.WriteLine("Enter the Course Trainer : ");
                            string trainer = Console.ReadLine();

                            CourseDatabase.AddCourse(coursename, date,trainer);

                            break;

                        case 2: //Add Student

                            Console.WriteLine("Enter the Student Name to add : ");
                            string studentname = Console.ReadLine();

                            Console.WriteLine("Enter the Student Year of Pass (YYYY) : ");
                            int YearOfPass = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the Course ID : ");
                            int courseid = Convert.ToInt32(Console.ReadLine());

                            StudentDatabase.AddStudent(studentname, YearOfPass, courseid);

                            break;

                        case 3: //Edit Course

                            Console.WriteLine("Enter the Trainer Name : ");
                            string trainer1 = Console.ReadLine();

                            CourseDatabase.EditCourse(trainer1);

                            break;

                        case 4: //Edit Student

                            Console.WriteLine("Enter the Student ID : ");
                            int stu_id = Convert.ToInt32(Console.ReadLine());

                            StudentDatabase.EditStudent(stu_id);

                            break;

                        case 5: //Search Course

                            CourseDatabase.SearchCourse();

                            break;

                        case 6: //Search Student

                            StudentDatabase.SearchStudent();

                            break;

                        case 7: //Remove Course

                            Console.WriteLine("Enter the Course Trainer : ");
                            string trainer_name = Console.ReadLine();

                            CourseDatabase.RemoveCourse(trainer_name);

                            break;

                        case 8: //Remove Student

                            Console.WriteLine("Enter the Student Name : ");
                            string stu_name = Console.ReadLine();

                            StudentDatabase.RemoveStudent(stu_name);

                            break;

                        case 9: //Show All Courses

                            CourseDatabase.ShowCourses();

                            break;

                        case 10: //Show All Students

                            StudentDatabase.ShowStudents();

                            break;

                        case 11: //Students in a Particular Course

                            Console.WriteLine("Enter the Course ID : ");
                            int coursid = Convert.ToInt32(Console.ReadLine());

                            CourseDatabase.CourseStudents(coursid);

                            break;

                        case 0: // Exit

                            Environment.Exit(0);

                            break;

                        default:

                            Console.WriteLine("Invalid choice. Please try again.");

                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
