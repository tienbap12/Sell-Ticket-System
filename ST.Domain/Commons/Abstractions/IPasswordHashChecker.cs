using ST.Domain.Entities;

namespace ST.Domain.Commons.Abstractions
{
    public interface IPasswordHashChecker
    {
        bool HashesMatch(string providerPassword, Account user);
    }
}