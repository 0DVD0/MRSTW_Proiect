namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DeleteExpDateFromUserMembershipTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserMemberships", "ExpirationDate");
        }

        public override void Down()
        {
            
            AddColumn("dbo.UserMemberships", "ExpirationDate", c => c.DateTime(nullable: true));
        }
    }
}
