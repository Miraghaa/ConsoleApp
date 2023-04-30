

using ConsoleApp.Core.Models.Base;
using ConsoleApp.Core.Repositories;

namespace ConsoleApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Basemodel
    {
        private readonly static  List<T> _items=new List<T>();
        public async Task AddAsync(T model)
        {
            _items.Add(model);
        }

        public async Task<List<T>> GetAllAsync()
        {
              return _items;
        }

        public async Task<T> GetAsync(Func<T, bool> statement)
        {
            return _items.FirstOrDefault(statement);
        }

        public async Task RemoveAsync(T model)
        {
            _items.Remove(model);
        }
    }
}
