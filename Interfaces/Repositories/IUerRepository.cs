public interface IUserRepository{

    public Task<User> GetUserById(int id);
    public Task<List<User>> GetAllUsers();
}