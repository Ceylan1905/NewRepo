namespace zeynerp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModulesTableProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modules", "ModuleName", c => c.String(nullable: false));
            AlterColumn("dbo.Modules", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Modules", "Price", c => c.String(nullable: false));
            AlterColumn("dbo.Modules", "CurrencyUnit", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modules", "CurrencyUnit", c => c.String());
            AlterColumn("dbo.Modules", "Price", c => c.String());
            AlterColumn("dbo.Modules", "Status", c => c.String());
            AlterColumn("dbo.Modules", "ModuleName", c => c.String());
        }
    }
}
