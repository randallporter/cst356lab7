namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventDate = c.DateTime(nullable: false),
                        EventDateEnd = c.DateTime(nullable: false),
                        EventName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Event_EventID })
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Event_EventID);
            
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.User_ID })
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Group_GroupID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.GroupUsers", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.UserEvents", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.UserEvents", "User_ID", "dbo.Users");
            DropIndex("dbo.GroupUsers", new[] { "User_ID" });
            DropIndex("dbo.GroupUsers", new[] { "Group_GroupID" });
            DropIndex("dbo.UserEvents", new[] { "Event_EventID" });
            DropIndex("dbo.UserEvents", new[] { "User_ID" });
            DropTable("dbo.GroupUsers");
            DropTable("dbo.UserEvents");
            DropTable("dbo.Groups");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}
