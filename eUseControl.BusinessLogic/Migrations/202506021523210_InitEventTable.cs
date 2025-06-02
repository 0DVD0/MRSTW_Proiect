namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitEventTable : DbMigration
    {
        public override void Up()
        {
               CreateTable(
               "dbo.Events",
               c => new
               {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(),
                    Action = c.String(),
                    EventTime = c.DateTime(nullable: false),
               })
               .PrimaryKey(t => t.Id);
          }
        
        public override void Down()
        {
               DropTable("dbo.Events");
          }
    }
}
