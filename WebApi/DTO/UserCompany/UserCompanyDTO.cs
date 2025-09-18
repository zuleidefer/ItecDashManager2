using System.ComponentModel.DataAnnotations;

namespace ItecDashManager.WebApi.DTO.UserCompany;

    public class UserCompanyDTO
    {
        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }

