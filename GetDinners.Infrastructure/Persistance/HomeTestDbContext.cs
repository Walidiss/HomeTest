using GetDinners.Domain.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Infrastructure.Persistance
{
    public sealed class HomeTestDbContext : DbContext
    {
        public HomeTestDbContext(DbContextOptions<HomeTestDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> menus { get; set; } = null!;

        //Cette méthode est utilisée pour configurer les entités et leurs relations au moment de la création du modèle (avant que la base de données ne soit créée).
        //Vous pouvez définir des configurations spécifiques ou appliquer des configurations provenant d'autres classes.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cette ligne applique automatiquement toutes les configurations d'entités trouvées dans l'assembly où HomeTestDbContext est défini.
            // Cela permet de centraliser les configurations de modèle dans des classes séparées pour chaque entité, en implémentant l'interface IEntityTypeConfiguration<T>.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HomeTestDbContext).Assembly);

            // Appelle la méthode de la classe de base pour s'assurer que tout comportement par défaut d'Entity Framework Core est maintenu.
            base.OnModelCreating(modelBuilder);
        }

        // Cette méthode est utilisée pour configurer le contexte en cas d'absence de configuration via DbContextOptions (comme dans le constructeur).
        // Elle est utile lorsque vous devez spécifier des options directement dans le contexte, comme une chaîne de connexion par défaut ou des comportements spécifiques.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
