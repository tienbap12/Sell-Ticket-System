using ST.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ST.Application.Feature.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand(int id) : ICommand<Result>
    {
        public int Id { get; set; } = id;
    }
}
