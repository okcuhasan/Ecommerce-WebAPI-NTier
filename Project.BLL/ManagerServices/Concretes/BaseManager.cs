using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected IRepository<T> _irp; // BaseRepository<T> ile aynı türde

        public BaseManager(IRepository<T> irp) // IRepository<T> gördüğün yerde BaseRepository<T> nin instace ını alacaksın
        {
          _irp = irp;
        }

        public string Add(T item)
        {
            if(item.CreatedDate != null) // iş akışı
            {
                _irp.Add(item); // dal 
                return "Ekleme başarılıdır"; // iş akışı
            }
            else
            {
                return "Ekleme başarısızdır"; // iş akışı
            }
        }
        public async Task AddAsync(T item)
        {
            // Todo : iş akışı yazılabilir
            await _irp.AddAsync(item);
        }

        public async Task AddRangeAsync(List<T> list)
        {
            // Todo : iş akışı yazılabilir
            await _irp.AddRangeAsync(list);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            // Todo : iş akışı yazılabilir
            return await _irp.AnyAsync(exp);
        }

        public void Delete(T item)
        {
            // Todo : iş akışı yazılabilir
            _irp.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            // Todo : iş akışı yazılabilir
            _irp.DeleteRange(list);
        }

        public void Destroy(T item)
        {
            // Todo : iş akışı yazılabilir
            _irp.Destroy(item);
        }

        public void DestroyRange(List<T> list)
        {
            // Todo : iş akışı yazılabilir
            _irp.DestroyRange(list);
        }

        public async Task<T> FindAsync(int id)
        {
            // Todo : iş akışı yazılabilir
            return await _irp.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            // Todo : iş akışı yazılabilir
            return await _irp.FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
            // Todo : iş akışı yazılabilir
            return _irp.GetActives();
        }

        public IQueryable<T> GetAll()
        {
            // Todo : iş akışı yazılabilir
            return _irp.GetAll();
        }

        public IQueryable<T> GetModifieds()
        {
            // Todo : iş akışı yazılabilir
            return _irp.GetModifieds();
        }

        public IQueryable<T> GetPassives()
        {
            // Todo : iş akışı yazılabilir
            return _irp.GetPassives();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            // Todo : iş akışı yazılabilir
            return _irp.Select(exp);
        }

        public async Task Update(T item)
        {
            // Todo : iş akışı yazılabilir
            await _irp.Update(item);
        }

        public async Task UpdateRange(List<T> list)
        {
            // Todo : iş akışı yazılabilir
            await _irp.UpdateRange(list);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            // Todo : iş akışı yazılabilir
            return _irp.Where(exp);
        }
    }
}
