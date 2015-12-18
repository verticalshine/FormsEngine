namespace FormsEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.Int(nullable: false),
                        Submitter = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ProcedureDate = c.DateTime(nullable: false),
                        TheData = c.String(),
                        Form_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Form", t => t.Form_Id)
                .Index(t => t.Form_Id);
            
            CreateTable(
                "dbo.Form",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormName = c.String(),
                        Version = c.Int(nullable: false),
                        Schema = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormData", "Form_Id", "dbo.Form");
            DropIndex("dbo.FormData", new[] { "Form_Id" });
            DropTable("dbo.Form");
            DropTable("dbo.FormData");
        }
    }
}
