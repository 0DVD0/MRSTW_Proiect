namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserSchema : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "LoginDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "LoginDateTime", c => c.DateTime(nullable: false));
        }
    }
}
