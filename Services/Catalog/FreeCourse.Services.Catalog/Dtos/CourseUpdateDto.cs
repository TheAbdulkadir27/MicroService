﻿using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Dtos
{
    public class CourseUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public Feature Feature { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
