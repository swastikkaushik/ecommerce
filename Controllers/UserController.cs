public class UserController : ControllerBase
{

    private readonly IUserService _userService;
    public UserController(IUserService userService){
        _userService = userService;
    }

    [HttptGet]
    public async Task<List<User>> GetUsers()
    {
        return await _userService.GetAllUsers();
    }
}