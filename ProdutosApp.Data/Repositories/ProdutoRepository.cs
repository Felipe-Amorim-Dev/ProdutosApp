using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    /// <summary>
    /// Classe para implementação das operações no banco de dados com produto
    /// </summary>
    public class ProdutoRepository
    {
        //Método para adicionar um produto no banco de dados.
        public void Add(Produto produto)
        {
            //Abrindo conexão com o banco de dados
            using (var context = new DataContext())
            {
                //Acessando a propriedade DbSet na DataContext e adicionando produto ao banco de dados.
                context.Produto.Add(produto);
                //salvando as alterações
                context.SaveChanges();
            }
        }

        //Método para atualizar um produto no banco de dados.
        public void Update(Produto produto)
        {
            //Abrindo conexão com o banco de dados
            using (var context = new DataContext())
            {
                //Acessando a propriedade DbSet na DataContext e atualizando produto ao banco de dados.
                context.Produto.Update(produto);
                //salvando as alterações
                context.SaveChanges();
            }
        }

        //Método para remover um produto no banco de dados.
        public void Delete(Produto produto)
        {
            //Abrindo conexão com o banco de dados
            using (var context = new DataContext())
            {
                //Acessando a propriedade DbSet na DataContext e removendo produto ao banco de dados.
                context.Produto.Remove(produto);
                //salvando as alterações
                context.SaveChanges();
            }
        }

        //Método para consultar todos os produto no banco de dados.
        public List<Produto> GetAll()
        {
            //Abrindo conexão com o banco de dados
            using (var context = new DataContext())
            {
                return context.Produto.OrderBy(p => p.Nome).ToList();
            }
        }

        //Método para consultar um produto no banco de dados por ID.
        public Produto? GetById(Guid? id)
        {
            //Abrindo conexão com o banco de dados
            using (var context = new DataContext())
            {
                return context.Produto.Find(id);
            }
        }
    }
}
