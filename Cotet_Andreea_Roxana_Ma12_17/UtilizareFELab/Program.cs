using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilizareFELab
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Pentru primul scenariu
             * using(var db = new ModelSelfReferences())
            {
                var reference = new SelfReference()
                {
                    Name = "Reference"
                };

                db.SelfReferences.Add(reference);
                db.SaveChanges();
                Console.Write("Reference successfully added");
            }*/

            /* Pentru al doilea scenariu
            using(var db = new ModelProduct())
            {
                var product = new Product
                {
                    SKU = 147,
                    Description = "Expandable Hydration Pack",
                    Price = 19.97M,
                    ImageURL = "/pack147.jpg"
                };
                db.Products.Add(product);

                product = new Product
                {
                    SKU = 186,
                    Description = "Range Field Pack",
                    Price = 99.97M,
                    ImageURL = "/noimage.jpg"
                };
                db.Products.Add(product);

                product = new Product
                {
                    SKU = 178,
                    Description = "Rugged Range Duffel Bag",
                    Price = 39.97M,
                    ImageURL = "/pack178.jpg"
                };
                db.Products.Add(product);

                product = new Product
                {
                    SKU = 202,
                    Description = "Samll Deployment Back Pack",
                    Price = 29.97M,
                    ImageURL = "/pack202.jpg"
                };
                db.Products.Add(product);
                db.SaveChanges();

                foreach (var p in db.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description, p.Price.ToString("C"), p.ImageURL);
                }
            }
            */

            byte[] thumbBits = new byte[100];
            byte[] fullBits = new byte[2000];
            using (var context = new ModelPhotograph())
            {
                var photo = new Photograph
                {
                    Title = "My dog",
                    ThumbnailBits = thumbBits
                };
                var fullImage = new PhotographFullImage
                {
                    HighResolutionBits = fullBits
                };
                photo.PhotographFullImage = fullImage;
                context.Photographs.Add(photo);
                context.SaveChanges();

                foreach(var image in context.Photographs)
                {
                    Console.WriteLine("Photo: {0}, ThumbnailSize {1} bytes", 
                        image.Title, image.ThumbnailBits.Length);
                    context.Entry(image).Reference(p => p.PhotographFullImage).Load();
                    Console.WriteLine("Full Image Size: {0} bytes",
                        image.PhotographFullImage.HighResolutionBits.Length);
                }
            }
        }
    }
}
