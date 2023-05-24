using Execricio.NETFramework.CRUD.Business.Models;
using Execricio.NETFramework.CRUD.Data.Repository;
using Execricio.NETFramework.CRUD.Database.Repository.Interfaces;

namespace Execricio.NETFramework.CRUD.Business.Services
{
    public sealed class ProdutoService : BaseService<ProdutoModel>
    {
        private static ProdutoService _instance;

        private ProdutoService(IBaseRepository<ProdutoModel> repository) : base(repository)
        {
        }

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
    }
}
