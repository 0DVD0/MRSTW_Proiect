namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipPurchaseDateToUserMembership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMemberships", "MembershipPurchaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMemberships", "MembershipPurchaseDate");
        }
    }
}
