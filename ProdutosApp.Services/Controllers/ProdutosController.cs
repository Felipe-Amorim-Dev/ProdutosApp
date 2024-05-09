using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Post([FromBody] ProdutosPostModel model)
        {
            try
            {
                //Criando um objeto da classe produto.
                var produto = new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Quantidade = model.Quantidade,
                    DataHoraCriacao = DateTime.Now,
                    DataHoraAlteracao = DateTime.Now
                };

                //Gravando no banco de dados.
                var produtoRepository = new ProdutoRepository();
                produtoRepository.Add(produto);

                //Copiando os dados do produto para a classe ProdutoGetModel.
                var result = EntityToModel(produto);

                //Retornando statusCode 200 (OK).
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put([FromBody] ProdutosPutModel model)
        {
            try
            {
                //Consultando o produto no banco de dados através do ID.
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(model.Id);

                if (produto != null)
                {
                    //atualizar os dados do produto.
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;
                    produto.Quantidade = model.Quantidade;
                    produto.DataHoraAlteracao = DateTime.Now;

                    produtoRepository.Update(produto);

                    //Copiando os dados do produto para a classe ProdutosGetModel.
                    var result = EntityToModel(produto);

                    //Retornando o código 200 (OK).
                    return StatusCode(200, result);
                }
                else
                {
                    //Retornando o código de erro 400 (Bad Request).
                    return StatusCode(400, new { mensagem = "Produto não encontrado." });
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                //Buscando no banco de dados através do ID.
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(id);

                //Verificando se o produto foi encontrado.
                if(produto != null)
                {
                    //Excluindo o produto no banco de dados.
                    produtoRepository.Delete(produto);

                    //Copiando os dados do produto para a classe ProdutosGetModel
                    var result = EntityToModel(produto);

                    //Retornando o código 200 (OK).
                    return StatusCode(200, result);
                }
                else
                {
                    //Retornando o código de erro 400 (Bad Request).
                    return StatusCode(400, new { mensagem = "Produto não encontrado." });
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                //Criando uma lista de objetos para retornar a consulta
                var lista = new List<ProdutosGetModel>();

                //Acessando o banco de dados e consultando todos os produtos cadastrados
                var produtosRepository = new ProdutoRepository();
                foreach(var item in produtosRepository.GetAll())
                {
                    //Adicionando cada produto obtido na lista
                    lista.Add(EntityToModel(item));
                }

                if(lista.Count > 0)
                {
                    //Retornando a lista com todos os produtos.
                    return StatusCode(200, lista);
                }
                else
                {
                    //Retornando o código 204 (No Content).
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                //Consultando o produto no banco de dados
                var produtosRepository = new ProdutoRepository();
                var produto = produtosRepository.GetById(id);

                if(produto != null)
                {
                    //Copiando os dados do produto para a classe ProdutosGetModel.
                    var result = EntityToModel(produto);

                    //Retornando o código 200 (OK).
                    return StatusCode(200, result);
                }
                else
                {
                    //Retornando o código 204 (No Content).
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                //Retornando código de erro 500 (Internal server error).
                return StatusCode(500, new { e.Message });
            }
            
        }

        /// <summary>
        /// Método auxiliar para copiar os dados de um objeto da classe Produto
        /// para um objeto da classe ProdutosGetModel
        /// </summary>
        private ProdutosGetModel EntityToModel(Produto produto)
        {
            return new ProdutosGetModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Total = produto.Preco * produto.Quantidade,
                DataHoraCriacao = produto.DataHoraCriacao,
                DataHoraAlteracao = produto.DataHoraAlteracao
            };
        }
    }
}
