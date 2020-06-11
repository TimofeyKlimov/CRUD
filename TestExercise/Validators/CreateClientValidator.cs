using Domain.Contract;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExercise.Commands;

namespace TestExercise.Validators
{
    public class CreateClientValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientValidator()
        {
            RuleFor(s => s.CreateClientContract.Name).NotEmpty().NotNull()
                .WithMessage("Name is null");
            RuleFor(s => s.CreateClientContract.TIN).NotNull().NotEmpty()
                .WithMessage("TIN is null");
            RuleFor(s => s.CreateClientContract.ClientType).NotEmpty().NotNull()
                .WithMessage("ClientType is null");
        }
    }
}
