using CrossCutting.Entities;
using CrossCutting.Enum;
using FluentValidation;
using System;

namespace Application.Models
{
    public class PropertyImageDto : BaseEntity
    {
        public Guid IdProperty { get; set; }
        public byte[] File { get; set; }
        public bool Enabled { get; set; }

        public virtual PropertyDto Property { get; set; }
    }

    public class PropertyImageValidator : AbstractValidator<PropertyImageDto>
    {
        public PropertyImageValidator()
        {
            RuleFor(x => x.IdProperty)
                .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message);
            RuleFor(x => x.File)
                .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message);
            RuleFor(x => x.Enabled)
                .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message);
        }
    }
}
