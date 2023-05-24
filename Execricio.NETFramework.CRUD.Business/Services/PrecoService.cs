using Execricio.NETFramework.CRUD.Business.Models;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Data.Repository;
using Execricio.NETFramework.CRUD.Database.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Execricio.NETFramework.CRUD.Business.Services
{
    public sealed class PrecoService : BaseService<PrecoModel>
    {
        private static PrecoService _instance;

        private PrecoService(IBaseRepository<PrecoModel> repository) : base(repository)
        {
        }

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
    
        public PrecoResponse RecuperarPreco(int id)
        {
            PrecoModel model = Recuperar(id);
            PrecoResponse response = new PrecoResponse() 
            {
                Id = model.Id,
                Preco = model.Preco,
                ProdutoId = model.ProdutoId,
                Data = model.Data
            };
            return response;
        }

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

        public bool DeletarPreco(int id, PrecoRequest request)
        {
            PrecoModel model = Recuperar(id);

            if (model is null || model.Id != id)
                return false;

            return Deletar(id);
        }
    }
}
