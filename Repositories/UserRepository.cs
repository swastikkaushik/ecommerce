public class UserRepository : IUserRepository{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context){
        _context = context;
    }

    public async Task<User> GetUserById(int id){
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAllUsers(){
        return await _context.Users.ToListAsync();
    }
}