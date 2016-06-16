namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallCanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Photos", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.Users");
            AddColumn("dbo.Photos", "TotalRate", c => c.Int(nullable: false));
            AddColumn("dbo.Photos", "CreationDate", c => c.DateTime(nullable: false));
            AddForeignKey("dbo.Ratings", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Photos", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProfiles", "Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.Users");
            DropForeignKey("dbo.Photos", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Ratings", "PhotoId", "dbo.Photos");
            DropColumn("dbo.Photos", "CreationDate");
            DropColumn("dbo.Photos", "TotalRate");
            AddForeignKey("dbo.UserProfiles", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Photos", "UserProfileId", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.Ratings", "PhotoId", "dbo.Photos", "Id");
        }
    }
}
