namespace zeynerp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLogsTableProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Price", c => c.String());
            AddColumn("dbo.Logs", "UpdatedDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "UpdatedDate");
            DropColumn("dbo.Logs", "Price");
        }
    }
}
