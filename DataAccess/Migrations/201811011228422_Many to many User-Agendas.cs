namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManytomanyUserAgendas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "User_Id", c => c.Guid());
            CreateIndex("dbo.Agenda", "User_Id");
            AddForeignKey("dbo.Agenda", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "User_Id", "dbo.Users");
            DropIndex("dbo.Agenda", new[] { "User_Id" });
            DropColumn("dbo.Agenda", "User_Id");
        }
    }
}
