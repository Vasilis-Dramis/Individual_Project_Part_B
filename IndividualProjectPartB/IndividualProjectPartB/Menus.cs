using IndividualProjectPartB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Menus
    {
        public enum menuIDs { exit = -1, addFirstCourseMenu = 0, centralMenu = 100, courseMenu = 110, infoCourseMenu = 111, editCourseMenu = 112, studentMenu = 120, infoStudentMenu = 121, trainertMenu = 130, assignmentMenu = 140 };
        public static void menuRunner()
        {
            menuIDs choice = menuIDs.centralMenu;
            do
            {
                choice = menuHandler(choice);
            } while (!Helper.exitChecker(choice.ToString()));
        }
        public static menuIDs menuHandler(menuIDs menuID)
        {
            Console.Clear();
            menuIDs nextChoice = menuIDs.centralMenu;
            switch (menuID)
            {
                case menuIDs.addFirstCourseMenu:
                    nextChoice = addFirstCourseMenu();
                    break;
                case menuIDs.centralMenu:
                    nextChoice = centralMenu();
                    break;
                case menuIDs.courseMenu:
                    nextChoice = courseMenu();
                    break;
                case menuIDs.infoCourseMenu:
                    nextChoice = infoCourseMenu();
                    break;
                case menuIDs.editCourseMenu:
                    nextChoice = editCourseMenu();
                    break;
                case menuIDs.studentMenu:
                    nextChoice = studentMenu();
                    break;
                case menuIDs.infoStudentMenu:
                    nextChoice = infoStudentMenu();
                    break;
                case menuIDs.trainertMenu:
                    nextChoice = trainertMenu();
                    break;
                case menuIDs.assignmentMenu:
                    nextChoice = assignmentMenu();
                    break;
                default:
                    break;
            }
            return nextChoice;
        }
        public static menuIDs centralMenu()
        {
            Console.WriteLine("Welcome to our school!!");
            //menuID = "100";
            Console.WriteLine("\nPlease choose what you want to do:\n" +
                                "1. Courses\n" +
                                "2. Students\n" +
                                "3. Trainers\n" +
                                "4. Assignments\n" +
                                "EXIT to exit program\n");

            int selection;
            selection = Helper.menuSelectionChecker(4, true);

            menuIDs IDselect = menuIDs.centralMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.courseMenu;
                    break;
                case 2:
                    IDselect = menuIDs.studentMenu;
                    break;
                case 3:
                    IDselect = menuIDs.trainertMenu;
                    break;
                case 4:
                    IDselect = menuIDs.assignmentMenu;
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            IndividualPartBModel db = new IndividualPartBModel();
            if (db.Courses.Count() == 0 && selection != -1)
                IDselect = menuIDs.addFirstCourseMenu;
            return IDselect;
        }
        public static menuIDs addFirstCourseMenu()
        {
            //menuID = "000";
            Console.WriteLine("Every School must have at least one course.\n");
            Console.WriteLine("Would you like to add a course?\n");
            Console.WriteLine("To add a course press 'y'\n" +
                                "To exit press 'n'\n");
            menuIDs IDselect;
            if (Helper.yesInput())
            {
                ProjectHelper.addNew(availableTypes.Course);
                IDselect = menuIDs.centralMenu;
            }
            else
            {
                IDselect = menuIDs.exit;
            }
            return IDselect;
        }
        public static menuIDs courseMenu()
        {
            //menuID = "110";
            Console.WriteLine("Course menu\n");
            Console.WriteLine("Please choose what you want to do:\n" +
                                "1. back\n" +
                                "2. add a course\n" +
                                "3. see all available courses\n" +
                                "4. see infos about courses\n" +
                                "5. edit a course\n" +
                                "EXIT to exit program\n");

            int selection = Helper.menuSelectionChecker(5, true);

            menuIDs IDselect = menuIDs.courseMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.centralMenu;
                    break;
                case 2:
                    ProjectHelper.addNew(availableTypes.Course);
                    break;
                case 3:
                    IndividualPartBModel db = new IndividualPartBModel();
                    HelperDB.showDbByType(db.Courses.ToList());
                    break;
                case 4:
                    IDselect = menuIDs.infoCourseMenu;
                    break;
                case 5:
                    IDselect = menuIDs.editCourseMenu;
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            if (selection == 3)
            {
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
            }
            return IDselect;
        }
        public static menuIDs infoCourseMenu()
        {
            //menuID = "111";
            Console.WriteLine("Course info menu\n");
            Console.WriteLine("Please choose what you want to do:\n" +
                                "1. back\n" +
                                "2. see the students of a course\n" +
                                "3. see the trainers of a course\n" +
                                "4. see the assignments of a course\n" +
                                "5. see all the connections of all the courses\n" +
                                "EXIT to exit program\n");

            int selection = Helper.menuSelectionChecker(5, true);

            menuIDs IDselect = menuIDs.infoCourseMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.courseMenu;
                    break;
                case 2:
                    ProjectHelper.showCourseInfo(availableTypes.Student);
                    break;
                case 3:
                    ProjectHelper.showCourseInfo(availableTypes.Trainer);
                    break;
                case 4:
                    ProjectHelper.showCourseInfo(availableTypes.Assignment);
                    break;
                case 5:
                    ProjectHelper.showAllConnections(availableTypes.Course);
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            if (selection == 5)
            {
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
            }
            return IDselect;
        }
        public static menuIDs editCourseMenu()
        {
            //menuID = "112";
            Console.WriteLine("Course edit menu\n");
            Console.WriteLine("Please choose what you want to do:\n" +
                                "1. back\n" +
                                "2. add a student to a course\n" +
                                "3. add a trainer to a course\n" +
                                "4. add an assignment to a course\n" +
                                "EXIT to exit program\n");

            int selection = Helper.menuSelectionChecker(4, true);

            menuIDs IDselect = menuIDs.editCourseMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.courseMenu;
                    break;
                case 2:
                    ProjectHelper.addToCourse(availableTypes.Student);
                    break;
                case 3:
                    ProjectHelper.addToCourse(availableTypes.Trainer);
                    break;
                case 4:
                    ProjectHelper.addToCourse(availableTypes.Assignment);
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            return IDselect;
        }
        public static menuIDs studentMenu()
        {
            //menuID = "120";
            Console.WriteLine("Student menu\n");
            Console.WriteLine("Please choose what you want to do:\n" +
                                "1. back\n" +
                                "2. add a new student\n" +
                                "3. see all students\n" +
                                "4. see infos about students\n" +
                                "5. add a course to a student\n" +
                                "EXIT to exit program\n");

            int selection = Helper.menuSelectionChecker(5, true);

            menuIDs IDselect = menuIDs.studentMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.centralMenu;
                    break;
                case 2:
                    ProjectHelper.addNew(availableTypes.Student);
                    break;
                case 3:
                    IndividualPartBModel db = new IndividualPartBModel();
                    HelperDB.showDbByType(db.Students.ToList());
                    break;
                case 4:
                    IDselect = menuIDs.infoStudentMenu;
                    break;
                case 5:
                    ProjectHelper.addToCourse(availableTypes.Student);
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            if (selection == 3)
            {
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
            }
            return IDselect;
        }
        public static menuIDs infoStudentMenu()
        {
            //menuID = "121";
            Console.WriteLine("Student info menu\n");
            Console.WriteLine("Please choose what you want to do:\n" +
                                "1. back\n" +
                                "2. see all the assignments of a student\n" +
                                "3. see all the courses of a student\n" +
                                "4. see the students with more than one courses\n" +
                                "5. see all the connections of all the students\n" +
                                "EXIT to exit program\n");

            int selection = Helper.menuSelectionChecker(5, true);

            menuIDs IDselect = menuIDs.infoStudentMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.studentMenu;
                    break;
                case 2:
                    ProjectHelper.showStudentInfo(availableTypes.Assignment);
                    break;
                case 3:
                    ProjectHelper.showStudentInfo(availableTypes.Course);
                    break;
                case 4:
                    HelperDB.showStudentsWithMultipleCourses();
                    break;
                case 5:
                    ProjectHelper.showAllConnections(availableTypes.Student);
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            if (selection == 4 || selection == 5)
            {
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
            }
            return IDselect;
        }
        public static menuIDs trainertMenu()
        {
            //menuID = "130";
            Console.WriteLine("Trainer menu\n");
            Console.WriteLine("Please choose what you want to do:\n" +
                                "1. back\n" +
                                "2. add a new trainer\n" +
                                "3. see all trainers\n" +
                                "4. assign a trainer to a course\n" +
                                "5. see all the connections of all trainers\n" +
                                "EXIT to exit program\n");

            int selection = Helper.menuSelectionChecker(5, true);

            menuIDs IDselect = menuIDs.trainertMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.centralMenu;
                    break;
                case 2:
                    ProjectHelper.addNew(availableTypes.Trainer);
                    break;
                case 3:
                    IndividualPartBModel db = new IndividualPartBModel();
                    HelperDB.showDbByType(db.Trainers.ToList());
                    break;
                case 4:
                    ProjectHelper.addToCourse(availableTypes.Trainer);
                    break;
                case 5:
                    ProjectHelper.showAllConnections(availableTypes.Trainer);
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            if (selection == 3 || selection == 5)
            {
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
            }
            return IDselect;
        }
        public static menuIDs assignmentMenu()
        {
            //menuID = "140";
            Console.WriteLine("Assignment menu\n");
            Console.WriteLine("Please choose what you want to do:\n" +
                                "1. back\n" +
                                "2. add a new assignment\n" +
                                "3. add an assignment to a course\n" +
                                "4. see all assignments\n" +
                                "5. see the students who need to submit assignments in a date\n" +
                                "6. see all the assignments per course per student\n" +
                                "7. see all the connections of all assignments\n" +
                                "EXIT to exit program\n");

            int selection = Helper.menuSelectionChecker(7, true);

            menuIDs IDselect = menuIDs.assignmentMenu;
            switch (selection)
            {
                case 1:
                    IDselect = menuIDs.centralMenu;
                    break;
                case 2:
                    ProjectHelper.addNew(availableTypes.Assignment);
                    break;
                case 3:
                    ProjectHelper.addToCourse(availableTypes.Assignment);
                    break;
                case 4:
                    IndividualPartBModel db = new IndividualPartBModel();
                    HelperDB.showDbByType(db.Assignments.ToList());
                    break;
                case 5:
                    ProjectHelper.showAssignmentDates();
                    break;
                case 6:
                    HelperDB.showAssignmentPerCoursePerStudentt();
                    break;
                case 7:
                    ProjectHelper.showAllConnections(availableTypes.Assignment);
                    break;
                default:
                    IDselect = menuIDs.exit;
                    break;
            }
            if (selection == 4 || selection == 6 || selection == 7)
            {
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
            }
            return IDselect;
        }
    }
}
