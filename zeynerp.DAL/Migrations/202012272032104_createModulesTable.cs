namespace zeynerp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createModulesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        Order = c.Int(nullable: false),
                        Status = c.String(),
                        Price = c.String(),
                        CurrencyUnit = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Modules", new[] { "CategoryId" });
            DropTable("dbo.Modules");
        }
    }
}
