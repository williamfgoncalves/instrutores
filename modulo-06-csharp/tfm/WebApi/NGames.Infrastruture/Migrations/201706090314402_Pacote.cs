namespace NGames.Infrastruture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pacote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacote", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Reserva", "TotalOpcionais", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserva", "TotalOpcionais");
            DropColumn("dbo.Pacote", "Valor");
        }
    }
}
