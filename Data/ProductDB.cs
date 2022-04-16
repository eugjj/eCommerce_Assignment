using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommence_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommence_Assignment.Data
{
    public class ProductDB
    {
        private DBContext dbContext;

        public ProductDB(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SeedProducts()
        {
            dbContext.Add(new Products
            {
                Name = "Microsoft 365 Family Basic",
                Price = 128,
                ImageUrl = "/images/m365_family.png",
                Description = "Create inspiring documents with smart assistance features in Word, Excel & PowerPoint​",
                Brand = "Microsoft"
            });
            dbContext.Add(new Products
            {
                Name = "Microsoft 365 Business",
                Price = 218,
                ImageUrl = "/images/m365_business.png",
                Description = "Create inspiring documents with smart assistance features in Word, Excel, PowerPoint​ and email support with Outlook",
                Brand = "Microsoft"
            });
            dbContext.Add(new Products
            {
                Name = "ASP.Net Core",
                Price = 39,
                ImageUrl = "/images/netcore.png",
                Description = "An open-source, managed computer software framework for Windows, Linux, and macOS operating systems",
                Brand = "Microsoft"
            });
            dbContext.Add(new Products
            {
                Name = "ASP.Net Framework",
                Price = 29,
                ImageUrl = "/images/netframework.png",
                Description = "A proprietary software framework developed by Microsoft that runs primarily on Windows",
                Brand = "Microsoft"
            });
            dbContext.Add(new Products
            {
                Name = "SQL Server Management Studio",
                Price = 49,
                ImageUrl = "/images/sql.jpg",
                Description = "Configure, managage, and administer all database components within Microsoft SQL Server",
                Brand = "Microsoft"
            });
            dbContext.Add(new Products
            {
                Name = "Acrobat DC Pro",
                Price = 148,
                ImageUrl = "/images/acrobat.jpg",
                Description = "All you need to convert, sign, edit & manage PDF documents on any device",
                Brand = "Adobe"
            });
            dbContext.Add(new Products
            {
                Name = "Adobe Photoshop",
                Price = 320,
                ImageUrl = "/images/photoshop.jpg",
                Description = "From social posts to photo retouching, banners to beautiful websites, everyday image edits to total transformations",
                Brand = "Adobe"
            });
            dbContext.Add(new Products
            {
                Name = "Flutter SDK",
                Price = 29,
                ImageUrl = "/images/flutter.png",
                Description = "Develop cross platform applications for Android, iOS, Linux, macOS, Windows and the web from a single codebase",
                Brand = "Google"
            });
            dbContext.Add(new Products
            {
                Name = "Xcode",
                Price = 18,
                ImageUrl = "/images/xcode.png",
                Description = "Apple's integrated development environment for macOS, used to develop software for macOS and iOS",
                Brand = "Apple"
            });

            dbContext.SaveChanges();

        }
    }
}
