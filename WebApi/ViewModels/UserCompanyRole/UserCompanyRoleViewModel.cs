using ItecDashManager.WebApi.ViewModels.Role;
using ItecDashManager.WebApi.ViewModels.UserCompany;

namespace ItecDashManager.WebApi.ViewModels.UserCompanyRole;

    public class UserCompanyRoleViewModel
    {
        public Guid Id { get; set; }

        public UserCompanyViewModel UserCompany { get; set; }

        public RoleViewModel Role { get; set; }
    }

