using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExercise.Commands;

namespace TestExercise.Validators
{
    public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientValidator()
        {
            RuleFor(s => s.UpdateClient.Name).NotEmpty().NotNull();
            RuleFor(s => s.UpdateClient.ClientType).NotEmpty().NotNull();
            RuleFor(s => s.UpdateClient.TIN).NotNull().NotEmpty();
        }
    }
}
