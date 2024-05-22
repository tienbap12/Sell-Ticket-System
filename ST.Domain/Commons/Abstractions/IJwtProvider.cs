using ST.Domain.Entities;

namespace ST.Application.Commons.Abstractions
{
    public interface IJwtProvider
    {
        string Generate(Account req);
    }
}
