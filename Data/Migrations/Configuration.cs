namespace Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext ctx)
        {

            var suppliersArray = new[]
            {
                new Supplier { Name = "Supplier One", CreatedDate = DateTime.UtcNow },
                new Supplier { Name = "Supplier Two", CreatedDate = DateTime.UtcNow },
                new Supplier { Name = "Supplier Three", CreatedDate = DateTime.UtcNow },
                new Supplier { Name = "Supplier Four", CreatedDate = DateTime.UtcNow },
                new Supplier { Name = "Supplier Five", CreatedDate = DateTime.UtcNow }
            };

            ctx.Suppliers.AddOrUpdate(
                s => s.Id,
                suppliersArray
            );

            ctx.Products.AddOrUpdate(
                p => p.Id,
                new Product { Name = "Product One", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[0] },
                new Product { Name = "Product Two", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[0] },
                new Product { Name = "Product Three", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[1] },
                new Product { Name = "Product Four", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[1] },
                new Product { Name = "Product Five", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[2] },
                new Product { Name = "Product Six", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[2] },
                new Product { Name = "Product Seven", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[3] },
                new Product { Name = "Product Eight", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[3] },
                new Product { Name = "Product Nine", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[4] },
                new Product { Name = "Product Ten", CreatedDate = DateTime.UtcNow, Supplier = suppliersArray[4] }
            );

            var categoriesArray = new[]
            {
                new Category { Name="Category One", CreatedDate = DateTime.UtcNow },
                new Category { Name="Category Two", CreatedDate = DateTime.UtcNow },
                new Category { Name="Category Three", CreatedDate = DateTime.UtcNow },
                new Category { Name="Category Four", CreatedDate = DateTime.UtcNow },
                new Category { Name="Category Five", CreatedDate = DateTime.UtcNow },
                new Category { Name="Category Six", CreatedDate = DateTime.UtcNow },
                new Category { Name="Category Seven", CreatedDate = DateTime.UtcNow }
            };

            categoriesArray[1].Parent = categoriesArray[0];
            categoriesArray[2].Parent = categoriesArray[0];
            categoriesArray[4].Parent = categoriesArray[3];
            categoriesArray[5].Parent = categoriesArray[3];
            categoriesArray[6].Parent = categoriesArray[3];

            ctx.Categories.AddOrUpdate(
                c => c.Id,
                categoriesArray
            );

            ctx.SaveChanges();
        }
    }
}
