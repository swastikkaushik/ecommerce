using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;
    public UserController(IUserService userService){
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<User>> GetUsers()
    {
        return await _userService.GetAllUsers();
    }

    /// <summary>Returns one user and all of their orders.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> GetUserWithOrders(int id)
    {
        var user = await _userService.GetUserWithOrdersAsync(id);
        if (user is null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async  Task<User> CreateUserAsync(CreateUserRequest request)
    {
        return await _userService.CreateUserAsync(request);
    }
}