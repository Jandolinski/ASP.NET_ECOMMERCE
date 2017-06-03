namespace ASP.NET_ECOMMERCE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataProvidersandBootstrapper : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", new[] { "CategoryId", "ProducerId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "Id");
        }
    }
}
