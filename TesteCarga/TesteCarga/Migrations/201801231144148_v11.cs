namespace TesteCarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 80));
            DropColumn("dbo.User", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Nome", c => c.String(nullable: false, maxLength: 80));
            DropColumn("dbo.User", "Name");
        }
    }
}
