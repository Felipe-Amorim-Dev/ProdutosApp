namespace ProdutosApp.Services.Models
{
    /// <summary>
    /// Modelo de dados para consulta de produtos.
    /// </summary>
    public class ProdutosGetModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
    }
}
