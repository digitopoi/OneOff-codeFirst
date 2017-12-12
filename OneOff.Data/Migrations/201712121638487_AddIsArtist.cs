namespace OneOff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "IsArtist", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "IsArtist");
        }
    }
}
