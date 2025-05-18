namespace eUseControl.BusinessLogic.Migrations
{
     using System;
     using System.Data.Entity.Migrations;

     public partial class UpdateExpirationDateType : DbMigration
     {
          public override void Up()
          {
               AlterColumn("dbo.UserMemberships", "MembershipExperationDate", c => c.DateTime());
          }

          public override void Down()
          {
               // Be careful: reverting to non-nullable will fail if nulls exist
               AlterColumn("dbo.UserMemberships", "MembershipExperationDate", c => c.DateTime(nullable: false));
          }
     }
}

