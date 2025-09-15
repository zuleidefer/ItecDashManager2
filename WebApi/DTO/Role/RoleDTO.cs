using System.ComponentModel.DataAnnotations;

namespace ItecDashManager.WebApi.DTO.Role;

    public class RoleDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }

