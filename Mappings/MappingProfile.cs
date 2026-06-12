using AutoMapper;
using ProjectPortal.DTOs;
using ProjectPortal.Models;

namespace ProjectPortal.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateTaskDto, TaskItem>();

        CreateMap<UpdateTaskDto, TaskItem>();
        
        CreateMap<CreateProjectDto, Project>();
        
        CreateMap<UpdateProjectDto, Project>();
        
        CreateMap<CreateUserDto, User>();

        CreateMap<UpdateUserDto, User>();
    }
}