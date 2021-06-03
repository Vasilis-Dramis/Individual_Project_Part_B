using IndividualProjectPartB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    public enum availableTypes { Course = 1, Trainer = 2, Student = 3, Assignment = 4 };
    class ProjectHelper
    {
        public static void showCourseInfo(availableTypes typeToShow)
        {
            do
            {
                Console.WriteLine("\nPlease choose the Course you want to see its {0}s.\n", typeToShow);
                Courses course = chooseCourse();
                course.showConnections(typeToShow);
                Console.WriteLine("\nWould you like to see the {0}s of another Course? (y/n)", typeToShow);
            } while (Helper.yesInput());
        }
        public static void showStudentInfo(availableTypes typeToShow)
        {
            IndividualPartBModel db = new IndividualPartBModel();
            if (!(db.Students.Count() > 0))
            {
                Console.WriteLine("You don't have any students yet.\nWould you like to add a new student? (y/n)");
                if (Helper.yesInput())
                {
                    addNew(availableTypes.Student);
                }
            }
            else
            {
                do
                {
                    Console.WriteLine("\nPlease choose the student you want to see his {0}.", typeToShow);
                    Students student = chooseStudent();
                    student.showConnections(typeToShow, true);
                    Console.WriteLine("\nWould you like to see the {0}s of another Student? (y/n)", typeToShow);
                } while (Helper.yesInput());
            }
        }
        public static void addToCourse(availableTypes typeToAdd)
        {
            IndividualPartBModel db = new IndividualPartBModel();
            Console.WriteLine("\nPlease choose the course you want to add the {0}.\n", typeToAdd);
            Courses course = chooseCourse();
            bool emptyListFlag = true;
            switch (typeToAdd)
            {
                case availableTypes.Trainer:
                    emptyListFlag = db.Trainers.Count() > 0 ? false : true;
                    break;
                case availableTypes.Student:
                    emptyListFlag = db.Students.Count() > 0 ? false : true;
                    break;
                case availableTypes.Assignment:
                    emptyListFlag = db.Assignments.Count() > 0 ? false : true;
                    break;
            }
            if (emptyListFlag)
            {
                Console.WriteLine("You don't have any {0} yet.\nWould you like to add a new {1}? (y/n)", typeToAdd, typeToAdd);
                if (Helper.yesInput())
                    addNewLoop(typeToAdd, course);
            }
            else
            {
                Console.WriteLine("\nPlease choose the {0} you want to add the Course.\n", typeToAdd);
                do
                {
                    switch (typeToAdd)
                    {
                        case availableTypes.Trainer:
                            Trainers trainer = chooseTrainer();
                            course.addToCourse(trainer);
                            break;
                        case availableTypes.Student:
                            Students student = chooseStudent();
                            course.addToCourse(student);
                            break;
                        case availableTypes.Assignment:
                            Assignments assignment = chooseAssignment();
                            if (assignment.subDateTime < course.start_date || assignment.subDateTime > course.end_date)
                            {
                                Console.WriteLine("The submit date of the assignment is out of range of the dates of the course.\nAre you sure you want to add the assignment? (y/n)");
                                if (Helper.yesInput())
                                    course.addToCourse(assignment);
                            }
                            else
                                course.addToCourse(assignment);
                            break;
                    }
                    Console.WriteLine("\nWould you like to add another {0} to the course? (y/n)", typeToAdd);
                } while (Helper.yesInput());
            }
        }
        public static void addNew(availableTypes typeToAdd)
        {
            if (typeToAdd == availableTypes.Course)
            {
                do
                {
                    Courses newcourse = createCourse();
                    Console.WriteLine();
                    Console.WriteLine("\nWould you like to add another course? (y/n)");
                } while (Helper.yesInput());
            }
            else
            {
                Console.WriteLine("Every {0} must belong to at least one Course.\nPlease choose the Course you want to add the {1}", typeToAdd, typeToAdd);
                Courses course = chooseCourse();
                addNewLoop(typeToAdd, course);
            }
        }
        static void addNewLoop(availableTypes typeToAdd, Courses course)
        {
            do
            {
                switch (typeToAdd)
                {
                    case availableTypes.Trainer:
                        Trainers newTrainer = createTrainer();
                        course.addToCourse(newTrainer);
                        break;
                    case availableTypes.Student:
                        Students newStudent = createStudent();
                        course.addToCourse(newStudent);
                        break;
                    case availableTypes.Assignment:
                        Assignments newAssignment = createAssignment(course);
                        course.addToCourse(newAssignment);
                        break;
                    default:
                        Console.WriteLine("You cannot add {0} to the DataBase.", typeToAdd);
                        break;
                }
                Console.WriteLine("\nWould you like to add another {0} to this Course? (y/n)", typeToAdd);
            } while (Helper.yesInput());
        }
        public static Courses createCourse()
        {
            Console.WriteLine("Please give the Title of the course.");
            string title = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the Stream of the course.");
            string stream = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the Type of the course.");
            string type = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the Start Date of the course. (DD/MM/YYYY)");
            DateTime startDate = Helper.validDateTimeInput(new DateTime(1753, 01, 01), new DateTime(9999, 12, 31));
            Console.WriteLine("Please give the End Date of the course. (DD/MM/YYYY)");
            DateTime endDate = Helper.validDateTimeInput(startDate, new DateTime(9999, 12, 31));

            Courses course = new Courses(title, stream, type, startDate, endDate);
            HelperDB.addToDb(course);
            return course;
        }
        public static Trainers createTrainer()
        {
            Console.WriteLine("Please give the First Name of the trainer.");
            string firstName = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the Last Name of the trainer.");
            string lastName = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the Subject of the trainer.");
            string subject = Helper.noEmptyStringInputChecker();

            Trainers trainer = new Trainers(firstName, lastName, subject);
            HelperDB.addToDb(trainer);
            return trainer;
        }
        public static Students createStudent()
        {
            Console.WriteLine("Please give the First Name of the student.");
            string firstName = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the Last Name of the student.");
            string lastName = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the birth date of the student. (DD/MM/YYYY)");
            DateTime birthDate = Helper.validDateTimeInput(new DateTime(2020 - 120, 01, 01), DateTime.Now);
            Console.WriteLine("Please give the tuition fees of the student.");
            decimal tuitionFees = Helper.decimalInput(0,9999.99m);

            Students student = new Students(firstName, lastName, birthDate, tuitionFees);
            HelperDB.addToDb(student);
            return student;
        }
        public static Assignments createAssignment(Courses course)
        {
            Console.WriteLine("Please give the Title of the assignment.");
            string title = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the Description of the assignment.");
            string description = Helper.noEmptyStringInputChecker();
            Console.WriteLine("Please give the SubDate of the assignment. (DD/MM/YYYY)");
            DateTime subDate = Helper.validDateTimeInput(course.start_date, course.end_date, true);
            Console.WriteLine("Please give the oralMark of the assignment, as an integer between 1 and 100.");
            int oralMark = Helper.intInput(1, 100);
            Console.WriteLine("Please give the totalMark of the assignment, as an integer between 1 and 100.");
            int totalMark = Helper.intInput(1, 100);

            Assignments assignment = new Assignments(title, description, subDate, oralMark, totalMark);
            HelperDB.addToDb(assignment);
            return assignment;
        }
        public static Courses chooseCourse()
        {
            IndividualPartBModel db = new IndividualPartBModel();
            List<Courses> courseList = db.Courses.ToList();
            HelperDB.showDbByType(courseList);
            int listPosition = Helper.menuSelectionChecker(courseList.Count, false) - 1;
            Courses course = courseList[listPosition];
            return course;
        }
        public static Trainers chooseTrainer()
        {
            IndividualPartBModel db = new IndividualPartBModel();
            List<Trainers> trainerList = db.Trainers.OrderBy(x=>x.lastName).ToList();
            HelperDB.showDbByType(trainerList);
            int listPosition = Helper.menuSelectionChecker(trainerList.Count, false) - 1;
            Trainers trainer = trainerList[listPosition];
            return trainer;
        }
        public static Students chooseStudent()
        {
            IndividualPartBModel db = new IndividualPartBModel();
            List<Students> studentList = db.Students.OrderBy(x=>x.lastName).ToList();
            HelperDB.showDbByType(studentList);
            int listPosition = Helper.menuSelectionChecker(studentList.Count, false) - 1;
            Students student = studentList[listPosition];
            return student;
        }
        public static Assignments chooseAssignment()
        {
            IndividualPartBModel db = new IndividualPartBModel();
            List<Assignments> assignmentList = db.Assignments.ToList();
            HelperDB.showDbByType(assignmentList);
            int listPosition = Helper.menuSelectionChecker(assignmentList.Count, false) - 1;
            Assignments assignment = assignmentList[listPosition];
            return assignment;
        }



        public static void showAssignmentDates()
        {
            IndividualPartBModel db = new IndividualPartBModel();
            do
            {
                List<Assignments> assignmentsToSubmit = new List<Assignments>();
                Console.WriteLine("Please give a date to see if there are any assignments to be submitted.");
                DateTime dt = Helper.validDateTimeInput();
                DateTime startDt = Helper.startOfCalendarWeek(dt);
                DateTime endDt = startDt.AddDays(6);
                foreach (Assignments assignment in db.Assignments.ToList())
                {
                    if (assignment.subDateTime >= startDt && assignment.subDateTime <= endDt)
                        assignmentsToSubmit.Add(assignment);
                }
                Console.WriteLine("\nAssignments to be submitted between {0} and {1} :\n", startDt.ToString("dd/MM/yyyy"), endDt.ToString("dd/MM/yyyy"));
                if (assignmentsToSubmit.Count() == 0)
                {
                    Console.WriteLine("None assignment.");
                }
                else
                {
                    int assignmentCounter = 1;
                    foreach (Assignments assignment in assignmentsToSubmit)
                    {
                        HelperDB.show(assignment, assignmentCounter + ". ");
                        Console.WriteLine("\nStudents:");
                        assignment.showConnections(availableTypes.Student, false);
                        assignmentCounter++;
                    }
                }
                Console.WriteLine("\nWould you like to check another Date? (y/n)");
            } while (Helper.yesInput());

        }
        public static void showAllConnections(availableTypes typeToShow)
        {
            IndividualPartBModel db = new IndividualPartBModel();
            bool emptyListFlag = true;
            switch (typeToShow)
            {
                case availableTypes.Course:
                    emptyListFlag = db.Courses.Count() > 0 ? false : true;
                    break;
                case availableTypes.Trainer:
                    emptyListFlag = db.Trainers.Count() > 0 ? false : true;
                    break;
                case availableTypes.Student:
                    emptyListFlag = db.Students.Count() > 0 ? false : true;
                    break;
                case availableTypes.Assignment:
                    emptyListFlag = db.Assignments.Count() > 0 ? false : true;
                    break;
            }
            if (emptyListFlag)
                Console.WriteLine("\nThere are no {0}s yet.", typeToShow);
            switch (typeToShow)
            {
                case availableTypes.Course:
                    foreach (Courses course in db.Courses.ToList())
                    {
                        course.connectionsAnalysis();
                        Console.WriteLine(". . . . . . . . . . . . . . . . . . . .");
                    }
                    break;
                case availableTypes.Trainer:
                    foreach (Trainers trainer in db.Trainers.ToList())
                    {
                        trainer.connectionsAnalysis();
                        Console.WriteLine(". . . . . . . . . . . . . . . . . . . .");
                    }
                    break;
                case availableTypes.Student:
                    foreach (Students student in db.Students.ToList())
                    {
                        student.connectionsAnalysis();
                        Console.WriteLine(". . . . . . . . . . . . . . . . . . . .");
                    }
                    break;
                case availableTypes.Assignment:
                    foreach (Assignments assignment in db.Assignments.ToList())
                    {
                        assignment.connectionsAnalysis();
                        Console.WriteLine(". . . . . . . . . . . . . . . . . . . .");
                    }
                    break;
                default:
                    Console.WriteLine("The DataBase doesn't support {0} connections.", typeToShow);
                    break;
            }
        }
    }
}
