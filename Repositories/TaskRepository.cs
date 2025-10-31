using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksSystemDBContext _dbContext;
        public TaskRepository(TasksSystemDBContext tasksSystemDBContext)
        {
            _dbContext = tasksSystemDBContext;
        }
        public async Task<List<TaskModel>> SearchAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> SearchById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TaskModel> Add(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskById = await SearchById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa para o Id: {id} não foi encontrato");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;    
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }
        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await SearchById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa para o Id: {id} não foi encontrato");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
