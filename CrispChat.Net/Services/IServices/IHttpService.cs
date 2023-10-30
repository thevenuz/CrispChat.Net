using CrispChat.Net.Models;

namespace CrispChat.Net.Services.IServices
{
    internal interface IHttpService
    {
        Task<Result<T, ErrorResult>> RequestAsync<T>(Request request);
    }
}
