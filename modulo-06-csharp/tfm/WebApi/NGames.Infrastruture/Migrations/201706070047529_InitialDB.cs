namespace NGames.Infrastruture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        DtNascimento = c.DateTime(nullable: false),
                        Genero = c.Byte(nullable: false),
                        Endereco_Logradouro = c.String(nullable: false, maxLength: 256),
                        Endereco_Cidade = c.String(nullable: false, maxLength: 256),
                        Endereco_Estado = c.String(nullable: false, maxLength: 2),
                        Endereco_Cep = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cpf, unique: true, name: "IX_Cliente_Cpf");
            
            CreateTable(
                "dbo.Opcional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256),
                        Quantidade = c.Int(nullable: false),
                        Diaria = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256),
                        Desconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true, name: "IX_Permissao_Nome");
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256),
                        Quantidade = c.Int(nullable: false),
                        Diaria = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservaOpcional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        IdOpcional = c.Int(nullable: false),
                        IdReserva = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Opcional", t => t.IdOpcional, cascadeDelete: true)
                .ForeignKey("dbo.Reserva", t => t.IdReserva, cascadeDelete: true)
                .Index(t => t.IdOpcional)
                .Index(t => t.IdReserva);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalReserva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DtReserva = c.DateTime(nullable: false),
                        DtEntrega = c.DateTime(nullable: false),
                        Diarias = c.Int(nullable: false),
                        Multa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_Id = c.Int(nullable: false),
                        Pacote_Id = c.Int(),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pacote", t => t.Pacote_Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Pacote_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false, maxLength: 160),
                        Senha = c.String(maxLength: 32, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "IX_Usuario_Email");
            
            CreateTable(
                "dbo.UsuarioPermisao",
                c => new
                    {
                        IdUsuario = c.Guid(nullable: false),
                        IdPermissao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdUsuario, t.IdPermissao })
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .ForeignKey("dbo.Permissao", t => t.IdPermissao, cascadeDelete: true)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdPermissao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioPermisao", "IdPermissao", "dbo.Permissao");
            DropForeignKey("dbo.UsuarioPermisao", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.ReservaOpcional", "IdReserva", "dbo.Reserva");
            DropForeignKey("dbo.Reserva", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.Reserva", "Pacote_Id", "dbo.Pacote");
            DropForeignKey("dbo.Reserva", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.ReservaOpcional", "IdOpcional", "dbo.Opcional");
            DropIndex("dbo.UsuarioPermisao", new[] { "IdPermissao" });
            DropIndex("dbo.UsuarioPermisao", new[] { "IdUsuario" });
            DropIndex("dbo.Usuario", "IX_Usuario_Email");
            DropIndex("dbo.Reserva", new[] { "Produto_Id" });
            DropIndex("dbo.Reserva", new[] { "Pacote_Id" });
            DropIndex("dbo.Reserva", new[] { "Cliente_Id" });
            DropIndex("dbo.ReservaOpcional", new[] { "IdReserva" });
            DropIndex("dbo.ReservaOpcional", new[] { "IdOpcional" });
            DropIndex("dbo.Permissao", "IX_Permissao_Nome");
            DropIndex("dbo.Cliente", "IX_Cliente_Cpf");
            DropTable("dbo.UsuarioPermisao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Reserva");
            DropTable("dbo.ReservaOpcional");
            DropTable("dbo.Produto");
            DropTable("dbo.Permissao");
            DropTable("dbo.Pacote");
            DropTable("dbo.Opcional");
            DropTable("dbo.Cliente");
        }
    }
}
