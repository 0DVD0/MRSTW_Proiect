namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipStatusToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MembershipStatus", c => c.Int(nullable: false, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "MembershipStatus");
        }
    }
}
