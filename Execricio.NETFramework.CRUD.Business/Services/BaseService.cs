using Execricio.NETFramework.CRUD.Business.Services.Interfaces;
using Execricio.NETFramework.CRUD.Data.Repository;
using Execricio.NETFramework.CRUD.Database.Repository.Interfaces;
using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Business.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public T Recuperar(int id)
        {
            return _repository.Recuperar(id);
        }

        public IEnumerable<T> Recuperar()
        {
            return _repository.Recuperar();
        }

        public bool Salvar(T produto)
        {
            return _repository.Salvar(produto);
        }

        public bool Atualizar(T produto)
        {
            return _repository.Atualizar(produto);
        }

        public bool Deletar(int id)
        {
            return _repository.Deletar(id);
        }
    }
}
