namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAddASPNETID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AspNetID", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AspNetID");
        }
    }
}
