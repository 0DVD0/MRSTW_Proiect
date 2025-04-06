namespace eUseControl.BusinessLogic.Migrations
{
     using System;
     using System.Data.Entity;
     using System.Data.Entity.Migrations;
     using System.Linq;
     using eUseControl.Domain.Entities.User;
     using eUseControl.Helper.AssistingLogic;

     internal sealed class Configuration : DbMigrationsConfiguration<eUseControl.BusinessLogic.DBModel.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eUseControl.BusinessLogic.DBModel.UserContext context)
        {

          }
     }
}
