using FreeCourse.Services.Catalog.Models;
using System;

namespace FreeCourse.Services.Catalog.Dtos
{
    public class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public Feature Feature { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
