using FluentValidation;
using Game.Domain.DTO.Base;

namespace GameAPI.Validations.Base
{
    /// <summary>
    /// Base validator class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValidatorBase<T> : AbstractValidator<T> where T : IRequest
    {
    }
}
