using System.ComponentModel.DataAnnotations;

namespace ItecDashManager.WebApi.DTO.Action;

    public class ApplicationActionDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }

