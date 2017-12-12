namespace OneOff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gig", "IsRequest", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gig", "IsRequest");
        }
    }
}
