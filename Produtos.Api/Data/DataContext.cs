using Microsoft.EntityFrameworkCore;
using Produtos.Api.Models;

namespace Produtos.Api.Data
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString = @"Server=localhost;Database=DB_BERNHOEFT;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Persist Security Info=False;Trusted_Connection=True";

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
               .Entity<Produto>()
               .ToTable("TBLPRODUTO");

            modelBuilder
               .Entity<Categoria>()
               .ToTable("TBLCATEGORIA");

            #region Produto Map
            modelBuilder
                .Entity<Produto>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Produto>()
                .Property(x => x.Id)
                .HasColumnName("IDPRODUTO")
                .IsRequired();

            modelBuilder
                .Entity<Produto>()
                .Property(x => x.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            modelBuilder
                .Entity<Produto>()
                .Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();

            modelBuilder
                .Entity<Produto>()
                .Property(x => x.Preco)
                .HasColumnName("PRECO")
                .IsRequired();

            modelBuilder
                .Entity<Produto>()
                .Property(x => x.Situacao)
                .HasColumnName("SITUACAO")
                .IsRequired();

            modelBuilder
                .Entity<Produto>()
                .Property(x => x.IdCategoria)
                .HasColumnName("IDCATEGORIA")
                .IsRequired();

            modelBuilder
                .Entity<Produto>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdCategoria);
            #endregion

            #region Categoria Map
            modelBuilder
                .Entity<Categoria>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Categoria>()
                .Property(x => x.Id)
                .HasColumnName("IDCATEGORIA")
                .IsRequired();

            modelBuilder
                .Entity<Categoria>()
                .Property(x => x.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            modelBuilder
                .Entity<Categoria>()
                .Property(x => x.Situacao)
                .HasColumnName("SITUACAO")
                .IsRequired();

            modelBuilder
                .Entity<Categoria>()
                .HasMany(x => x.Produtos)
                .WithOne(x => x.Categoria);
            #endregion
        }
    }
}
