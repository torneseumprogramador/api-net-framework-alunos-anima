using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;
using Execricio.NETFramework.CRUD.Data.Arguments;
using Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite;
using Execricio.NETFramework.CRUD.Data.Repository.Sqlite;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Execricio.NETFramework.CRUD.Business.Services
{
    public class PrecoService : IPrecoService
    {
        private IPrecoRepository _precoRepository;
        private static PrecoService _instance;
        private static IMapper _mapper;

        private PrecoService(IPrecoRepository precoRepository, IMapper mapperConfig)
        {
            _precoRepository = precoRepository;
            _mapper = mapperConfig;
        }

        public static PrecoService Instance
        {
            get
            {
                if (_instance is null)
                {
                    IPrecoRepository precoRepository = PrecoRepository.Instance;
                    IMapper mapperConfig = AutoMapper.InitializeAutomapper();
                    _instance = new PrecoService(precoRepository, mapperConfig);
                }
                return _instance;
            }
        }

        public bool AtualizarPreco(int id, PrecoRequest preco)
        {
            if (id != preco.Id || preco is null)
                return false;

            PrecoArgument precoAtualizado = _mapper.Map<PrecoArgument>(preco);
            precoAtualizado.Ativo = false;
            _precoRepository.AtualizarPreco(precoAtualizado);

            PrecoArgument precoNovo = _mapper.Map<PrecoArgument>(preco);
            preco.Ativo = true;

            return _precoRepository.SalvarPreco(precoNovo);
        }

        public bool DeletarPreco(int id)
        {
            IEnumerable<PrecoArgument> precos = _precoRepository.RecuperarPrecos();

            if(!precos.Any(preco => preco.Id == id))
                return false;

            return _precoRepository.DeletarPreco(id);
        }

        public PrecoResponse RecuperarPreco(int id)
        {
            PrecoArgument preco = _precoRepository.RecuperarPreco(id);
            return _mapper.Map<PrecoResponse>(preco);
        }

        public IEnumerable<PrecoResponse> RecuperarPrecos()
        {
            IEnumerable<PrecoArgument> precos = _precoRepository.RecuperarPrecos();
            return _mapper.Map<IEnumerable<PrecoResponse>>(precos);
        }

        public bool SalvarPreco(PrecoRequest preco)
        {
            PrecoArgument precoNovo = _mapper.Map<PrecoArgument>(preco);
            return _precoRepository.SalvarPreco(precoNovo);
        }
    }
}
