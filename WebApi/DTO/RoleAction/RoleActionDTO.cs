using System.ComponentModel.DataAnnotations;

namespace ItecDashManager.WebApi.DTO.RoleAction;

    public class RoleActionDTO
    {
        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public Guid ActionId { get; set; }
    }

