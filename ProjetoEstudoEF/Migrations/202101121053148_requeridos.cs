namespace ProjetoEstudoEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requeridos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "ConfirmarSenha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "ConfirmarSenha", c => c.String());
            AlterColumn("dbo.Pessoas", "Senha", c => c.String());
            AlterColumn("dbo.Pessoas", "Email", c => c.String());
            AlterColumn("dbo.Pessoas", "Nome", c => c.String());
        }
    }
}
