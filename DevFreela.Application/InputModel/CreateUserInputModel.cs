namespace DevFreela.Application.InputModel
{
    public class CreateUserInputModel
    {
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}