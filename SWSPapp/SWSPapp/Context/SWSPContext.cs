namespace SWSPapp.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SWSPContext : DbContext
    {
        public SWSPContext()
            : base("name=SWSPContext")
        {
            Database.SetInitializer<SWSPContext>(null);
        }

        public virtual DbSet<dic_city> dic_city { get; set; }
        public virtual DbSet<dic_club> dic_club { get; set; }
        public virtual DbSet<dic_country> dic_country { get; set; }
        public virtual DbSet<dic_currency> dic_currency { get; set; }
        public virtual DbSet<dic_position> dic_position { get; set; }
        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<players_history> players_history { get; set; }
        public virtual DbSet<players_statistics> players_statistics { get; set; }
        public virtual DbSet<player_statistic_changes> player_statistic_changes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dic_city>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<dic_city>()
                .HasMany(e => e.players)
                .WithRequired(e => e.dic_city)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dic_club>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<dic_club>()
                .HasMany(e => e.players_history)
                .WithRequired(e => e.dic_club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dic_country>()
                .Property(e => e.symbol)
                .IsFixedLength();

            modelBuilder.Entity<dic_country>()
                .Property(e => e.name_pol)
                .IsFixedLength();

            modelBuilder.Entity<dic_country>()
                .Property(e => e.name_eng)
                .IsFixedLength();

            modelBuilder.Entity<dic_country>()
                .HasMany(e => e.players)
                .WithRequired(e => e.dic_country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dic_currency>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<dic_currency>()
                .HasMany(e => e.players_history)
                .WithRequired(e => e.dic_currency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dic_position>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<dic_position>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<dic_position>()
                .HasMany(e => e.players)
                .WithRequired(e => e.dic_position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<player>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<player>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<player>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<player>()
                .HasMany(e => e.players_history)
                .WithRequired(e => e.player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<player>()
                .HasMany(e => e.players_statistics)
                .WithRequired(e => e.player)
                .WillCascadeOnDelete(false);
        }
    }
}
