using System.Net;

namespace GavelPoMobile.Application.Common.Errors;
public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
