public interface IUserRepository{

    public Task<User?> GetUserById(int id);
    public Task<User?> GetUserWithOrdersAsync(int id);
    public Task<List<User>> GetAllUsers();
    public Task<User> CreateUserAsync(CreateUserRequest request);
}