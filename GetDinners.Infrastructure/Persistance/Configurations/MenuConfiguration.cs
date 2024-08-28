using GetDinners.Domain.Hosts.ValueObjects;
using GetDinners.Domain.Menus;
using GetDinners.Domain.Menus.Entities;
using GetDinners.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetDinners.Infrastructure.Persistance.Configurations
{
    internal sealed class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigurationMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);

        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

            builder.Property(x => x.Name)
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(100);

            builder.OwnsOne(x => x.AverageRating);

            builder.Property(x => x.HostId)
                   .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
        }


        private void ConfigurationMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sectionBuilder =>
            {
                sectionBuilder.ToTable("MenuSections");

                sectionBuilder
                .WithOwner()
                .HasForeignKey("MenuId");

                sectionBuilder.HasKey("Id", "MenuId");

                sectionBuilder.Property(x => x.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

                sectionBuilder
                .Property(x => x.Name)
                .HasMaxLength(100);

                sectionBuilder
                .Property(x => x.Description)
                .HasMaxLength(100);


                sectionBuilder.OwnsMany(
                s => s.Items,
                itemBuilder => ConfigureMenuItemsTable(itemBuilder));

                //sectionBuilder.Navigation(s => s.Items) : Cette partie configure la navigation vers la propriété Items de l'entité. s => s.Items est une expression lambda qui fait référence à la propriété Items de l'entité.

                //.Metadata.SetField("_items") : Cette méthode indique à Entity Framework Core d'utiliser le champ privé _items pour stocker la collection associée à Items. Autrement dit, lorsque Entity Framework doit accéder à la collection Items, il utilisera le champ privé _items au lieu de la propriété publique Items.
                sectionBuilder
                .Navigation(s => s.Items).Metadata
                .SetField("_items");


                //Cette méthode configure le mode d'accès pour la propriété Items. En utilisant PropertyAccessMode.Field, vous indiquez à Entity Framework d'accéder directement
                //au champ privé associé (dans ce cas, _items) pour lire ou écrire des données, plutôt que d'utiliser la propriété publique Items.
                sectionBuilder
                  .Navigation(s => s.Items)
                  .UsePropertyAccessMode(PropertyAccessMode.Field);
            });
            //cette méthode permet l'accés au metadata de Menu (sections) 
            //SetPropertyAccessMode utilisé pour permettre d'accéder directement au champ privé 
            builder.Metadata
                .FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuItemsTable(OwnedNavigationBuilder<MenuSection, MenuItem> itemBuilder)
        {
            itemBuilder.ToTable("MenuItems");

            // MenuItem à deux owners  MenuSection et Menu
            //MenuItem à deux clés etrangéres 
            itemBuilder
                .WithOwner()
                .HasForeignKey("MenuSectionId", "MenuId");

            //le Id de MenuItem est composé de MenuSectionId +  MenuId
            itemBuilder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

            itemBuilder
                .Property(x => x.Id)
                .HasColumnName("MenuItemId")
                .ValueGeneratedOnAdd()
                .HasConversion(
                id => id.Value,
                value => MenuItemId.Create(value));

            itemBuilder
                .Property(x => x.Name)
                .HasMaxLength(100);

            itemBuilder
                .Property(x => x.Description)
                .HasMaxLength(100);

        }
        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dinnerBuilder =>
            {
                dinnerBuilder.ToTable("MenuDinnerIds");

                dinnerBuilder
                .WithOwner()
                .HasForeignKey("MenuId");

                dinnerBuilder.HasKey("Id");

                dinnerBuilder
                .Property(x => x.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
            });

            builder.Metadata
                    .FindNavigation(nameof(Menu.DinnerIds))!
                    .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, reviewIds =>
            {
                reviewIds.ToTable("MenuReviewIds");

                reviewIds
                .WithOwner()
                .HasForeignKey("MenuId");

                reviewIds
                .Property(x => x.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();


            });
            builder.Metadata
                .FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

        }

    }
}

