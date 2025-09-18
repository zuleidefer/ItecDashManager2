using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Entities.Company;

    public class Company
    {
        public Company() { }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ExternalIdentification { get; set; }

        public string PrimaryColor { get; set; }

        public ICollection<UserCompany.UserCompany> UserCompanies { get; set; }
    }

