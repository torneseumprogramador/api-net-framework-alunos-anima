using Execricio.NETFramework.CRUD.Business.Models;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Data.Repository;
using Execricio.NETFramework.CRUD.Database.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Execricio.NETFramework.CRUD.Business.Services
{
    /// <summary>
    /// Classe que representa o serviço de manipulação de dados relacionados a produtos.
    /// </summary>
    public sealed class ProdutoService : BaseService<ProdutoModel>
    {
        private static ProdutoService _instance;

        /// <summary>
        /// Construtor privado para impedir a criação de instâncias externas da classe.
        /// Utiliza a instância do repositório fornecido como parâmetro na construção da classe base.
        /// </summary>
        /// <param name="repository">Instância do repositório a ser utilizada.</param>
        private ProdutoService(IBaseRepository<ProdutoModel> repository) : base(repository)
        {
        }

        /// <summary>
        /// Instância estática do serviço de produtos.
        /// </summary>
        public static ProdutoService Instance
        {
            get
            {
                if (_instance == null)
                {
                    IBaseRepository<ProdutoModel> repository = new BaseRepository<ProdutoModel>();
                    _instance = new ProdutoService(repository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Recupera um produto com base no seu ID e o retorna como um objeto ProdutoResponse.
        /// </summary>
        /// <param name="id">ID do produto a ser recuperado.</param>
        /// <returns>O produto recuperado como um objeto ProdutoResponse.</returns>
        public ProdutoResponse RecuperarProduto(int id)
        {
            ProdutoModel model = Recuperar(id);
            ProdutoResponse response = new ProdutoResponse()
            {
                Nome = model.Nome,
                Descricao = model.Descricao
            };
            return response;
        }

        /// <summary>
        /// Recupera todos os produtos e os retorna como uma coleção de objetos ProdutoResponse.
        /// </summary>
        /// <returns>Uma coleção de objetos ProdutoResponse representando os produtos recuperados.</returns>
        public IEnumerable<ProdutoResponse> RecuperarProdutos()
        {
            IEnumerable<ProdutoModel> model = Recuperar();
            IEnumerable<ProdutoResponse> responses = model.Select(m =>
            {
                return new ProdutoResponse()
                {
                    Nome = m.Nome,
                    Descricao = m.Descricao
                };
            });

            return responses;
        }

        /// <summary>
        /// Salva um novo produto com base nos dados fornecidos.
        /// </summary>
        /// <param name="request">Dados do produto a serem salvos.</param>
        /// <returns>Um valor booleano indicando se o salvamento foi bem-sucedido.</returns>
        public bool SalvarProduto(ProdutoRequest request)
        {
            ProdutoModel model = new ProdutoModel()
            {
                Nome = request.Nome,
                Descricao = request.Descricao
            };

            return Salvar(model);
        }

        /// <summary>
        /// Atualiza um produto existente com base no seu ID e nos dados fornecidos.
        /// </summary>
        /// <param name="id">ID do produto a ser atualizado.</param>
        /// <param name="request">Dados do produto atualizado.</param>
        /// <returns>Um valor booleano indicando se a atualização foi bem-sucedida.</returns>
        public bool AtualizarProduto(int id, ProdutoRequest request)
        {
            ProdutoModel model = Recuperar(id);

            if (model is null || model.Id != id)
                return false;

            ProdutoModel modelAtualizado = new ProdutoModel()
            {
                Nome = request.Nome,
                Descricao = request.Descricao
            };

            return Atualizar(modelAtualizado);
        }

        /// <summary>
        /// Deleta um produto existente com base no seu ID.
        /// </summary>
        /// <param name="id">ID do produto a ser deletado.</param>
        /// <param name="request">Dados do produto a serem deletados.</param>
        /// <returns>Um valor booleano indicando se a deleção foi bem-sucedida.</returns>
        public bool DeletarProduto(int id, ProdutoRequest request)
        {
            ProdutoModel model = Recuperar(id);

            if (model is null || model.Id != id)
                return false;

            return Deletar(id);
        }
    }

}
