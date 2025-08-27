using System.Data;
using AutoMapper;
using ItecDashManager.Domain.Entities;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.WebApi.DTO.User;
using ItecDashManager.WebApi.DTO;
using ItecDashManager.Domain.Entities.Role;
using ItecDashManager.WebApi.DTO.Role;
using ItecDashManager.WebApi.DTO.Action;
using ItecDashManager.WebApi.DTO.RoleAction;
using ItecDashManager.Domain.Entities.RoleAction;
using ItecDashManager.Domain.Entities.Media;
using ItecDashManager.WebApi.DTO.Media;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.WebApi.DTO.Company;
using ItecDashManager.Domain.Entities.Dashboard;
using ItecDashManager.WebApi.DTO.Dashboard;
using ItecDashManager.Domain.Entities.UserCompanyRole;
using ItecDashManager.WebApi.DTO.UserCompanyRole;
using ItecDashManager.Domain.Entities.UserCompany;
using ItecDashManager.WebApi.DTO.UserCompany;
using ItecDashManager.Domain.Entities.UserDashboard;
using ItecDashManager.WebApi.DTO.UserDashboard;

namespace ItecDashManager.WebApi.Mappings
{
    public class AutoMapperProfileDTOs : Profile
    {
        public AutoMapperProfileDTOs()
        {
            CreateMap<Role, RoleDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Action, ActionDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<RoleAction, RoleActionDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Media, MediaDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Company, CompanyDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Dashboard, DashboardDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<User, UserDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<UserCompanyRole, UserCompanyRoleDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<UserCompany, UserCompanyDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<UserDashboard, UserDashboardDTO>().PreserveReferences().MaxDepth(0);
        }
    }
}
