namespace eUseControl.BusinessLogic.Migrations
{
     using System;
     using System.Data.Entity.Migrations;

     public partial class UpdateODbTableDefinition : DbMigration
     {
          public override void Up()
          {
               // Rename FeedbackDbTable → Feedbacks only if Feedbacks doesn't already exist
               Sql(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeedbackDbTable]') AND type = 'U')
                    AND NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedbacks]') AND type = 'U')
                BEGIN
                    EXEC sp_rename 'dbo.FeedbackDbTable', 'Feedbacks';
                END
            ");

               // Rename ODbTables → Orders only if Orders doesn't already exist
               Sql(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ODbTables]') AND type = 'U')
                    AND NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type = 'U')
                BEGIN
                    EXEC sp_rename 'dbo.ODbTables', 'Orders';
                END
            ");

               // Add column UserId to Orders if not already there
               Sql(@"
                IF NOT EXISTS (
                    SELECT * FROM sys.columns 
                    WHERE Name = N'UserId' AND Object_ID = Object_ID(N'dbo.Orders')
                )
                BEGIN
                    ALTER TABLE dbo.Orders ADD UserId INT NULL;
                END
            ");
          }

          public override void Down()
          {
               // Drop column only if it exists
               Sql(@"
                IF EXISTS (
                    SELECT * FROM sys.columns 
                    WHERE Name = N'UserId' AND Object_ID = Object_ID(N'dbo.Orders')
                )
                BEGIN
                    ALTER TABLE dbo.Orders DROP COLUMN UserId;
                END
            ");

               // Rename Orders → ODbTables only if ODbTables doesn't already exist
               Sql(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type = 'U')
                    AND NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ODbTables]') AND type = 'U')
                BEGIN
                    EXEC sp_rename 'dbo.Orders', 'ODbTables';
                END
            ");

               // Rename Feedbacks → FeedbackDbTable only if FeedbackDbTable doesn't already exist
               Sql(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedbacks]') AND type = 'U')
                    AND NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeedbackDbTable]') AND type = 'U')
                BEGIN
                    EXEC sp_rename 'dbo.Feedbacks', 'FeedbackDbTable';
                END
            ");
          }
     }
}
