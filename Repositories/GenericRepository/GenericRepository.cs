using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.Data;
using ProiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories.GenericRepository
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: BaseEntity
    {
        protected readonly ProiectDAWContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(ProiectDAWContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        
        // Get all
        public async Task<List<TEntity>> GetAll()
        {
            //System.Diagnostics.Debug.WriteLine("GenericRepository");
            // the select to the DB and we get the result
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            // Only the select. Do not use toList, count etc before filtering the data
            return _table.AsNoTracking();

            //Do this
            //select * from entity where Id is not null
            //var entityListFiltered = _table.Where(x => x.Id.ToString() != "").ToList();
        }

        // Create
        public void Create(TEntity entity)
        {
            _table.Add(entity);
            Save();
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
            Save();
        }
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // Update
        public void Update(TEntity entity)
        {
            entity.DateModified = DateTime.Now;
            _table.Update(entity);
            Save();
        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
            Save();
        }

        // Delete
        public void Delete(Guid id)
        {
            var entity = _table.Find(id);
            _table.Remove(entity);
            Save();
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
            Save();
        }

        // Find
        public TEntity FindById(object id)
        {
            return _table.Find(id);
            //return _table.FirstOrDefault(x => x.Id.Equals(id));
        }
        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
            //return await _table.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        // Save
        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
