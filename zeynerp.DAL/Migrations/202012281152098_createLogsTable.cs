namespace zeynerp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createLogsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner = c.String(),
                        Comment = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.ModuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Logs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Logs", new[] { "ModuleId" });
            DropIndex("dbo.Logs", new[] { "CategoryId" });
            DropTable("dbo.Logs");
        }
    }
}
