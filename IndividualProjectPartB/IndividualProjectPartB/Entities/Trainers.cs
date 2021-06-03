namespace IndividualProjectPartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Trainers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainers()
        {
            Courses = new HashSet<Courses>();
        }

        [Key]
        public int TrainerID { get; set; }

        [Required]
        [StringLength(25)]
        public string firstName { get; set; }

        [Required]
        [StringLength(25)]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        public string subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }
    }
    public partial class Trainers
    {
        public Trainers(string firstName, string lastName, string subject)
        {
            Courses = new HashSet<Courses>();
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
        }

        public void showConnections(availableTypes typeToShow, bool showContainerInfo)
        {
            int counter = 1;
            if (showContainerInfo)
                HelperDB.show(this, "\nTrainer: ");
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
                        Console.WriteLine("\nThe Trainer has no Courses yet.");
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
                        Console.WriteLine("\nThe Trainer has no Students yet.");
                    break;
                case availableTypes.Assignment:
                    List<Assignments> listOfAssignments = new List<Assignments>();
                    Console.WriteLine("\nAssignments:");
                    foreach (Courses course in this.Courses)
                    {
                        foreach (Assignments assignment in course.Assignments)
                        {
                            listOfAssignments.Add(assignment);
                        }
                    }
                    if (listOfAssignments.Count() > 0)
                    {
                        foreach (Assignments assignment in listOfAssignments.Distinct())
                        {
                            HelperDB.show(assignment, ("  " + counter + ". ").ToString());
                            counter++;
                        }
                    }
                    else
                        Console.WriteLine("\nThe Trainer has no Assignments yet.");
                    break;
                default:
                    Console.WriteLine("The Trainer doesn't support {0} connections.", typeToShow);
                    break;
            }
        }
        public void connectionsAnalysis()
        {
            showConnections(availableTypes.Course, true);
            showConnections(availableTypes.Student, false);
            showConnections(availableTypes.Assignment, false);
            Console.WriteLine("\nConnection Analysis:");
            Console.WriteLine("- - - - -");
            foreach (Courses course in Courses)
            {
                course.connectionsAnalysis();
            }
        }
    }
}
