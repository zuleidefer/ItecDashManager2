using System.Data;
using AutoMapper;
using ItecDashManager.Domain.Entities;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.WebApi.DTO.User;
using ItecDashManager.WebApi.DTO;

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
