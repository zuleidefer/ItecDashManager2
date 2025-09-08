using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;
using DashboardEntity = ItecDashManager.Domain.Entities.Dashboard.Dashboard;

namespace ItecDashManager.Domain.Entities.UserDashboard;

    public class UserDashboard
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DashboardId { get; set; }

        public User.User? User { get; set; }
        public DashboardEntity? Dashboard { get; set; }

    }

    
