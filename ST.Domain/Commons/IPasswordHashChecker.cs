using ST.Domain.Entities;

namespace ST.Domain.Commons
{
    public interface IPasswordHashChecker
    {
        bool HashesMatch(string providerPassword, Account user);
    }
}
