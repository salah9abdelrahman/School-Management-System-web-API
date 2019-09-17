namespace School_managment_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        SNN = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        SessionId = c.Int(nullable: false),
                        IsAttended = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.SessionId })
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        ExamName = c.String(nullable: false),
                        MaxExamDegree = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ExamId = c.Int(nullable: false),
                        StudentResult = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.ExamId })
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ClassRoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassRoomId)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        Phone = c.String(),
                        Gender = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        ParentSNN = c.String(maxLength: 128),
                        ClassRoomId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomId)
                .ForeignKey("dbo.Parents", t => t.ParentSNN)
                .Index(t => t.ParentSNN)
                .Index(t => t.ClassRoomId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentSNN = c.String(nullable: false, maxLength: 128),
                        FName = c.String(nullable: false),
                        LName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ParentSNN);
            
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        TeacherCourseId = c.Int(nullable: false, identity: true),
                        TeacherId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Sessions", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Sessions", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ParentSNN", "dbo.Parents");
            DropForeignKey("dbo.Students", "ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.Attendences", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ClassRooms", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Results", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "SessionId", "dbo.Sessions");
            DropIndex("dbo.TeacherCourses", new[] { "CourseId" });
            DropIndex("dbo.TeacherCourses", new[] { "TeacherId" });
            DropIndex("dbo.Students", new[] { "ClassRoomId" });
            DropIndex("dbo.Students", new[] { "ParentSNN" });
            DropIndex("dbo.ClassRooms", new[] { "LevelId" });
            DropIndex("dbo.Results", new[] { "ExamId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "LevelId" });
            DropIndex("dbo.Sessions", new[] { "TeacherId" });
            DropIndex("dbo.Sessions", new[] { "CourseId" });
            DropIndex("dbo.Attendences", new[] { "SessionId" });
            DropIndex("dbo.Attendences", new[] { "StudentId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherCourses");
            DropTable("dbo.Parents");
            DropTable("dbo.Students");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Levels");
            DropTable("dbo.Results");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
            DropTable("dbo.Sessions");
            DropTable("dbo.Attendences");
            DropTable("dbo.Admins");
        }
    }
}
