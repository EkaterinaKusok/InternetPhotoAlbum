namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableUserRoles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoleUsers", newName: "UserRoles");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            RenameColumn(table: "dbo.UserRoles", name: "Role_Id", newName: "RoleId");
            RenameColumn(table: "dbo.UserRoles", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.UserRoles", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserRoles", name: "IX_Role_Id", newName: "IX_RoleId");
            DropPrimaryKey("dbo.UserRoles");
            AddPrimaryKey("dbo.UserRoles", new[] { "UserId", "RoleId" });
            AddForeignKey("dbo.Photos", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.UserRoles");
            AddPrimaryKey("dbo.UserRoles", new[] { "Role_Id", "User_Id" });
            RenameIndex(table: "dbo.UserRoles", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameIndex(table: "dbo.UserRoles", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.UserRoles", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserRoles", name: "RoleId", newName: "Role_Id");
            AddForeignKey("dbo.Photos", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.UserRoles", newName: "RoleUsers");
        }
    }
}
