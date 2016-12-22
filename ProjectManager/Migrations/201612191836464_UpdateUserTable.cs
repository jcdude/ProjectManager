namespace ProjectManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "First", c => c.String());
            AddColumn("dbo.AspNetUsers", "Last", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Last");
            DropColumn("dbo.AspNetUsers", "First");
        }
    }
}
