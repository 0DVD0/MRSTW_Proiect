namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFeedBakcTable : DbMigration
    {
        public override void Up()
        {
               Sql(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeedbackDbTables]') AND type = 'U')
                    AND NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedbacks]') AND type = 'U')
                BEGIN
                    EXEC sp_rename 'dbo.FeedbackDbTables', 'Feedbacks';
                END
            ");
          }
        
        public override void Down()
        {
               Sql(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedbacks]') AND type = 'U')
                    AND NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeedbackDbTables]') AND type = 'U')
                BEGIN
                    EXEC sp_rename 'dbo.Feedbacks', 'FeedbackDbTables';
                END
            ");
          }
    }
}
