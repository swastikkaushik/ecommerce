public class UserService : IUserService{

    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository){
        _userRepository = userRepository;
    }

    public async Task<User> GetUserById(int id){
        return await _userRepository.GetUserById(id);
    }

    public async Task<List<User>> GetAllUsers(){
        return await _userRepository.GetAllUsers();
    }
}