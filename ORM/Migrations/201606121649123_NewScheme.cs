namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewScheme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        UserRating = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.UserProfileId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserPhoto = c.Binary(),
                        DateOfBirth = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            AddColumn("dbo.Photos", "Image", c => c.Binary());
            AddColumn("dbo.Photos", "UserProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Photos", "Name", c => c.String());
            CreateIndex("dbo.Photos", "UserProfileId");
            AddForeignKey("dbo.Photos", "UserProfileId", "dbo.UserProfiles", "Id");
            DropColumn("dbo.Photos", "UserId");
            DropColumn("dbo.Photos", "Content");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Photos", "Content", c => c.Binary());
            AddColumn("dbo.Photos", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ratings", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Photos", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropIndex("dbo.Ratings", new[] { "PhotoId" });
            DropIndex("dbo.Ratings", new[] { "UserProfileId" });
            DropIndex("dbo.Photos", new[] { "UserProfileId" });
            AlterColumn("dbo.Photos", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Users", "CreationDate");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Photos", "UserProfileId");
            DropColumn("dbo.Photos", "Image");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Ratings");
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.Photos", "UserId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            AddForeignKey("dbo.Photos", "UserId", "dbo.Users", "Id");
        }
    }
}
