

using ConsoleApp.Core.Models.Base;

namespace ConsoleApp.Core.Repositories
{
    public interface IRepository<T> where T : Basemodel
    {
        public Task AddAsync(T model);
        public Task<T> GetAsync(Func <T,bool> statement);
        public Task <List<T>> GetAllAsync();    
        public Task RemoveAsync (T model);
    }
}
