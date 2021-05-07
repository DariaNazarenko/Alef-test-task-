using System;
using System.Collections.Generic;
using System.Text;
using Alef_Vinal.Services.DTOs;
using FluentValidation;

namespace Alef_Vinal.Services.Validation
{
    public class ValueCodeValidator : AbstractValidator<ValueCodeDto>
    {
        public ValueCodeValidator()
        {
            RuleFor(c => c.Code)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(t => t.Value)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("{PropertyName} is empty");
        }
    }
}
