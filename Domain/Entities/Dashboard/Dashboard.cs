using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Entities.Dashboard;

    
    public class Dashboard
    {
        public required string Name { get; set; }
        public required string Url { get; set; }

   
        public ICollection<UserDashboard> UserDashboards { get; set; } = new List<UserDashboard>();
    }

