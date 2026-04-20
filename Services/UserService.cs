public class UserService : IUserService{

    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository){
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserById(int id){
        return await _userRepository.GetUserById(id);
    }

    public async Task<User?> GetUserWithOrdersAsync(int id)
    {
        return await _userRepository.GetUserWithOrdersAsync(id);
    }

    public async Task<List<User>> GetAllUsers(){
        return await _userRepository.GetAllUsers();
    }

    public async Task<User> CreateUserAsync(CreateUserRequest request){
        return await _userRepository.CreateUserAsync(request);
    }
}