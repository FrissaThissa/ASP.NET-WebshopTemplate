using WebshopTemplate.Models;
using WebshopTemplate.ViewModels.Products;
using WebshopTemplate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace WebshopTemplate.Services
{
    public class ProductService : IProductService
    {
        private readonly WebshopTemplateContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(WebshopTemplateContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public void CreateProduct(Product product)
        {
            HandleProductImages(product);
            _context.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Images)
                .Include(p => p.Brand)
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(int categoryid)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryid)
                .Include(p => p.Images)
                .ToList();
        }

        public List<Product> GetProductsByFilter(ProductFilter filter)
        {
            return _context.Products
                .Include(p => p.Brand)
                .ToList();
        }

        public void UpdateProduct(Product product)
        {

        }

        public async void HandleProductImages(Product product)
        {
            //create a Photo list to store the upload files.
            if (product.Files.Count > 0)
            {
                foreach (var formFile in product.Files)
                {
                    if (formFile.Length > 0)
                    {
                        string filename = Path.GetFileName(formFile.FileName);
                        string fileId = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(formFile.FileName);
                        string localpath = "images/" + fileId;
                        string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileId);
                        using (var stream = System.IO.File.Create(path))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        if (product.Images == null)
                            product.Images = new List<Image>();

                        Image image = new Image { Path = localpath, OriginalFileName = filename };

                        product.Images.Add(image);
                        /*
                        using (var memoryStream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(memoryStream);
                            // Upload the file if less than 2 MB
                            if (memoryStream.Length < 2097152)
                            {
                                //based on the upload file to create Photo instance.
                                //You can also check the database, whether the image exists in the database.
                                var bytes = memoryStream.ToArray();
                                var image = new Image()
                                {
                                    Bytes = bytes,
                                    Description = formFile.FileName,
                                    FileExtension = Path.GetExtension(formFile.FileName),
                                    Size = formFile.Length,
                                    Base64 = Convert.ToBase64String(bytes)
                                };
                                //add the photo instance to the list.
                                images.Add(image);
                            }
                        }
                        */
                    }
                }
            }
            //assign the photos to the Product, using the navigation property.
            //product.Images = images;
        }
    }
}
