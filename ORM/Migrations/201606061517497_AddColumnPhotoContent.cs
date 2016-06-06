namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPhotoContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Content", c => c.Binary());
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Photos", "Content");
        }
    }
}
