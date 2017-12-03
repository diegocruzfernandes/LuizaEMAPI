namespace LuizaEMAPI.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false, maxLength: 200),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Department_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Department_Id);
            
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 32, fixedLength: true));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Department_Id", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_Id" });
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            RenameTable(name: "dbo.User", newName: "Users");
        }
    }
}
