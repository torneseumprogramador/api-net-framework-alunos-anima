using AutoMapper;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;
using Execricio.NETFramework.CRUD.Data.Arguments;
using Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite;
using Execricio.NETFramework.CRUD.Data.Repository.Sqlite;
using System.Collections.Generic;
using System.Linq;


namespace Execricio.NETFramework.CRUD.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private IPrecoService _precoService;
        private static ProdutoService _instance;
        private static IMapper _mapper;

        private ProdutoService(IProdutoRepository produtoRepository, IPrecoService precoService, IMapper mapperConfig)
        {
            _produtoRepository = produtoRepository;
            _precoService = precoService;
            _mapper = mapperConfig;
        }

        public static ProdutoService Instance
        {
            get
            {
                if (_instance is null)
                {
                    IProdutoRepository produtoRepository = ProdutoRepository.Instance;
                    IPrecoService precoService = PrecoService.Instance;
                    IMapper mapperConfig = AutoMapper.InitializeAutomapper();
                    _instance = new ProdutoService(produtoRepository, precoService, mapperConfig);
                }
                return _instance;
            }
        }

        public bool AtualizarProduto(int id, ProdutoRequest produto)
        {
            if(id != produto.Id || produto is null)
                return false;

            ProdutoArgument produtoAtualizado = _mapper.Map<ProdutoArgument>(produto);

            return _produtoRepository.AtualizarProduto(produtoAtualizado);
        }

        public bool DeletarProduto(int id)
        {
            IEnumerable<ProdutoArgument> produtos = _produtoRepository.RecuperarProdutos();

            if (!produtos.Any(produto => produto.Id == id))
                return false;

            return _produtoRepository.DeletarProduto(id);
        }

        public ProdutoResponse RecuperarProduto(int id, bool infoPreco = false)
        {
            ProdutoArgument produto = _produtoRepository.RecuperarProduto(id);
            ProdutoResponse response = _mapper.Map<ProdutoResponse>(produto);

            if (infoPreco)
                response.Preco = _precoService.RecuperarPrecos().Where(preco => preco.ProdutoId == response.Id && preco.Ativo).First().Preco;

            return response;
        }

        public IEnumerable<ProdutoResponse> RecuperarProdutos(bool infoPreco = false)
        {
            IEnumerable<ProdutoArgument> produtos = _produtoRepository.RecuperarProdutos();
            IEnumerable<ProdutoResponse> responses = _mapper.Map<IEnumerable<ProdutoResponse>>(produtos);

            if (infoPreco)
            {
                responses = responses.Select(response =>
                {
                    response.Preco = _precoService.RecuperarPrecos().Where(preco => preco.ProdutoId == response.Id && preco.Ativo).First().Preco;
                    return response;
                });
            }

            return responses;
        }

        public bool SalvarProduto(ProdutoRequest produto)
        {
            ProdutoArgument novoProduto = _mapper.Map<ProdutoArgument>(produto);
            return _produtoRepository.SalvarProduto(novoProduto);
        }
    }
}
