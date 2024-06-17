namespace TypicalTechTools.Models
{
    public class CreateUserDTO
    {

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirmation { get; set; } = string.Empty;

    }
}
