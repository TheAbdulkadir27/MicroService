using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Mapping
{
    public class GenerallMapping : Profile
    {
        public GenerallMapping()
        {
            CreateMap<Category, Category>().ReverseMap();
            CreateMap<CourseCreateDto, CourseDto>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<CourseUpdateDto, Course>().ReverseMap();
            CreateMap<FeatureDto, Feature>().ReverseMap();
        }
    }
}
