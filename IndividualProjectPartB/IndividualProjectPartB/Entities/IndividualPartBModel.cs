namespace IndividualProjectPartB_GeorgeMalandris.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IndividualPartBModel : DbContext
    {
        public IndividualPartBModel()
            : base("name=IndividualPartBModel")
        {
        }

        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignments>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Assignments)
                .Map(m => m.ToTable("CourseAssignmentsRelation").MapLeftKey("AssignmentID").MapRightKey("CourseID"));

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseStudentRelation").MapLeftKey("CourseID").MapRightKey("StudentID"));

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Trainers)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseTrainerRelation").MapLeftKey("CourseID").MapRightKey("TrainerID"));

            modelBuilder.Entity<Students>()
                .Property(e => e.tuitionFees)
                .HasPrecision(6, 2);
        }
    }
}
