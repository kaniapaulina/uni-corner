namespace ZespolBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CzlonekZespolus",
                c => new
                    {
                        CzłonekZespoluld = c.Int(nullable: false, identity: true),
                        ZespolId = c.Int(nullable: false),
                        DataWstapienia = c.DateTime(nullable: false),
                        FunkcjaWZespole = c.String(),
                        Aktywny = c.Boolean(nullable: false),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Adres = c.String(),
                        DataUrodzenia = c.DateTime(nullable: false),
                        Pesel = c.String(),
                        Plec = c.Int(nullable: false),
                        Zespol_ZespolId = c.Int(),
                        Zespol_ZespolId1 = c.Int(),
                        Zespol_ZespolId2 = c.Int(),
                    })
                .PrimaryKey(t => t.CzłonekZespoluld)
                .ForeignKey("dbo.Zespols", t => t.Zespol_ZespolId)
                .ForeignKey("dbo.Zespols", t => t.Zespol_ZespolId1)
                .ForeignKey("dbo.Zespols", t => t.Zespol_ZespolId2)
                .Index(t => t.Zespol_ZespolId)
                .Index(t => t.Zespol_ZespolId1)
                .Index(t => t.Zespol_ZespolId2);
            
            CreateTable(
                "dbo.Zespols",
                c => new
                    {
                        ZespolId = c.Int(nullable: false, identity: true),
                        LiczbaAktywnychCzlonkowZespolu = c.Int(nullable: false),
                        NazwaZespolu = c.String(),
                        Kierownik_KierownikZespoluId = c.Int(),
                        KierownikZespolu_KierownikZespoluId = c.Int(),
                    })
                .PrimaryKey(t => t.ZespolId)
                .ForeignKey("dbo.KierownikZespolus", t => t.Kierownik_KierownikZespoluId)
                .ForeignKey("dbo.KierownikZespolus", t => t.KierownikZespolu_KierownikZespoluId)
                .Index(t => t.Kierownik_KierownikZespoluId)
                .Index(t => t.KierownikZespolu_KierownikZespoluId);
            
            CreateTable(
                "dbo.KierownikZespolus",
                c => new
                    {
                        KierownikZespoluId = c.Int(nullable: false, identity: true),
                        LiczbaProjektow = c.Int(nullable: false),
                        DoswiadczenieKierownika = c.Int(nullable: false),
                        TelefonKontaktowy = c.Long(nullable: false),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Adres = c.String(),
                        DataUrodzenia = c.DateTime(nullable: false),
                        Pesel = c.String(),
                        Plec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KierownikZespoluId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CzlonekZespolus", "Zespol_ZespolId2", "dbo.Zespols");
            DropForeignKey("dbo.Zespols", "KierownikZespolu_KierownikZespoluId", "dbo.KierownikZespolus");
            DropForeignKey("dbo.Zespols", "Kierownik_KierownikZespoluId", "dbo.KierownikZespolus");
            DropForeignKey("dbo.CzlonekZespolus", "Zespol_ZespolId1", "dbo.Zespols");
            DropForeignKey("dbo.CzlonekZespolus", "Zespol_ZespolId", "dbo.Zespols");
            DropIndex("dbo.Zespols", new[] { "KierownikZespolu_KierownikZespoluId" });
            DropIndex("dbo.Zespols", new[] { "Kierownik_KierownikZespoluId" });
            DropIndex("dbo.CzlonekZespolus", new[] { "Zespol_ZespolId2" });
            DropIndex("dbo.CzlonekZespolus", new[] { "Zespol_ZespolId1" });
            DropIndex("dbo.CzlonekZespolus", new[] { "Zespol_ZespolId" });
            DropTable("dbo.KierownikZespolus");
            DropTable("dbo.Zespols");
            DropTable("dbo.CzlonekZespolus");
        }
    }
}
