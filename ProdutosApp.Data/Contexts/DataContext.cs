using Microsoft.EntityFrameworkCore;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Contexts
{
    /// <summary>
    /// Classe para conexão do EntityFramework com o banco de dados.
    /// </summary>
    public class DataContext : DbContext
    {
        //Método para conexão com o banco de dados.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //caminho da string de conexão do banco de dados.
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProdutosApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        //Método para adicionar as classes de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        //Propriedade para acessar as operações de CRUD.
        //Deve ser adicionado uma propriedade para cada entidade!
        public DbSet<Produto> Produto { get; set; }
    }
}
