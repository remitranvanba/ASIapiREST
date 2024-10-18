using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace ASIapiREST.Models.EntityFramework
{
    public partial class SerieDBContext : DbContext
    {
        public SerieDBContext()
        {
        }

        public SerieDBContext(DbContextOptions<SerieDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notation> Notations { get; set; }

        public virtual DbSet<Serie> Series { get; set; }

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263. 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLoggerFactory(MyLoggerFactory)
        //                                                                                               .EnableSensitiveDataLogging()
        //                                                                                               .UseNpgsql("Server=localhost;port=5432;Database=SerieDB;uid= postgres; password=root;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.UtilisateurId, e.SerieId }).HasName("pk_not");

                entity.HasOne(d => d.SerieNotee).WithMany(p => p.NotesSerie)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_ser");

                entity.HasOne(d => d.UtilisateurNotant).WithMany(p => p.NotesUtilisateur)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_utl");
            });


            modelBuilder.Entity<Serie>(entity =>
            {
                entity.HasKey(e => e.SerieId).HasName("pk_ser");

                entity.HasIndex(s => s.Titre);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.UtilisateurId).HasName("pk_utl");

                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.Pays).HasDefaultValue("France");
                entity.Property(u => u.DateCreation).HasDefaultValueSql("now()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
