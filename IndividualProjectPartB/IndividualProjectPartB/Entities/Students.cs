namespace IndividualProjectPartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            Courses = new HashSet<Courses>();
        }

        [Key]
        public int StudentID { get; set; }

        [Required]
        [StringLength(25)]
        public string firstName { get; set; }

        [Required]
        [StringLength(25)]
        public string lastName { get; set; }

        public DateTime dateOfBirth { get; set; }

        public decimal tuitionFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }
    }
    public partial class Students
    {
        public Students(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
        {
            Courses = new HashSet<Courses>();
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.tuitionFees = tuitionFees;
        }
        public void showConnections(availableTypes typeToShow, bool showContainerInfo)
        {
            int counter = 1;
            if (showContainerInfo)
                HelperDB.show(this, "\nStudent: ");

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
                        Console.WriteLine("\nThe Student has no Courses yet.");
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
                        Console.WriteLine("\nThe Student has no Trainers yet.");
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
                        Console.WriteLine("\nThe Student has no Assignments yet.");
                    break;
                default:
                    Console.WriteLine("The Student doesn't support {0} connections.", typeToShow);
                    break;
            }
        }
        public void connectionsAnalysis()
        {
            showConnections(availableTypes.Course, true);
            showConnections(availableTypes.Trainer, false);
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
