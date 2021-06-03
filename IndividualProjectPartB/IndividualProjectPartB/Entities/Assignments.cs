namespace IndividualProjectPartB_GeorgeMalandris.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Assignments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignments()
        {
            Courses = new HashSet<Courses>();
        }

        [Key]
        public int AssignmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        public DateTime subDateTime { get; set; }

        public int oralMark { get; set; }

        public int totalMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }
    }
    public partial class Assignments
    {
        public Assignments(string title, string description, DateTime subDateTime, int oralMark, int totalMark)
        {
            Courses = new HashSet<Courses>();
            this.title = title;
            this.description = description;
            this.subDateTime = subDateTime;
            this.oralMark = oralMark;
            this.totalMark = totalMark;
        }
        public void showConnections(availableTypes typeToShow, bool showContainerInfo)
        {
            int counter = 1;
            if (showContainerInfo)
                HelperDB.show(this, "\nAssignment: ");

            switch (typeToShow)
            {
                case availableTypes.Course:
                    if (Courses.Count > 0)
                    {
                        Console.WriteLine("\nCourses:");
                        foreach (var i in Courses)
                        {
                            HelperDB.show(i, ("  " + counter + ". ").ToString());
                            counter++;
                        }
                    }
                    else
                        Console.WriteLine("\nNo Course has this Assignment yet.");
                    break;
                case availableTypes.Trainer:
                    List<Trainers> listOfTrainers = new List<Trainers>();
                    Console.WriteLine("\nTrainers:");
                    foreach (Courses course in this.Courses)
                    {
                        foreach (Trainers trainer in course.Trainers)
                        {
                            listOfTrainers.Add(trainer);
                        }
                    }
                    if (listOfTrainers.Count() > 0)
                    {
                        foreach (Trainers trainer in listOfTrainers.Distinct())
                        {
                            HelperDB.show(trainer, ("  " + counter + ". ").ToString());
                            counter++;
                        }
                    }
                    else
                        Console.WriteLine("\nNo Trainer has this Assignment yet.");
                    break;
                case availableTypes.Student:
                    List<Students> listOfStudents = new List<Students>();
                    Console.WriteLine("\nStudents:");
                    foreach (Courses course in this.Courses)
                    {
                        foreach (Students student in course.Students)
                        {
                            listOfStudents.Add(student);
                        }
                    }
                    if (listOfStudents.Count() > 0)
                    {
                        foreach (Students student in listOfStudents.Distinct())
                        {
                            HelperDB.show(student, ("  " + counter + ". ").ToString());
                            counter++;
                        }
                    }
                    else
                        Console.WriteLine("\nNo Student has this Assignment yet.");
                    break;
                default:
                    Console.WriteLine("The Assignment doesn't support {0} connections.", typeToShow);
                    break;
            }
        }
        public void connectionsAnalysis()
        {
            showConnections(availableTypes.Course, true);
            showConnections(availableTypes.Student, false);
            showConnections(availableTypes.Trainer, false);
            Console.WriteLine("\nConnection Analysis:");
            Console.WriteLine("- - - - -");
            foreach (Courses course in Courses)
            {
                course.connectionsAnalysis();
            }
        }
    }
}
