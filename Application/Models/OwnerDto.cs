using CrossCutting.Entities;
using CrossCutting.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class OwnerDto : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public DateTime Birthday { get; set; }

        public virtual IList<PropertyDto> Properties { get; set; }
    }

    public class OwnerValidator : AbstractValidator<OwnerDto>
    {
        public OwnerValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage(ResponseModelValidationEnum.NotEmpty.Message)
               .Length(3, 200).WithMessage(ResponseModelValidationEnum.Length.Message.Replace(":min", "3").Replace(":max", "200"));
            RuleFor(x => x.Address)
               .NotEmpty().WithMessage(ResponseModelValidationEnum.NotEmpty.Message)
               .Length(3, 200).WithMessage(ResponseModelValidationEnum.Length.Message.Replace(":min", "3").Replace(":max", "200"));
        }
    }
}
