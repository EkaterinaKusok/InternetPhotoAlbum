namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChange3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
