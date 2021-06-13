namespace EvidencijaAvioKarata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopunjavanjeKlase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Klasa (Id, Naziv) VALUES (1, 'Prva klasa')");
            Sql("INSERT INTO Klasa (Id, Naziv) VALUES (2, 'Biznis klasa')");
            Sql("INSERT INTO Klasa (Id, Naziv) VALUES (3, 'Ekonomska klasa')");
        }
        
        public override void Down()
        {
        }
    }
}
