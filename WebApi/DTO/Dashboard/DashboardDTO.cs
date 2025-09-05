namespace ItecDashManager.WebApi.DTO.Dashboard;

    public class DashboardDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Url { get; set; }
    }

