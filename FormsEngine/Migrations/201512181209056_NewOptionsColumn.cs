namespace FormsEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOptionsColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Form", "Options", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Form", "Options");
        }
    }
}
