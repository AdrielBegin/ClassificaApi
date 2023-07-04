using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClassificaApi.Model
{
    public class ClassificaContext : DbContext
    {
        public ClassificaContext(DbContextOptions<ClassificaContext> options) : base(options)
        {

        }
        // Mapear 
        public DbSet<Classificados> Classificados { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
