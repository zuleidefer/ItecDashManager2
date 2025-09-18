using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Entities.UserCompany;

    public class UserCompany
    {
        public UserCompany() { }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Company.Company Company { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User.User User { get; set; }

        public ICollection<UserCompanyRole.UserCompanyRole> UserCompanyRoles { get; set; }
    }

