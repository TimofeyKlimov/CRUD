using Domain.Contract;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestExercise.PipelinesBehavior
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse:class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var fails = _validators.Select(s => s.Validate(context)).SelectMany(s => s.Errors).Where(s => s != null).ToList();
            var responseType = typeof(TResponse);
            if(fails.Any())
            {
                var list = new List<ErrorModel>();
                foreach(var fail in fails)
                {
                    var error = new ErrorModel()
                    {
                        Message = fail.ErrorMessage,
                        Property = fail.PropertyName
                    };
                    list.Add(error);
                }

                var response = Activator.CreateInstance(responseType, list);
                return response as TResponse;
            }
            return await  next();
        }
    }
}
