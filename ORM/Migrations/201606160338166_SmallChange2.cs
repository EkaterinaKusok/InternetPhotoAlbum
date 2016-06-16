namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChange2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "TotalRating", c => c.Int(nullable: false));
            DropColumn("dbo.Photos", "TotalRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "TotalRate", c => c.Int(nullable: false));
            DropColumn("dbo.Photos", "TotalRating");
        }
    }
}
