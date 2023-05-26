using AutoMapper;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;
using Execricio.NETFramework.CRUD.Data.Arguments;
using Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite;
using Execricio.NETFramework.CRUD.Data.Repository.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private static ProdutoService _instance;
        private static IMapper _mapper;

        private ProdutoService(IProdutoRepository produtoRepository, IMapper mapperConfig)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapperConfig;
        }

        public static ProdutoService Instance
        {
            get
            {
                if (_instance is null)
                {
                    IProdutoRepository produtoRepository = ProdutoRepository.Instance;
                    var mapperConfig = AutoMapper.InitializeAutomapper();
                    _instance = new ProdutoService(produtoRepository, mapperConfig);
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

        public ProdutoResponse RecuperarProduto(int id)
        {
            ProdutoArgument produto = _produtoRepository.RecuperarProduto(id);
            return _mapper.Map<ProdutoResponse>(produto);
        }

        public IEnumerable<ProdutoResponse> RecuperarProdutos()
        {
            IEnumerable<ProdutoArgument> produtos = _produtoRepository.RecuperarProdutos();
            return _mapper.Map<IEnumerable<ProdutoResponse>>(produtos);
        }

        public bool SalvarProduto(ProdutoRequest produto)
        {
            ProdutoArgument novoProduto = _mapper.Map<ProdutoArgument>(produto);
            return _produtoRepository.SalvarProduto(novoProduto);
        }
    }
}
