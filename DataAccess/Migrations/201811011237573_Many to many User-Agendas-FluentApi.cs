namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManytomanyUserAgendasFluentApi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Agenda_Id", "dbo.Agenda");
            DropIndex("dbo.Agenda", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Agenda_Id" });
            CreateTable(
                "dbo.UserAgenda",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Agenda_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Agenda_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Agenda", t => t.Agenda_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Agenda_Id);
            
            DropColumn("dbo.Agenda", "User_Id");
            DropColumn("dbo.Users", "Agenda_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Agenda_Id", c => c.Guid());
            AddColumn("dbo.Agenda", "User_Id", c => c.Guid());
            DropForeignKey("dbo.UserAgenda", "Agenda_Id", "dbo.Agenda");
            DropForeignKey("dbo.UserAgenda", "User_Id", "dbo.Users");
            DropIndex("dbo.UserAgenda", new[] { "Agenda_Id" });
            DropIndex("dbo.UserAgenda", new[] { "User_Id" });
            DropTable("dbo.UserAgenda");
            CreateIndex("dbo.Users", "Agenda_Id");
            CreateIndex("dbo.Agenda", "User_Id");
            AddForeignKey("dbo.Users", "Agenda_Id", "dbo.Agenda", "Id");
            AddForeignKey("dbo.Agenda", "User_Id", "dbo.Users", "Id");
        }
    }
}
