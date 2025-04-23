namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitOrderdsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 50),
                    MembershipName = c.String(nullable: false, maxLength: 50),
                    OrderDate = c.DateTime(nullable: false),
                    TotalPrice = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
