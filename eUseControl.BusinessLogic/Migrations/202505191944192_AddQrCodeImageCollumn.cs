namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQrCodeImageCollumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMemberships", "QrCodeImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMemberships", "QrCodeImage");
        }
    }
}
