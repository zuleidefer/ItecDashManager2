using ItecDashManager.WebApi.ViewModels.Company;
using ItecDashManager.WebApi.ViewModels.User;

namespace ItecDashManager.WebApi.ViewModels.UserCompany;

    public class UserCompanyViewModel
    {
        public Guid Id { get; set; }

        public CompanyViewModel Company { get; set; }

        public UserViewModel User { get; set; }
    }

