using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksSystemDBContext _dbContext;
        public UserRepository(TasksSystemDBContext tasksSystemDBContext)
        {
            _dbContext = tasksSystemDBContext;
        }
        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> SearchById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await SearchById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o Id: {id} não foi encontrato");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;    

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
        public async Task<bool> Delete(int id)
        {
            UserModel userById = await SearchById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o Id: {id} não foi encontrato");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
