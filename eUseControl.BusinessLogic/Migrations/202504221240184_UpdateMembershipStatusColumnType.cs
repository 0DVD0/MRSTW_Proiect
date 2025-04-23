namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipStatusColumnType : DbMigration
    {
     
            public override void Up()
            {
          
                AlterColumn("dbo.Users", "MembershipStatus", c => c.Boolean(nullable: false, defaultValue: false));
            }

            public override void Down()
            {
               
                AlterColumn("dbo.Users", "MembershipStatus", c => c.Int(nullable: false, defaultValue: 0));
            }
        }

}
