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
    /// Classe que representa o serviço de manipulação de dados relacionados a preços.
    /// </summary>
    public sealed class PrecoService : BaseService<PrecoModel>
    {
        private static PrecoService _instance;

        /// <summary>
        /// Construtor privado para impedir a criação de instâncias externas da classe.
        /// Utiliza a instância do repositório fornecido como parâmetro na construção da classe base.
        /// </summary>
        /// <param name="repository">Instância do repositório a ser utilizada.</param>
        private PrecoService(IBaseRepository<PrecoModel> repository) : base(repository)
        {
        }

        /// <summary>
        /// Instância estática do serviço de preços.
        /// </summary>
        public static PrecoService Instance
        {
            get
            {
                if (_instance == null)
                {
                    IBaseRepository<PrecoModel> repository = new BaseRepository<PrecoModel>();
                    _instance = new PrecoService(repository);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Recupera um preço com base no seu ID e o retorna como um objeto PrecoResponse.
        /// </summary>
        /// <param name="id">ID do preço a ser recuperado.</param>
        /// <returns>O preço recuperado como um objeto PrecoResponse.</returns>
        public PrecoResponse RecuperarPreco(int id)
        {
            PrecoModel model = Recuperar(id);
            PrecoResponse response = new PrecoResponse()
            {
                Preco = model.Preco,
                ProdutoId = model.ProdutoId,
                Data = model.Data
            };
            return response;
        }

        /// <summary>
        /// Recupera todos os preços e os retorna como uma coleção de objetos PrecoResponse.
        /// </summary>
        /// <returns>Uma coleção de objetos PrecoResponse representando os preços recuperados.</returns>
        public IEnumerable<PrecoResponse> RecuperarPrecos()
        {
            IEnumerable<PrecoModel> model = Recuperar();
            IEnumerable<PrecoResponse> responses = model.Select(m =>
            {
                return new PrecoResponse()
                {
                    Preco = m.Preco,
                    ProdutoId = m.ProdutoId,
                    Data = m.Data
                };
            });

            return responses;
        }

        /// <summary>
        /// Salva um novo preço com base nos dados fornecidos.
        /// </summary>
        /// <param name="request">Dados do preço a serem salvos.</param>
        /// <returns>Um valor booleano indicando se o salvamento foi bem-sucedido.</returns>
        public bool SalvarPreco(PrecoRequest request)
        {
            PrecoModel model = new PrecoModel()
            {
                Preco = request.Preco,
                ProdutoId = request.ProdutoId,
                Data = request.Data
            };

            return Salvar(model);
        }

        /// <summary>
        /// Atualiza um preço existente com base no seu ID e nos dados fornecidos.
        /// </summary>
        /// <param name="id">ID do preço a ser atualizado.</param>
        /// <param name="request">Dados do preço atualizado.</param>
        /// <returns>Um valor booleano indicando se a atualização foi bem-sucedida.</returns>
        public bool AtualizarPreco(int id, PrecoRequest request)
        {
            PrecoModel model = Recuperar(id);

            if (model is null || model.Id != id)
                return false;

            PrecoModel modelAtualizado = new PrecoModel()
            {
                Preco = request.Preco,
                ProdutoId = request.ProdutoId,
                Data = request.Data
            };

            return Atualizar(modelAtualizado);
        }

        /// <summary>
        /// Deleta um preço existente com base no seu ID.
        /// </summary>
        /// <param name="id">ID do preço a ser deletado.</param>
        /// <param name="request">Dados do preço a serem deletados.</param>
        /// <returns>Um valor booleano indicando se a deleção foi bem-sucedida.</returns>
        public bool DeletarPreco(int id, PrecoRequest request)
        {
            PrecoModel model = Recuperar(id);

            if (model is null || model.Id != id)
                return false;

            return Deletar(id);
        }
    }
}
