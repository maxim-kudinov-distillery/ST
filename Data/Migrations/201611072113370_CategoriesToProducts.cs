namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriesToProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id })
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.ProductCategory", "Product_Id", "dbo.Product");
            DropIndex("dbo.ProductCategory", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategory", new[] { "Product_Id" });
            DropTable("dbo.ProductCategory");
        }
    }
}
