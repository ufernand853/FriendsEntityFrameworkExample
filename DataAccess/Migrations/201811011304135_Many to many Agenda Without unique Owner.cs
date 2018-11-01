namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManytomanyAgendaWithoutuniqueOwner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "Owner_Id", "dbo.Users");
            DropIndex("dbo.Agenda", new[] { "Owner_Id" });
            DropColumn("dbo.Agenda", "Owner_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agenda", "Owner_Id", c => c.Guid());
            CreateIndex("dbo.Agenda", "Owner_Id");
            AddForeignKey("dbo.Agenda", "Owner_Id", "dbo.Users", "Id");
        }
    }
}
