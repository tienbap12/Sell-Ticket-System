using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Contracts.Category
{
    public class CategoryRequest
    {
        public string Name { get; set; }
        public string? imagePath { get; set; }
        public string? superName { get; set; }
        public string? superId { get; set; }
        public int status { get; set; }
        public bool isPublic { get; set; }
        public bool priority { get; set; }
    }
}
