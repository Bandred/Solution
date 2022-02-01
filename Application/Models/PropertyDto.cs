using CrossCutting.Entities;
using CrossCutting.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class PropertyDto : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public string Year { get; set; }
        public Guid IdOwner { get; set; }

        public virtual OwnerDto Owner { get; set; }
        public virtual IList<PropertyImageDto> PropertyImages { get; set; }
        public virtual IList<PropertyTraceDto> PropertyTraces { get; set; }
    }

    public class PropertyValidator : AbstractValidator<PropertyDto>
    {
        public PropertyValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage(ResponseModelValidationEnum.NotEmpty.Message)
               .Length(3, 200).WithMessage(ResponseModelValidationEnum.Length.Message.Replace(":min", "3").Replace(":max", "200"));
            RuleFor(x => x.Address)
               .NotEmpty().WithMessage(ResponseModelValidationEnum.NotEmpty.Message)
               .Length(3, 200).WithMessage(ResponseModelValidationEnum.Length.Message.Replace(":min", "3").Replace(":max", "200"));
            RuleFor(x => x.Price)
               .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message)
               .GreaterThanOrEqualTo(0).WithMessage(ResponseModelValidationEnum.GreaterThanOrEqualTo.Message.Replace(":max", "0"));
            RuleFor(x => x.CodeInternal)
               .NotEmpty().WithMessage(ResponseModelValidationEnum.NotEmpty.Message)
               .Length(3, 200).WithMessage(ResponseModelValidationEnum.Length.Message.Replace(":min", "3").Replace(":max", "200"));
            RuleFor(x => x.Year)
               .NotEmpty().WithMessage(ResponseModelValidationEnum.NotEmpty.Message)
               .Length(4, 200).WithMessage(ResponseModelValidationEnum.Length.Message.Replace(":min", "4").Replace(":max", "10"));
            RuleFor(x => x.IdOwner)
               .NotNull().WithMessage(ResponseModelValidationEnum.NotNull.Message);
        }
    }
}
