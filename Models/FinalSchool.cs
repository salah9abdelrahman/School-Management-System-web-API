namespace School_managment_system.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class FinalSchool : DbContext
    {
        //
        public FinalSchool()
            : base("name=FinalSchool")
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Attendence> Attendences { get; set; }
        public virtual DbSet<TeacherCourse> TeacherCourses { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
    }
    
}