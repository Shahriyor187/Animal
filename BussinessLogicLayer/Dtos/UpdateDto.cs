﻿using DataAccsesLayer.Entities;

namespace Animals.Dtos
{
    public class UpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Homeland { get; set; } = string.Empty;
        public int CategoryId { get; set; } 
    }
}
