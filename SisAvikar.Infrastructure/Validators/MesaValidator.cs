using FluentValidation;
using SisAvikar.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAvikar.Infrastructure.Validators
{
    public class MesaValidator: AbstractValidator<MesaDto>
    {
        public MesaValidator()
        {
            RuleFor(mesa => mesa.Descripcion)
                .NotNull()
                .Length(1, 50);
        }
    }
}
