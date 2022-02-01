using CrossCutting.Entities;
using CrossCutting.Enum;
using FluentValidation;
using System;

namespace Application.Models
{
    public class PropertyTraceDto : BaseEntity
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public Guid IdProperty { get; set; }

        public virtual PropertyDto Property { get; set; }
    }

    public class PropertyTraceValidator : AbstractValidator<PropertyTraceDto>
    {
        public PropertyTraceValidator()
        {
            RuleFor(x => x.DateSale)
                .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message);
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage(ResponseModelValidationEnum.NotEmpty.Message)
              .Length(3, 200).WithMessage(ResponseModelValidationEnum.Length.Message.Replace(":min", "3").Replace(":max", "200"));
            RuleFor(x => x.Value)
                .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message)
                .GreaterThanOrEqualTo(0).WithMessage(ResponseModelValidationEnum.GreaterThanOrEqualTo.Message.Replace(":max", "0"));
            RuleFor(x => x.Tax)
                .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message);
            RuleFor(x => x.IdProperty)
                .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message);
        }
    }
}
