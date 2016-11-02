namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreeHelper : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Supplier", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supplier", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
        }
    }
}
