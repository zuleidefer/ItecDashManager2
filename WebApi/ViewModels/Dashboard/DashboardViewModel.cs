using System;

namespace ItecDashManager.WebApi.ViewModels.Dashboard;

    public class DashboardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

