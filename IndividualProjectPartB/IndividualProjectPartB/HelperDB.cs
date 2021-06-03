using IndividualProjectPartB_GeorgeMalandris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB_GeorgeMalandris
{
    static class HelperDB
    {
        public static void addToDb<T>(T value)
        {
            IndividualPartBModel db = new IndividualPartBModel();
            switch (value)
            {
                case Courses course:
                    if (!existsInDb(course))
                    {
                        db.Courses.Add(course);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!");
                        }
                        Console.WriteLine("The {0} was succefully added.", value.GetType().Name);
                    }
                    break;
                case Trainers trainer:
                    if (!existsInDb(trainer))
                    {
                        db.Trainers.Add(trainer);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!");
                        }
                        Console.WriteLine("The {0} was succefully added.", value.GetType().Name);
                    }
                    break;
                case Students student:
                    if (!existsInDb(student))
                    {
                        db.Students.Add(student);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!");
                        }
                        Console.WriteLine("The {0} was succefully added.", value.GetType().Name);
                    }
                    break;
                case Assignments assignment:
                    if (!existsInDb(assignment))
                    {
                        db.Assignments.Add(assignment);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!");
                        }
                        Console.WriteLine("The {0} was succefully added.", value.GetType().Name);
                    }
                    break;
                default:
                    Console.WriteLine("The DataBase doesn't support {0}.", value.GetType().Name);
                    break;
            }
        }
        static bool existsInDb<T>(T value)
        {
            IndividualPartBModel db = new IndividualPartBModel();
            bool flag = false;
            switch (value)
            {
                case Courses course:
                    var cList = db.Courses.Where(item => item.title.Equals(course.title, StringComparison.OrdinalIgnoreCase) && item.stream.Equals(course.stream, StringComparison.OrdinalIgnoreCase) && item.type.Equals(course.type, StringComparison.OrdinalIgnoreCase));
                    if (cList.Count() > 0)
                    {
                        if (cList.Count() > 1)
                            Console.WriteLine("WARNING!! You have doubles.");
                        Console.WriteLine("The Course already exists and cannot be added again.");
                        flag = true;
                    }
                    break;
                case Trainers trainer:
                    var tList = db.Trainers.Where(item => item.firstName.Equals(trainer.firstName, StringComparison.OrdinalIgnoreCase) && item.lastName.Equals(trainer.lastName, StringComparison.OrdinalIgnoreCase) && item.subject.Equals(trainer.subject, StringComparison.OrdinalIgnoreCase));
                    if (tList.Count() > 0)
                    {
                        if (tList.Count() > 1)
                            Console.WriteLine("WARNING!! You have doubles.");
                        Console.WriteLine("This Trainer already exists and cannot be added again.");
                        flag = true;
                    }
                    break;
                case Students student:
                    var sList = db.Students.Where(item => item.firstName.Equals(student.firstName, StringComparison.OrdinalIgnoreCase) && item.lastName.Equals(student.lastName, StringComparison.OrdinalIgnoreCase) && item.dateOfBirth == student.dateOfBirth);
                    if (sList.Count() > 0)
                    {
                        if (sList.Count() > 1)
                            Console.WriteLine("WARNING!! You have doubles.");
                        Console.WriteLine("This Student already exists and cannot be added again.");
                        flag = true;
                    }
                    break;
                case Assignments assignment:
                    var aList = db.Assignments.Where(item => item.title.Equals(assignment.title, StringComparison.OrdinalIgnoreCase) && item.description.Equals(assignment.description, StringComparison.OrdinalIgnoreCase) && item.subDateTime == assignment.subDateTime);
                    if (aList.Count() > 0)
                    {
                        if (aList.Count() > 1)
                            Console.WriteLine("WARNING!! You have doubles.");
                        Console.WriteLine("This Assignment already exists and cannot be added again.");
                        flag = true;
                    }
                    break;
                default:
                    Console.WriteLine("The DataBase doesn't support {0}.", value.GetType().Name);
                    break;
            }
            return flag;
        }
        public static void showDbByType<T>(List<T> value)
        {
            string valueT = value.GetType().ToString();
            valueT = valueT.Substring(valueT.LastIndexOf(".") + 1, valueT.Length - valueT.LastIndexOf(".") - 2);
            if (value.Count == 0)
                Console.WriteLine("\nThere are no {0} yet.", valueT);
            else
            {
                Console.WriteLine("{0}:", valueT);
                int counter = 1;
                foreach (T item in value)
                {
                    show(item, ("  " + counter + ". ").ToString());
                    counter++;
                }
            }
        }
        public static void show<T>(T value, string prefix)
        {
            switch (value)
            {
                case Courses course:
                    Console.WriteLine("{0}Title: {1}, Stream: {2}, Type: {3}, Start Date: {4}, End Date: {5}", prefix, course.title, course.stream, course.type, course.start_date.ToString("dddd, dd MMMM yyyy"), course.end_date.ToString("dddd, dd MMMM yyyy"));
                    break;
                case Trainers trainer:
                    Console.WriteLine("{0}Last Name: {1}, First Name: {2}, Subject: {3}", prefix, trainer.lastName, trainer.firstName, trainer.subject);
                    break;
                case Students student:
                    Console.WriteLine("{0}Last Name: {1}, First Name: {2}, Date of Birth: {3}, Tuition Fees: {4}", prefix, student.lastName, student.firstName, student.dateOfBirth.ToString("dd/MM/yyyy"), student.tuitionFees.ToString("N2"));
                    break;
                case Assignments assignment:
                    Console.WriteLine("{0}Title: {1}, Description: {2}, Sub Date: {3}, Oral Mark: {4}, Total Mark: {5}", prefix, assignment.title, assignment.description, assignment.subDateTime.ToString("dddd, dd MMMM yyyy"), assignment.oralMark, assignment.totalMark);
                    break;
                default:
                    Console.WriteLine("The DataBase doesn't support {0}.", value.GetType().Name);
                    break;
            }
        }
        public static void showStudentsWithMultipleCourses()
        {
            IndividualPartBModel db = new IndividualPartBModel();
            int counter = 0;
            Console.WriteLine("The students with multiple courses are:\n");
            foreach (Students item in db.Students.ToList())
            {
                if (item.Courses.Count() > 1)
                {
                    counter++;
                    show(item, ("  " + counter + ". ").ToString());
                }
            }
            if (counter == 0)
                Console.WriteLine("None of the students has multiple courses.");
        }
        public static void showAssignmentPerCoursePerStudentt()
        {
            IndividualPartBModel db = new IndividualPartBModel();
            if (db.Assignments.Count() > 0)
            {
                foreach (Courses course in db.Courses.ToList())
                {
                    show(course, "\nCourse: ");
                    foreach (Assignments assignment in course.Assignments)
                    {
                        assignment.showConnections(availableTypes.Student, true);
                    }
                }
            }
            else
                Console.WriteLine("There no assignment yet.");
        }
    }
}
