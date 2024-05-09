using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.Services.Models
{
    /// <summary>
    /// Modelo de dados para cadastro de produtos.
    /// </summary>
    public class ProdutosPostModel
    {
        [Required(ErrorMessage ="Informe o nome do produto.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int? Quantidade { get; set; }
    }
}
