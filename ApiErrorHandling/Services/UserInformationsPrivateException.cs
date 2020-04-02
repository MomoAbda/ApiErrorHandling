using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;

namespace ApiErrorHandling.Core
{
    public class UserInformationsPrivateException : HttpResponseException, IBusinessException
    {
        public UserInformationsPrivateException(HttpStatusCode httpStatusCode) : base(httpStatusCode)  {  }

        public ProblemDetails ProblemDetails => new ProblemDetails
        {
            Status = 40001,
            Type = "https://editus-tech/mybusiness-gateway/error/details/#40001",
            Title = "This information is private",
            Detail = "The user want their salary information stay private."
        };
    }
}
