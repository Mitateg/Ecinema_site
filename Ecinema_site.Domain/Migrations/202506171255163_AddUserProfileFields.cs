namespace Ecinema_site.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsPremium", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Movies", "ApplicationUser_Id");
            AddForeignKey("dbo.Movies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "IsPremium");
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Movies", "ApplicationUser_Id");
        }
    }
}
