namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipStatusToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MembershipStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "MembershipStatus");
        }
    }
}
