using EvidenceSkladu.Models;
using Microsoft.EntityFrameworkCore;

namespace EvidenceSkladu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Produkt> Produkty { get; set; }
    }
}