using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Entities.UserCompanyRole;

    public class UserCompanyRole
    {
        public UserCompanyRole() { }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("UserCompany")]
        public Guid UserCompanyId { get; set; }
        public UserCompany.UserCompany UserCompany { get; set; }

        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Roles.Role Role { get; set; }
    }

