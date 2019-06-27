namespace School_managment_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendences", "ClassRoom_ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.Attendences", new[] { "ClassRoom_ClassRoomId" });
            DropColumn("dbo.Attendences", "ClassRoom_ClassRoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendences", "ClassRoom_ClassRoomId", c => c.Int());
            CreateIndex("dbo.Attendences", "ClassRoom_ClassRoomId");
            AddForeignKey("dbo.Attendences", "ClassRoom_ClassRoomId", "dbo.ClassRooms", "ClassRoomId");
        }
    }
}
