namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            Name = fullName;
            Email = email;

        }
        public string Name { get;  set; }
        public string Email { get;  set; }

    }
}