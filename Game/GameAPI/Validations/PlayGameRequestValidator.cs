using FluentValidation;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Infrastructure.Utilities.Enums.Rpsls;

namespace GameAPI.Validations
{
    //public class PlayGameRequestValidator : ValidatorBase<PlayGameRequest>
    public class PlayGameRequestValidator : AbstractValidator<PlayGameRequest> 
    {
        public PlayGameRequestValidator()
        {
            RuleFor(r => r.Player)
                .Must(r => Enum.IsDefined(typeof(Choice), r));
        }
    }
}
