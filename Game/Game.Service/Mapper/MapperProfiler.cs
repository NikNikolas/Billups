using AutoMapper;
using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Model;
using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Domain.DTO.GameRpsls.Responses;
using Game.Infrastructure.Utilities.Helpers;

namespace Game.Service.Mapper
{
    /// <summary>
    /// Mapper class for mapping object
    /// </summary>
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<Choice, GetChoiceResponse>();
            CreateMap<GameCalculationRequest, GameResultHistory>();
            CreateMap<GetAllHistoryRequest, GetAllHistoryModel>();
            CreateMap<GameResultHistory, GetGameResultHistoryResponse>()
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => EnumHelper.GetNameOfGameResult(src.Result)));
        }
    }
}
