namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CategoriesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Category", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "ParentId", "dbo.Category");
            DropIndex("dbo.Category", new[] { "ParentId" });
            DropTable("dbo.Category");
        }
    }
}
