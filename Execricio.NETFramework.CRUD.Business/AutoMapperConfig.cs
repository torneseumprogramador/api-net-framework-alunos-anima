using AutoMapper;
using Execricio.NETFramework.CRUD.Business.Models;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Data.Arguments;

namespace Execricio.NETFramework.CRUD.Business
{
    public class AutoMapper
    {
        public static IMapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoRequest, ProdutoResponse>().ReverseMap();
                cfg.CreateMap<ProdutoArgument, ProdutoModel>().ReverseMap();

                cfg.CreateMap<PrecoRequest, PrecoResponse>().ReverseMap();
                cfg.CreateMap<PrecoArgument, PrecoModel>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}