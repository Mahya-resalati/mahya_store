namespace mahya_store.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public String FullName { get; set; }
        public String Email { get; set; }
        public List<RolesInRegisterUserDto> Roles { get; set; }

        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
