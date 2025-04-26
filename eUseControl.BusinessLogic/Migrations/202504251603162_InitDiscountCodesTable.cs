namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDiscountCodesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountCodes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DiscountCode = c.String(),
                    DiscountPercentage = c.Decimal(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.DiscountCodes");
        }
    }
}
