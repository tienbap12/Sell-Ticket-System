using ST.Domain.Commons.Primitives;
using System.ComponentModel.DataAnnotations;

namespace ST.Domain.Entities
{
    public class Category : Entity
    {
        [StringLength(128)]
        public string Name { get; set; }

        public string ImagePath { get; set; }
        public int Status { get; set; }
    }
}