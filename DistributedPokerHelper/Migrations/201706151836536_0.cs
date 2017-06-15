namespace DistributedPokerHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlindRound",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        TotalInSeconds = c.Int(nullable: false),
                        TournamentEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournament", t => t.TournamentEntity_Id)
                .Index(t => t.TournamentEntity_Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        TableEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameTable", t => t.TableEntity_Id)
                .Index(t => t.TableEntity_Id);
            
            CreateTable(
                "dbo.GameTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournament", t => t.TournamentEntity_Id)
                .Index(t => t.TournamentEntity_Id);
            
            CreateTable(
                "dbo.Tournament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CurrentBlindRound_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlindRound", t => t.CurrentBlindRound_Id)
                .Index(t => t.CurrentBlindRound_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameTable", "TournamentEntity_Id", "dbo.Tournament");
            DropForeignKey("dbo.BlindRound", "TournamentEntity_Id", "dbo.Tournament");
            DropForeignKey("dbo.Tournament", "CurrentBlindRound_Id", "dbo.BlindRound");
            DropForeignKey("dbo.Player", "TableEntity_Id", "dbo.GameTable");
            DropIndex("dbo.Tournament", new[] { "CurrentBlindRound_Id" });
            DropIndex("dbo.Tournament", new[] { "Name" });
            DropIndex("dbo.GameTable", new[] { "TournamentEntity_Id" });
            DropIndex("dbo.Player", new[] { "TableEntity_Id" });
            DropIndex("dbo.BlindRound", new[] { "TournamentEntity_Id" });
            DropTable("dbo.Tournament");
            DropTable("dbo.GameTable");
            DropTable("dbo.Player");
            DropTable("dbo.BlindRound");
        }
    }
}
