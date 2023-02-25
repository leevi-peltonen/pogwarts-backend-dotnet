using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Services
{
    public class UserService
    {
        private readonly PogwartsContext _context;
        public UserService(PogwartsContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var allUsers =  _context.User.Include(u => u.Characters).ToList();
                                       
            User user = allUsers.Find(user => user.UserId == id);
                        
            if(user != null)
            {
                return user;
            }else
            {
                return null;
            }
        }
        public async Task<User> CreateCharacterAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
