namespace BmstuLibResources
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

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
       

            modelBuilder.Entity<Resources>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.resource_author)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.html_code)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
                .Property(e => e.resource_type)
                .IsUnicode(false);

            modelBuilder.Entity<Resources>()
            .Property(e => e.resource_form)
            .IsUnicode(false);


            modelBuilder.Entity<Resources>()
            .Property(e => e.amount_resource);

            modelBuilder.Entity<Resources>()
            .Property(e => e.reserve_date);

            modelBuilder.Entity<Resources>()
            .Property(e => e.license_date);

            modelBuilder.Entity<Resources>()
            .Property(e => e.create_date);

            modelBuilder.Entity<Resources>()
            .Property(e => e.resource_form)
            .IsUnicode(false);

            modelBuilder.Entity<Resources>()
            .Property(e => e.is_editing);

            modelBuilder.Entity<Resources>()
                .HasMany(e => e.Stats)
                .WithRequired(e => e.Resources)
                .HasForeignKey(e => e.resource_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resources>()
                .HasMany(e => e.Validations)
                .WithRequired(e => e.Resources)
                .HasForeignKey(e => e.resource_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stats>()
                .Property(e => e.start_period_datetime);

            modelBuilder.Entity<Stats>()
                .Property(e => e.finish_period_datetime);

            modelBuilder.Entity<Stats>()
                .Property(e => e.visitors_count);

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

            modelBuilder.Entity<Validations>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }
}
