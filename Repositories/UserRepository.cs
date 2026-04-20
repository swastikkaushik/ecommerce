using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context){
        _context = context;
    }

    public async Task<User?> GetUserById(int id){
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserWithOrdersAsync(int id)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<User>> GetAllUsers(){
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateUserAsync(CreateUserRequest request){

        var user = new User{Name = request.Name, CreatedAt = DateTime.UtcNow};
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}