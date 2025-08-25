using System.Data;
using AutoMapper;
using ItecDashManager.Domain.Entities;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.WebApi.ViewModels;
using ItecDashManager.WebApi.ViewModels.User;

namespace ItecDashManager.WebApi.Mappings
{
    public class AutoMapperProfileViewModels : Profile
    {
        public AutoMapperProfileViewModels()
        {
            CreateMap<RoleViewModel, Role>().ReverseMap();
            CreateMap<ActionViewModel, Action>().ReverseMap();
            CreateMap<RoleActionViewModel, RoleAction>().ReverseMap();
            CreateMap<MediaViewModel, Media>().ReverseMap();
            CreateMap<CompanyViewModel, Company>().ReverseMap();
            CreateMap<DashboardViewModel, Dashboard>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<UserCompanyRoleViewModel, UserCompanyRole>().ReverseMap();
            CreateMap<UserCompanyViewModel, UserCompany>().ReverseMap();
            CreateMap<UserDashboardViewModel, UserDashboard>().ReverseMap();
        }
    }
}
