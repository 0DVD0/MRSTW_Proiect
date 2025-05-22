namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialityToCoaches : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coaches", "Speciality", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coaches", "Speciality");
        }
    }
}
