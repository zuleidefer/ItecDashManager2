using System.Data;
using AutoMapper;
using ItecDashManager.Domain.Entities;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Entities.Dashboard;
using ItecDashManager.Domain.Entities.Media;
using ItecDashManager.Domain.Entities.Role;
using ItecDashManager.Domain.Entities.RoleAction;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.Domain.Entities.UserCompany;
using ItecDashManager.Domain.Entities.UserCompanyRole;
using ItecDashManager.Domain.Entities.UserDashboard;
using ItecDashManager.WebApi.ViewModels;
using ItecDashManager.WebApi.ViewModels.Action;
using ItecDashManager.WebApi.ViewModels.Company;
using ItecDashManager.WebApi.ViewModels.Dashboard;
using ItecDashManager.WebApi.ViewModels.Media;
using ItecDashManager.WebApi.ViewModels.Role;
using ItecDashManager.WebApi.ViewModels.RoleAction;
using ItecDashManager.WebApi.ViewModels.User;
using ItecDashManager.WebApi.ViewModels.UserCompany;
using ItecDashManager.WebApi.ViewModels.UserCompanyRole;
using ItecDashManager.WebApi.ViewModels.UserDashboard;

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
