namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMDbTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Memberships",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Name = c.String(nullable: false, maxLength: 50),
                   Price = c.Double(nullable: false)
               })
               .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Memberships");
        }
    }
}
