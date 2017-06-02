namespace EditoraCrescer.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoDataPublicacaoNulo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livros", "DataPublicacao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Livros", "DataPublicacao", c => c.DateTime(nullable: false));
        }
    }
}
