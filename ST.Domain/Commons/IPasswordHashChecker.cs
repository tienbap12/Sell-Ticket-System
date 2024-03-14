using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Domain.Commons
{
    public interface IPasswordHashChecker
    {
        bool HashesMatch(string providerPassword, Account user);
    }
}
