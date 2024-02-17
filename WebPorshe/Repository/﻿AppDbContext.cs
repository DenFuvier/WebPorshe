using Microsoft.EntityFrameworkCore;
using System;
using WebPorshe.Model;

namespace WebPorshe.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Porshe> Porshes { get; set; }
    }
}