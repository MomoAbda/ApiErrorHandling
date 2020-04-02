using Microsoft.AspNetCore.Mvc;

namespace ApiErrorHandling.Core
{
    public interface IBusinessException
    {
        ProblemDetails ProblemDetails { get; }
    }
}
