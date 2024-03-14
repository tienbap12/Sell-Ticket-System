using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Wrappers
{
    public interface ICommand<out T> : IRequest<T>
    {
    }
}
