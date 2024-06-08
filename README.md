<h1>Aplicação para gerenciamento de produtos</h1>

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

![image](https://img.shields.io/badge/Feito_em-.NET_CORE-ffbc00)
![image](https://img.shields.io/badge/Version-8-ffbc00)

<p>Esta é uma aplicação construída em .NET Core para gerenciamento de produtos. A aplicação permite realizar operações CRUD (Criar, Ler, Atualizar, Deletar) em uma base de dados de produtos utilizando o Entity Framework para interação com o banco de dados.</p>

<h3><a href="https://github.com/Felipe-Amorim-Dev/ProdutosWeb">Link do Front-End</a></h3>

<h2>Estrutura do Projeto</h2>

<p>O projeto está dividido em duas camadas:</p>

<h3>Camada de serviços (Services Layer)</h3>
<p>Nesta camada estão localizadas os controladores (Controllers) e os modelos (Models):</p>


<ul>
<li><h4>ProdutosController</h4>
    Na camada de controle estão os métodos para manipulação das solicitações feitas pelo navegador.
    
    HTTP POST - CadastrarProduto: Método para cadastro do produto.
    HTTP PUT - AtualizarProduto: Método para atualizar o produto.
    HTTP DELETE - RemoverProduto: Método para cadastro do produto.
    HTTP GET - ConsultarProduto: Método para consultar todos os produtos.
    HTTP GET - GetById: Método para consulta do produto por ID.
</li>

<li><h4>Models</h4>
    Na camada de modelo estão os dados da aplicação onde são aplicadas validações para aplicar as regras de negócio.

    ProdutoPostModel - modelo para validação dos dados: Nome, Preço e Quantidade.
    ProdutoPutModel - modelo para validação dos dados: Id, Nome, Preço e Quantidade.
    ProdutoGetModel - modelo para retorno dos dados: Id, Nome, Preço, Quantidade, DataHoraCriacao e DataHoraAlteracao.
</li>
</ul>

<h3>Camada de dados (Data Layer)</h3>
<p>Nesta camada estão localizado as Entidades (Entities), o Repositório (Repositories), o Contexto (Context) e o Mapeamento (Mappings):</p>


<ul>
<li><h4>Produto</h4>
Entidade/Produto

Na Entidade se encontra as propriedade e métodos Get e Set.

Os atributos do Produto são:

    Private Guid? _id;
    private string? _nome;
    private decimal? _preco;
    private int? _quantidade;
    private DateTime? _dataHoraCriacao;
    private DateTIme? _dataHoraAltercao;

Os métodos do Produto são:

    public Guid? Id { get => _id; set => _id = value; }
    public string? Nome { get => _nome; set => _nome = value; }
    public decimal? Preco { get => _preco; set => _preco = value; }
    public int? Quantidade { get => _quantidade; set => _quantidade = value; }
    public DateTime? DataHoraCriacao { get => _dataHoraCriacao; set => _dataHoraCriacao = value; }
    public DateTime? DataHoraAlteracao { get => _dataHoraAlteracao; set => _dataHoraAlteracao = value; }
</li>

<li><h4>ProdutoRepository</h4>
    Na camada de Repositório estão as implementações das operações de CRUD, que atravez do DbSet que se encontra na DataContext pode acessar o banco de dados.

Operações: 

        ADD, UPDATE, DELETE, GetALL e GetById
    
</li>

<li><h4>DataContext</h4>
    Na camada Contexts cria o método para conexão com o banco de dados através da connection String.
    
</li>

<li><h4>ProdutoMap</h4>
    Na camada Mappings cria o mapeamento da classe produto no banco de dados, gerando a tabela Produto no Banco, utilizando a biblioteca do EntityFramework.    
</li>
</ul>


<h2>Como Executar o Projeto</h2>
<p>Para executar o projeto, você deve ter o Visual Studio 2022 devidamente instalado.</p>
<p>O projeto foi desenvolvido em C# .NET CORE versão 8.</p>
<p>
Para a Criação do banco de dados foi utilizada a biblioteca do EntityFramework.
Deve ser instalado na camada de Data (ProdutoApp.Data) as seguintes bibliotecas:
<ul>
<li>
Microsoft.EntityFrameworkCore
</li>
<li>
Microsoft.EntityFrameworkCore.SqlServer
</li>
<li>
Microsoft.EntityFrameworkCore.Tools
</li>
<li>
Microsoft.EntityFrameworkCore.Design
</li>
</ul>
</p>

Após instalada as bibliotecas devemos usar o console do NuGet para colocar os comandos de criação do Migrations.

    Add-Migration Initial //O initial pode ser qualquer nome.
    
    Update-Database 


<h2>Contribuição</h2>

Contribuições são sempre bem-vindas! Se você encontrou algum problema ou tem alguma sugestão para melhorar este projeto, por favor, abra uma issue ou envie um pull request.

<h3>Licença</h3>

<p>Este projeto é livre(FREE).</p>
