using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;

namespace ItecDashManager.Domain.Entities.Dashboard;

    
    public class Dashboard
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

   
        public ICollection<UserDashboard.UserDashboard> UserDashboards { get; set; } = new List<UserDashboard.UserDashboard>();
    }


