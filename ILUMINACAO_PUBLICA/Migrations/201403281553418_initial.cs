namespace ILUMINACAO_PUBLICA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PosMenu1 = c.Int(),
                        PosMenu2 = c.Int(),
                        PosMenu3 = c.Int(),
                        PrefeituraId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Ocorrencia",
                c => new
                    {
                        OcorrenciaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PrefeituraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OcorrenciaID)
                .ForeignKey("dbo.Prefeitura", t => t.PrefeituraId)
                .Index(t => t.PrefeituraId);
            
            CreateTable(
                "dbo.Prefeitura",
                c => new
                    {
                        PrefeituraID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.PrefeituraID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ocorrencia", new[] { "PrefeituraId" });
            DropForeignKey("dbo.Ocorrencia", "PrefeituraId", "dbo.Prefeitura");
            DropTable("dbo.Prefeitura");
            DropTable("dbo.Ocorrencia");
            DropTable("dbo.UserProfile");
        }
    }
}
