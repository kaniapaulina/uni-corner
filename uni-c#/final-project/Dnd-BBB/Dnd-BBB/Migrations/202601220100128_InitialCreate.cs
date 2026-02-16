namespace Dnd_BBB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        PartyId = c.Int(nullable: false),
                        SpellsJson = c.String(),
                        ProficienciesJson = c.String(),
                        EquipmentJson = c.String(),
                        Name = c.String(),
                        Gold = c.Int(nullable: false),
                        Hp = c.Int(nullable: false),
                        Ac = c.Int(nullable: false),
                        Cons = c.Int(nullable: false),
                        Dext = c.Int(nullable: false),
                        Str = c.Int(nullable: false),
                        Wis = c.Int(nullable: false),
                        Intel = c.Int(nullable: false),
                        Charm = c.Int(nullable: false),
                        UnitRaceName = c.String(),
                        UnitClassName = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        PartyId = c.Int(nullable: false, identity: true),
                        PartyName = c.String(),
                    })
                .PrimaryKey(t => t.PartyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "PartyId", "dbo.Parties");
            DropIndex("dbo.Characters", new[] { "PartyId" });
            DropTable("dbo.Parties");
            DropTable("dbo.Characters");
        }
    }
}
