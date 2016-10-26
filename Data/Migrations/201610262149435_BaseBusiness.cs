namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseBusiness : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Category", "CategoryId", "Id");
            RenameColumn("dbo.Product", "ProductId", "Id");
            RenameColumn("dbo.Supplier" ,"SupplierId", "Id");

            AddColumn("dbo.Category", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Category", "Id", "CategoryId");
            RenameColumn("dbo.Product", "Id", "ProductId");
            RenameColumn("dbo.Supplier", "Id", "SupplierId");
        }
    }
}
