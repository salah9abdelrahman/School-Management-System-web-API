namespace School_managment_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dgsssd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "Parent_ParentSNN", newName: "ParentSNN");
            RenameIndex(table: "dbo.Students", name: "IX_Parent_ParentSNN", newName: "IX_ParentSNN");
            DropColumn("dbo.Students", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ParentId", c => c.String());
            RenameIndex(table: "dbo.Students", name: "IX_ParentSNN", newName: "IX_Parent_ParentSNN");
            RenameColumn(table: "dbo.Students", name: "ParentSNN", newName: "Parent_ParentSNN");
        }
    }
}
