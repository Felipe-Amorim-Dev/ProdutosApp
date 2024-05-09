using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Entities
{

    /// <summary>
    /// Modelo de dados para a entidade produtos.
    /// </summary>
    public class Produto
    {
        #region Atributos
        private Guid? _id;
        private string? _nome;
        private decimal? _preco;
        private int? _quantidade;
        private DateTime? _dataHoraCriacao;
        private DateTime? _dataHoraAlteracao;
        #endregion

        #region Métodos
        public Guid? Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public decimal? Preco { get => _preco; set => _preco = value; }
        public int? Quantidade { get => _quantidade; set => _quantidade = value; }
        public DateTime? DataHoraCriacao { get => _dataHoraCriacao; set => _dataHoraCriacao = value; }
        public DateTime? DataHoraAlteracao { get => _dataHoraAlteracao; set => _dataHoraAlteracao = value; }
        #endregion

    }
}
