namespace HumanResourceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jashim3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "CountryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "CountryName", c => c.Int(nullable: false));
        }
    }
}
