namespace ItecDashManager.WebApi.ViewModels.User
{
    public class UserSignInResponseViewModel
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
