namespace School_managment_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dgss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sessions", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Students", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Attendences", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropIndex("dbo.Attendences", new[] { "StudentId" });
            DropIndex("dbo.Sessions", new[] { "TeacherId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ParentId" });
            DropIndex("dbo.TeacherCourses", new[] { "TeacherId" });
            RenameColumn(table: "dbo.Students", name: "SSN", newName: "StudentId");
            RenameColumn(table: "dbo.Teachers", name: "SSN", newName: "TeacherId");
            DropPrimaryKey("dbo.Attendences");
            DropPrimaryKey("dbo.Results");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Parents");
            DropPrimaryKey("dbo.Teachers");
            AddColumn("dbo.Students", "Parent_ParentSNN", c => c.String(maxLength: 128));
            AddColumn("dbo.Parents", "ParentSNN", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Admins", "SNN", c => c.String());
            AlterColumn("dbo.Attendences", "StudentId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Sessions", "TeacherId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Results", "StudentId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Students", "StudentId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Students", "ParentId", c => c.String());
            AlterColumn("dbo.TeacherCourses", "TeacherId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Teachers", "TeacherId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Attendences", new[] { "StudentId", "SessionId" });
            AddPrimaryKey("dbo.Results", new[] { "StudentId", "ExamId" });
            AddPrimaryKey("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.Parents", "ParentSNN");
            AddPrimaryKey("dbo.Teachers", "TeacherId");
            CreateIndex("dbo.Attendences", "StudentId");
            CreateIndex("dbo.Sessions", "TeacherId");
            CreateIndex("dbo.Results", "StudentId");
            CreateIndex("dbo.Students", "Parent_ParentSNN");
            CreateIndex("dbo.TeacherCourses", "TeacherId");
            AddForeignKey("dbo.Sessions", "TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.Students", "Parent_ParentSNN", "dbo.Parents", "ParentSNN");
            AddForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.Attendences", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Results", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            DropColumn("dbo.Parents", "ParentId");
            DropColumn("dbo.Parents", "SNN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parents", "SNN", c => c.Int(nullable: false));
            AddColumn("dbo.Parents", "ParentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendences", "StudentId", "dbo.Students");
            DropForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Parent_ParentSNN", "dbo.Parents");
            DropForeignKey("dbo.Sessions", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.TeacherCourses", new[] { "TeacherId" });
            DropIndex("dbo.Students", new[] { "Parent_ParentSNN" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Sessions", new[] { "TeacherId" });
            DropIndex("dbo.Attendences", new[] { "StudentId" });
            DropPrimaryKey("dbo.Teachers");
            DropPrimaryKey("dbo.Parents");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Results");
            DropPrimaryKey("dbo.Attendences");
            AlterColumn("dbo.Teachers", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherCourses", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "ParentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Results", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sessions", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Attendences", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "SNN", c => c.Int(nullable: false));
            DropColumn("dbo.Parents", "ParentSNN");
            DropColumn("dbo.Students", "Parent_ParentSNN");
            AddPrimaryKey("dbo.Teachers", "SSN");
            AddPrimaryKey("dbo.Parents", "ParentId");
            AddPrimaryKey("dbo.Students", "SSN");
            AddPrimaryKey("dbo.Results", new[] { "StudentId", "ExamId" });
            AddPrimaryKey("dbo.Attendences", new[] { "StudentId", "SessionId" });
            RenameColumn(table: "dbo.Teachers", name: "TeacherId", newName: "SSN");
            RenameColumn(table: "dbo.Students", name: "StudentId", newName: "SSN");
            CreateIndex("dbo.TeacherCourses", "TeacherId");
            CreateIndex("dbo.Students", "ParentId");
            CreateIndex("dbo.Results", "StudentId");
            CreateIndex("dbo.Sessions", "TeacherId");
            CreateIndex("dbo.Attendences", "StudentId");
            AddForeignKey("dbo.Results", "StudentId", "dbo.Students", "SSN", cascadeDelete: true);
            AddForeignKey("dbo.Attendences", "StudentId", "dbo.Students", "SSN", cascadeDelete: true);
            AddForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers", "SSN", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ParentId", "dbo.Parents", "ParentId", cascadeDelete: true);
            AddForeignKey("dbo.Sessions", "TeacherId", "dbo.Teachers", "SSN", cascadeDelete: true);
        }
    }
}
