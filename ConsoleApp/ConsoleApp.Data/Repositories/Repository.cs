

using ConsoleApp.Core.Models.Base;
using ConsoleApp.Core.Repositories;

namespace ConsoleApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Basemodel
    {
        private readonly  List<T> _Items=new List<T>();
        public async Task AddAsync(T model)
        {
            _Items.Add(model);
        }

        public async Task<List<T>> GetAllAsync()
        {
              return _Items;
        }

        public async Task<T> GetAsync(Func<T, bool> statement)
        {
            return _Items.FirstOrDefault(statement);
        }

        public async Task RemoveAsync(T model)
        {
            _Items.Remove(model);
        }
    }
}
