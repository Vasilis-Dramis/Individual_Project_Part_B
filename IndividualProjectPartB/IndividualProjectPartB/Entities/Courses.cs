namespace IndividualProjectPartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            Assignments = new HashSet<Assignments>();
            Students = new HashSet<Students>();
            Trainers = new HashSet<Trainers>();
        }

        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(10)]
        public string title { get; set; }

        [Required]
        [StringLength(10)]
        public string stream { get; set; }

        [Required]
        [StringLength(30)]
        public string type { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignments> Assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainers> Trainers { get; set; }
    }
    public partial class Courses
    {
        public Courses(string title, string stream, string type, DateTime start_date, DateTime end_date)
        {
            Assignments = new HashSet<Assignments>();
            Students = new HashSet<Students>();
            Trainers = new HashSet<Trainers>();
            this.title = title;
            this.stream = stream;
            this.type = type;
            this.start_date = start_date;
            this.end_date = end_date;
        }

        public void addToCourse<T>(T value)
        {
            IndividualPartBModel db = new IndividualPartBModel();
            switch (value)
            {
                case Trainers trainer:
                    if (!exists(trainer))
                    {
                        Trainers trainerToAdd = db.Trainers.Where(item => item.firstName.Equals(trainer.firstName, StringComparison.OrdinalIgnoreCase) && item.lastName.Equals(trainer.lastName, StringComparison.OrdinalIgnoreCase) && item.subject.Equals(trainer.subject, StringComparison.OrdinalIgnoreCase)).First();
                        if (trainerToAdd != null)
                            this.Trainers.Add(trainerToAdd);
                        else
                            this.Trainers.Add(trainer);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!");
                        }
                        Console.WriteLine("The Trainer was succefully added to the Course.");
                    }
                    else
                        Console.WriteLine("This Course already has this Trainer.");
                    break;
                case Students student:
                    if (!exists(student))
                    {
                        Students studentToAdd = db.Students.Where(item => item.firstName.Equals(student.firstName, StringComparison.OrdinalIgnoreCase) && item.lastName.Equals(student.lastName, StringComparison.OrdinalIgnoreCase) && item.dateOfBirth == student.dateOfBirth).First();
                        if (studentToAdd != null)
                            this.Students.Add(studentToAdd);
                        else
                            this.Students.Add(student);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!");
                        }
                        Console.WriteLine("The Student was succefully added to the Course.");
                    }
                    else
                        Console.WriteLine("This Course already has this Student.");
                    break;
                case Assignments assignment:
                    if (!exists(assignment))
                    {
                        Assignments assignmentToAdd = db.Assignments.Where(item => item.title.Equals(assignment.title, StringComparison.OrdinalIgnoreCase) && item.description.Equals(assignment.description, StringComparison.OrdinalIgnoreCase) && item.subDateTime == assignment.subDateTime).First();
                        if (assignmentToAdd != null)
                            this.Assignments.Add(assignmentToAdd);
                        else
                            this.Assignments.Add(assignment);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong!");
                        }
                        Console.WriteLine("The Assignment was succefully added to the Course.");
                    }
                    else
                        Console.WriteLine("This Course already has this Assignment.");
                    break;
                default:
                    Console.WriteLine("The Course cannot contain {0}.", value.GetType().Name);
                    break;
            }
        }
        bool exists<T>(T value)
        {
            bool flag = false;
            switch (value)
            {
                case Students student:
                    var sList = this.Students.Where(item => item.firstName.Equals(student.firstName, StringComparison.OrdinalIgnoreCase) && item.lastName.Equals(student.lastName, StringComparison.OrdinalIgnoreCase) && item.dateOfBirth == student.dateOfBirth);
                    flag = sList.Count() > 0 ? true : false;
                    break;
                case Trainers trainer:
                    var tList = this.Trainers.Where(item => item.firstName.Equals(trainer.firstName, StringComparison.OrdinalIgnoreCase) && item.lastName.Equals(trainer.lastName, StringComparison.OrdinalIgnoreCase) && item.subject.Equals(trainer.subject, StringComparison.OrdinalIgnoreCase));
                    flag = tList.Count() > 0 ? true : false;
                    break;
                case Assignments assignment:
                    var aList = this.Assignments.Where(item => item.title.Equals(assignment.title, StringComparison.OrdinalIgnoreCase) && item.description.Equals(assignment.description, StringComparison.OrdinalIgnoreCase) && item.subDateTime == assignment.subDateTime);
                    flag = aList.Count() > 0 ? true : false;
                    break;
            }
            return flag;
        }

        public void showConnections(availableTypes typeToShow)
        {
            HelperDB.show(this, "\nCourse: ");
            int counter = 1;
            switch (typeToShow)
            {
                case availableTypes.Trainer:
                    if (Trainers.Count > 0)
                    {
                        foreach (Trainers trainer in this.Trainers)
                        {
                            HelperDB.show(trainer, ("  " + counter + ". ").ToString());
                            counter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThe Course has no Trainers yet.");
                    }
                    break;
                case availableTypes.Student:
                    if (Students.Count > 0)
                    {
                        foreach (Students student in this.Students)
                        {
                            HelperDB.show(student, ("  " + counter + ". ").ToString());
                            counter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThe Course has no Students yet.");
                    }
                    break;
                case availableTypes.Assignment:
                    if (Assignments.Count > 0)
                    {
                        foreach (Assignments assignment in this.Assignments)
                        {
                            HelperDB.show(assignment, ("  " + counter + ". ").ToString());
                            counter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThe Course has no Assignments yet.");
                    }
                    break;
                default:
                    Console.WriteLine("The Course doesn't support connections.");
                    break;
            }
        }
        public void connectionsAnalysis()
        {
            HelperDB.show(this, "\nCourse:");
            Console.WriteLine("\nTrainers:");
            if (Trainers.Count > 0)
                foreach (Trainers trainer in Trainers)
                {
                    int counter = 1;
                    HelperDB.show(trainer, ("  " + counter + ". ").ToString());
                    counter++;
                }
            else
            {
                Console.WriteLine("\nThere are no Trainers in this Course yet.");
            }
            Console.WriteLine("\nStudents:");
            if (Students.Count > 0)
            {
                foreach (Students student in Students)
                {
                    int counter = 1;
                    HelperDB.show(student, ("  " + counter + ". ").ToString());
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("\nThere are no Students in this Course yet.");
            }
            Console.WriteLine("\nAssignments:");
            if (Assignments.Count > 0)
            {
                foreach (Assignments assignment in Assignments)
                {
                    int counter = 1;
                    HelperDB.show(assignment, ("  " + counter + ". ").ToString());
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("\nThere are no Assignments in this Course yet.");
            }
        }
    }
}
