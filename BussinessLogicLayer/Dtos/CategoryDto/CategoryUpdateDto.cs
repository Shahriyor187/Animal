using DataAccsesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Dtos.CategoryDto
{
    public class CategoryUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Homeland { get; set; } = string.Empty;
        public int CategoryId; 
    }
}
