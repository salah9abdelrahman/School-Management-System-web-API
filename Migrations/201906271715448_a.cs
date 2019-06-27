namespace School_managment_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendences", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Results", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Attendences", new[] { "CourseId" });
            DropIndex("dbo.Attendences", new[] { "TeacherId" });
            DropIndex("dbo.ClassRooms", new[] { "Name" });
            DropIndex("dbo.Results", new[] { "CourseId" });
            DropPrimaryKey("dbo.Attendences");
            DropPrimaryKey("dbo.Results");
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId);
            
            AddColumn("dbo.Attendences", "SessionId", c => c.Int(nullable: false));
            AddColumn("dbo.Attendences", "ClassRoom_ClassRoomId", c => c.Int());
            AddColumn("dbo.Results", "StudentResult", c => c.Int(nullable: false));
            AddColumn("dbo.Exams", "ExamName", c => c.String(nullable: false));
            AddColumn("dbo.Exams", "CourseId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Attendences", new[] { "StudentId", "SessionId" });
            AddPrimaryKey("dbo.Results", new[] { "StudentId", "ExamId" });
            CreateIndex("dbo.Attendences", "SessionId");
            CreateIndex("dbo.Attendences", "ClassRoom_ClassRoomId");
            CreateIndex("dbo.Exams", "CourseId");
            AddForeignKey("dbo.Attendences", "SessionId", "dbo.Sessions", "SessionId", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Attendences", "ClassRoom_ClassRoomId", "dbo.ClassRooms", "ClassRoomId");
            DropColumn("dbo.Attendences", "SessionDate");
            DropColumn("dbo.Attendences", "CourseId");
            DropColumn("dbo.Attendences", "TeacherId");
            DropColumn("dbo.Results", "CourseId");
            DropColumn("dbo.Results", "Mark");
            DropColumn("dbo.Exams", "ExamType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "ExamType", c => c.String(nullable: false));
            AddColumn("dbo.Results", "Mark", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Results", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Attendences", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.Attendences", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Attendences", "SessionDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Sessions", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Sessions", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "ClassRoom_ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "SessionId", "dbo.Sessions");
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Sessions", new[] { "TeacherId" });
            DropIndex("dbo.Sessions", new[] { "CourseId" });
            DropIndex("dbo.Attendences", new[] { "ClassRoom_ClassRoomId" });
            DropIndex("dbo.Attendences", new[] { "SessionId" });
            DropPrimaryKey("dbo.Results");
            DropPrimaryKey("dbo.Attendences");
            DropColumn("dbo.Exams", "CourseId");
            DropColumn("dbo.Exams", "ExamName");
            DropColumn("dbo.Results", "StudentResult");
            DropColumn("dbo.Attendences", "ClassRoom_ClassRoomId");
            DropColumn("dbo.Attendences", "SessionId");
            DropTable("dbo.Sessions");
            AddPrimaryKey("dbo.Results", new[] { "CourseId", "ExamId", "StudentId" });
            AddPrimaryKey("dbo.Attendences", new[] { "SessionDate", "CourseId", "TeacherId", "StudentId" });
            CreateIndex("dbo.Results", "CourseId");
            CreateIndex("dbo.ClassRooms", "Name", unique: true);
            CreateIndex("dbo.Attendences", "TeacherId");
            CreateIndex("dbo.Attendences", "CourseId");
            AddForeignKey("dbo.Attendences", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
            AddForeignKey("dbo.Results", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Attendences", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
