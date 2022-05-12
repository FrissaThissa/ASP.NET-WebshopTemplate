using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebshopTemplate.Areas.Identity.Data;
using WebshopTemplate.Models;

namespace WebshopTemplate.Data;

public class WebshopTemplateContext : IdentityDbContext<WebshopTemplateUser>
{
    public WebshopTemplateContext(DbContextOptions<WebshopTemplateContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Brand>? Brands { get; set; }
    public DbSet<Cart>? Carts { get; set; }
    public DbSet<Wishlist>? Wishlists { get; set; }
    public DbSet<Cart_Product> Cart_Products { get; set; }
}
