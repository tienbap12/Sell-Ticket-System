using System.ComponentModel.DataAnnotations;

namespace ST.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string SuperName { get; set; }
        public string SuperId { get; set; }
        public int Status { get; set; }
        public bool IsPublic { get; set; }
        public bool Priority { get; set; }
    }
}
