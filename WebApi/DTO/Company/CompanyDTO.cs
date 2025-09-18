using System.ComponentModel.DataAnnotations;

namespace ItecDashManager.WebApi.DTO.Company;

    public class CompanyDTO
    {
        [Required]
        public string Name { get; set; }

        public string ExternalIdentification { get; set; }

        public string PrimaryColor { get; set; }
    }

