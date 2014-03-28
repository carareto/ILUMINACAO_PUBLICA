namespace ILUMINACAO_PUBLICA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merge : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "PrefeituraID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "PrefeituraId", c => c.Int());
        }
    }
}
