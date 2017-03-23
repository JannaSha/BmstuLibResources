using System.Data.Entity;

namespace BmstuLibResources
{
    public partial class ResourcesLibModel : DbContext
    {
        public ResourcesLibModel()
            : base("name=ConnectionString")
        {
        }

        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Stats> Stats { get; set; }
        public virtual DbSet<Udc> Udc { get; set; }
        public virtual DbSet<Validations> Validations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Ресурсы
            modelBuilder.Entity<Resources>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.html_code)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.type_res)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
            .Property(e => e.form)
            .IsUnicode(false);

            modelBuilder.Entity<Resources>()
            .Property(e => e.amount);

            modelBuilder.Entity<Resources>()
            .Property(e => e.form)
            .IsUnicode(false);

            modelBuilder.Entity<Resources>()
            .Property(e => e.is_editing);

            modelBuilder.Entity<Resources>()
            .Property(e => e.is_license);

            modelBuilder.Entity<Resources>()
                .HasMany(e => e.Stats)
                .WithRequired(e => e.Resources)
                .HasForeignKey(e => e.id_resource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resources>()
                .HasMany(e => e.Validations)
                .WithRequired(e => e.Resources)
                .HasForeignKey(e => e.id_resource)
                .WillCascadeOnDelete(false);

            //Статистика
            modelBuilder.Entity<Stats>()
                .Property(e => e.start_period);

            modelBuilder.Entity<Stats>()
                .Property(e => e.finish_period);

            modelBuilder.Entity<Stats>()
                .Property(e => e.visitors_count);

            //Время
            modelBuilder.Entity<Resources>()
                .Property(e => e.create_date);

            modelBuilder.Entity<Resources>()
                .Property(e => e.reserve_date);

            modelBuilder.Entity<Resources>()
                .Property(e => e.license);
            //УДК
            modelBuilder.Entity<Udc>()
                .Property(e => e.udc_index)
                .IsUnicode(false);

            modelBuilder.Entity<Udc>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Udc>()
                .HasMany(e => e.Resources)
                .WithRequired(e => e.Udc)
                .HasForeignKey(e => e.udc_id)
                .WillCascadeOnDelete(false);

            //Валидация
            modelBuilder.Entity<Validations>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Validations>()
                .Property(e => e.check_date);

            modelBuilder.Entity<Validations>()
            .Property(e => e.is_valid);
        }
    }
}