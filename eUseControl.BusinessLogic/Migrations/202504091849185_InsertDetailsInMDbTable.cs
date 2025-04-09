namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDetailsInMDbTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "Details", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memberships", "Details");
        }
    }
}
