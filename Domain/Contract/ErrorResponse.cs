using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Domain.Contract
{
    public class ErrorResponse
    {
        public ErrorResponse(List<ErrorModel> errorModels)
        {
            ErrorModels = errorModels;
        }

        public List<ErrorModel> ErrorModels { get; }
    }
}
