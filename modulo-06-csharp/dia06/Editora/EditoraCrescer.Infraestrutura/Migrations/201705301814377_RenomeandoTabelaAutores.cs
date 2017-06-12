namespace EditoraCrescer.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenomeandoTabelaAutores : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Autors", newName: "Autores");
            AlterColumn("dbo.Autores", "Nome", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Autores", "Nome", c => c.String());
            RenameTable(name: "dbo.Autores", newName: "Autors");
        }
    }
}
