using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Commons.Abstractions
{
    public interface IPasswordHasher
    {
        (string, string) HashPassword(string password);
    }
}
