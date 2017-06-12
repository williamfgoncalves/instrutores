namespace EditoraCrescer.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandoRevisorEDataRevisaoParaNulo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Livros", "IdRevisor", "dbo.Revisores");
            DropIndex("dbo.Livros", new[] { "IdRevisor" });
            AlterColumn("dbo.Livros", "IdRevisor", c => c.Int());
            AlterColumn("dbo.Livros", "DataRevisao", c => c.DateTime());
            CreateIndex("dbo.Livros", "IdRevisor");
            AddForeignKey("dbo.Livros", "IdRevisor", "dbo.Revisores", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livros", "IdRevisor", "dbo.Revisores");
            DropIndex("dbo.Livros", new[] { "IdRevisor" });
            AlterColumn("dbo.Livros", "DataRevisao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Livros", "IdRevisor", c => c.Int(nullable: false));
            CreateIndex("dbo.Livros", "IdRevisor");
            AddForeignKey("dbo.Livros", "IdRevisor", "dbo.Revisores", "Id", cascadeDelete: true);
        }
    }
}
