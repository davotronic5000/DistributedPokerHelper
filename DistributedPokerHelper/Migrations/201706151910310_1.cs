namespace DistributedPokerHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tournament", "Name", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Tournament", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tournament", new[] { "Name" });
            AlterColumn("dbo.Tournament", "Name", c => c.String());
        }
    }
}
