namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdInODBtable : DbMigration
    {
        public override void Up()
        {
               AddColumn("dbo.ODbTables", "UserID", c => c.Int());
               AddColumn("dbo.Orders", "UserID", c => c.Int());
          }
        
        public override void Down()
        {
               DropColumn("dbo.ODbTables", "UserID");
               DropColumn("dbo.Orders", "UserID");
          }
    }
}
