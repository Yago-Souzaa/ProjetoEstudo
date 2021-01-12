namespace ProjetoEstudoEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Senha", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Pessoas", "ConfirmarSenha", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "ConfirmarSenha", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "Senha", c => c.String(nullable: false));
        }
    }
}
