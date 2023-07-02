using LearningCenter.API.Request;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.API.Mapper;
using AutoMapper;

public class RequesToModel : Profile
{
    public RequesToModel()
    {
        CreateMap<TutorialRequest, Tutorial>();
    }
}