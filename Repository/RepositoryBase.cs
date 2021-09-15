using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		private readonly AppDbContext _appDbContext;

		public RepositoryBase(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}

		public async Task CreateAsync(T entity)
		{
			await _appDbContext.Set<T>().AddAsync(entity);
		}

		public IQueryable<T> FindAll(bool trackChanges)
		{
			var entities = trackChanges ? _appDbContext.Set<T>().AsTracking() : _appDbContext.Set<T>().AsNoTracking();
			return entities;
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
		{
			var entities = trackChanges ? _appDbContext.Set<T>().Where(expression).AsTracking() : _appDbContext.Set<T>().Where(expression).AsNoTracking();
			return entities;
		}

		public void Update(T entity)
		{
			_appDbContext.Set<T>().Update(entity);
		}

		public void Delete(T entity)
		{
			_appDbContext.Set<T>().Remove(entity);
		}
	}
}