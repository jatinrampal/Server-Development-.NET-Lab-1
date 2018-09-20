using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //removeAll();
            enrollStudentToCourse();
            enrollStudentToCourse();
            displayCourseEnrollmentList();
            displayStudentCourses();
            displayCourseStudents();
            dropStudentFromCourse();
        }

        private static void enrollStudentToCourse()
        {
            
            Console.Write("Student Number: ");
            string sNumber = Console.ReadLine();

            Console.Write("Course Code: ");
            string cCode = Console.ReadLine();

            using (EDModelContainer db = new EDModelContainer())
            {
                Student student = db.Students.Where(s => s.StudentNum == sNumber).First();
                Course course = db.Courses.Where(c => c.CourseCode == cCode).First();

                course.Students.Add(student);
                db.SaveChanges();
            }


        }

        private static void dropStudentFromCourse()
        {

            Console.Write("Student Number: ");
            string sNumber = Console.ReadLine();

            Console.Write("Course Code: ");
            string cCode = Console.ReadLine();

            using (EDModelContainer db = new EDModelContainer())
            {
                Student student = db.Students.Where(s => s.StudentNum == sNumber).First();
                Course course = db.Courses.Where(c => c.CourseCode == cCode).First();

                course.Students.Remove(student);
                db.SaveChanges();
            }


        }


        private static void displayStudentCourses()
        {

            Console.Write("Student Number: ");
            string sNumber = Console.ReadLine();

            using (EDModelContainer db = new EDModelContainer())
            {
                Student student = db.Students.Where(s => s.StudentNum == sNumber).First();

                Console.WriteLine($" {student.FirstName}  {student.LastName}");
                List<Course> courseList = student.Courses.ToList();

                foreach(Course c in courseList)
                {
                    Console.WriteLine($" {c.CourseName} - {c.CourseCode}");
                }
            }


        }


        private static void displayCourseStudents()
        {
            Console.Write("Course Code: ");
            string cCode = Console.ReadLine();

            using (EDModelContainer db = new EDModelContainer())
            {
                Course course = db.Courses.Where(s => s.CourseCode == cCode).First();

                Console.WriteLine($" {course.CourseName}  {course.CourseCode}");
                List<Student> studentList = course.Students.ToList();

                foreach (Student c in studentList)
                {
                    Console.WriteLine($" {c.FirstName}  {c.LastName}");
                }
            }


        }

        private static void displayCourseEnrollmentList()
        {
            using (EDModelContainer db = new EDModelContainer())
            {
                List<Course> CourseList = db.Courses.ToList();
                foreach (Course c in CourseList)
                {
                    Console.WriteLine($" {c.CourseName} - {c.CourseCode}");

                    List<Student> StudentList = c.Students.ToList();
                    foreach(Student s in StudentList)
                    {
                        Console.WriteLine($" {s.FirstName} {s.LastName}");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void displaySelectedCourseEnrollmentList()
        {
            using (EDModelContainer db = new EDModelContainer())
            {
                List<Course> CourseList = db.Courses.ToList();
                foreach (Course c in CourseList)
                {
                    Console.WriteLine($" {c.CourseName} - {c.CourseCode}");

                    List<Student> StudentList = c.Students.ToList();
                    foreach (Student s in StudentList)
                    {
                        Console.WriteLine($" {s.FirstName} {s.LastName}");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void removeAll()
        {
            using (EDModelContainer db = new EDModelContainer())
            {
                List<Course> CourseList = db.Courses.ToList();
                foreach (Course c in CourseList)
                {
                    List<Student> StudentList = c.Students.ToList();
                    foreach (Student s in StudentList)
                    {
                        c.Students.Remove(s);
                    }
                    db.SaveChanges();
                }
            }

        }



    }
}
