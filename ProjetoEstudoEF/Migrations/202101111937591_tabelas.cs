namespace ProjetoEstudoEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anuncios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.DateTime(nullable: false),
                        PessoaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pessoas", t => t.PessoaID, cascadeDelete: true)
                .Index(t => t.PessoaID);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        ConfirmarSenha = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anuncios", "PessoaID", "dbo.Pessoas");
            DropIndex("dbo.Anuncios", new[] { "PessoaID" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.Anuncios");
        }
    }
}
