using LojaSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaSystem.Data
{
    public class LojaContext : DbContext
    {
        // DbSets - Representam as tabelas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // String de conexão para SQL Server LocalDB
            optionsBuilder.UseSqlite("Data Source=lojasystem.db");
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(Console.WriteLine);
            // Habilitar Lazy Loading (opcional)
            // optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ========== CONFIGURAÇÃO DOS RELACIONAMENTOS ==========
            
            // Produto <-> Categoria (Many-to-Many)
            modelBuilder.Entity<ProdutoCategoria>()
                .HasKey(pc => new { pc.ProdutoId, pc.CategoriaId });
            
            modelBuilder.Entity<ProdutoCategoria>()
                .HasOne(pc => pc.Produto)
                .WithMany()
                .HasForeignKey(pc => pc.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ProdutoCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany()
                .HasForeignKey(pc => pc.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Produto>()
                .HasMany(p => p.Categorias)
                .WithMany(c => c.Produtos)
                .UsingEntity<ProdutoCategoria>();

            // Pedido -> Cliente (Many-to-One)
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // ItemPedido -> Pedido (Many-to-One)
            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Pedido)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            // ItemPedido -> Produto (Many-to-One)
            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Produto)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cliente -> Perfil (One-to-One)
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Perfil)
                .WithOne(p => p.Cliente)
                .HasForeignKey<Perfil>(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // ========== SEED DATA (Dados Iniciais) ==========
            
            // Categorias
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Eletrônicos", Descricao = "Produtos eletrônicos em geral" },
                new Categoria { Id = 2, Nome = "Informática", Descricao = "Computadores, notebooks e periféricos" },
                new Categoria { Id = 3, Nome = "Móveis", Descricao = "Móveis para casa e escritório" }
            );

            // Produtos
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Smartphone Samsung Galaxy", Preco = 1299.90m, EstoqueAtual = 25, DataCadastro = new DateTime(2025, 1, 1) },
                new Produto { Id = 2, Nome = "Notebook Dell Inspiron", Preco = 2499.99m, EstoqueAtual = 15, DataCadastro = new DateTime(2025, 1, 1) },
                new Produto { Id = 3, Nome = "Mesa de Escritório", Preco = 599.90m, EstoqueAtual = 10, DataCadastro = new DateTime(2025, 1, 1) },
                new Produto { Id = 4, Nome = "Mouse Gamer Logitech", Preco = 199.90m, EstoqueAtual = 50, DataCadastro = new DateTime(2025, 1, 1) }
            );

            // Relacionamentos Many-to-Many Produto <-> Categoria
            modelBuilder.Entity<ProdutoCategoria>().HasData(
                new ProdutoCategoria { ProdutoId = 1, CategoriaId = 1 }, // Smartphone -> Eletrônicos
                new ProdutoCategoria { ProdutoId = 2, CategoriaId = 2 }, // Notebook -> Informática
                new ProdutoCategoria { ProdutoId = 2, CategoriaId = 1 }, // Notebook -> Eletrônicos (produto pode ter múltiplas categorias)
                new ProdutoCategoria { ProdutoId = 3, CategoriaId = 3 }, // Mesa -> Móveis
                new ProdutoCategoria { ProdutoId = 4, CategoriaId = 2 }, // Mouse -> Informática
                new ProdutoCategoria { ProdutoId = 4, CategoriaId = 1 }  // Mouse -> Eletrônicos
            );

            // Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nome = "João Silva", Email = "joao@email.com", Telefone = "(11) 99999-1234", DataCadastro = new DateTime(2025, 1, 1) },
                new Cliente { Id = 2, Nome = "Maria Santos", Email = "maria@email.com", Telefone = "(11) 88888-5678", DataCadastro = new DateTime(2025, 1, 1) },
                new Cliente { Id = 3, Nome = "Pedro Oliveira", Email = "pedro@email.com", Telefone = "(11) 77777-9012", DataCadastro = new DateTime(2025, 1, 1) }
            );

            // Perfis
            modelBuilder.Entity<Perfil>().HasData(
                new Perfil { Id = 1, ClienteId = 1, Email = "joao.perfil@email.com", DataUltimaVisita = new DateTime(2025, 8, 20) },
                new Perfil { Id = 2, ClienteId = 2, Email = "maria.perfil@email.com", DataUltimaVisita = new DateTime(2025, 8, 22) }
            );
        }
    }
}
