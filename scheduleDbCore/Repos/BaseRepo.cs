using Microsoft.EntityFrameworkCore;
using scheduleDbCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scheduleDbCore.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly ScheduleEntities _db;

        public BaseRepo()
        {
            _db = new ScheduleEntities();
            _table = _db.Set<T>();
        }

        protected ScheduleEntities Context => _db;

        public void Dispose()
        {
            _db?.Dispose();
        }

        public virtual int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }

        public virtual int AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }

        public virtual int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public virtual List<T> ExecuteQuery(string sql) { throw new Exception(); }

        public virtual List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => _table.FromSqlRaw(sql, sqlParametersObjects).ToList();

        public virtual List<T> GetAll() => _table.ToList();

        public virtual T GetOne(int? key) => _table.Find(key);

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) { throw; }

            catch (DbUpdateException ex) { throw; }


            catch (Exception ex) { throw; }
        }
    }
}
