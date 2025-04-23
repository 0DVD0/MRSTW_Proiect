namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitMembershipsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MembershipName = c.String(nullable: false, maxLength: 50),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Details = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Memberships");
        }
    }
}
