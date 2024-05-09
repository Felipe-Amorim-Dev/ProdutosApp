using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.Services.Models
{
    /// <summary>
    /// Modelos de dados para edição de produtos.
    /// </summary>
    public class ProdutosPutModel
    {
        [Required(ErrorMessage ="Informe o Id do produto desejado")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int? Quantidade { get; set; }
    }
}
