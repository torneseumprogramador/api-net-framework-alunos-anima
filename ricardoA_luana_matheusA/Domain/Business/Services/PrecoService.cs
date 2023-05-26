using Repository.Interfaces;
using Repository.Repository;
using Service.DTO;
using Service.Services.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class PrecoService : IPrecoService
    {
        private readonly IPrecoRepository _PrecoRepository;

        public PrecoService()
        {
            _PrecoRepository = new PrecoRepository();
        }

        public List<PrecoDTO> BuscarPrecos()
        {
            var Precos = _PrecoRepository.BuscarPrecos();
            return Precos;
        }

        public PrecoDTO BuscarPreco(int id)
        {
            var Preco = _PrecoRepository.BuscarPreco(id);
            return Preco;
        }

        public bool InserirPreco(PrecoDTO Preco)
        {
            bool insercaoSucesso = _PrecoRepository.InserirPreco(Preco);
            return insercaoSucesso;
        }

        public bool AtualizarPreco(int id, PrecoDTO Preco)
        {
            bool atualizacaoSucesso = _PrecoRepository.AtualizarPreco(id, Preco);
            return atualizacaoSucesso;
        }

        public bool DeletarPreco(int id)
        {
            bool exclusaoSucesso = _PrecoRepository.DeletarPreco(id);
            return exclusaoSucesso;
        }
    }
}
