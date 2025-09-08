using System;

namespace ItecDashManager.WebApi.ViewModels.UserDashboard;

    public class UserDashboardViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DashboardId { get; set; }
    }

