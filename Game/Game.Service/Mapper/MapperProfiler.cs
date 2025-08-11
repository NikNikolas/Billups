using AutoMapper;
using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Domain.DTO.GameRpsls.Responses;

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
        }
    }
}
