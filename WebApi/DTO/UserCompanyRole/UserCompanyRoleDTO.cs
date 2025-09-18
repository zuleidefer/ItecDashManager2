using System.ComponentModel.DataAnnotations;

namespace ItecDashManager.WebApi.DTO.UserCompanyRole;

    public class UserCompanyRoleDTO
    {
        [Required]
        public Guid UserCompanyId { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }

