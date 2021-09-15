using Domain.Interfaces;
using Persistence;
using System.Threading.Tasks;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly AppDbContext _appDbContext;
		private IEventRepository _eventRepository;

		public RepositoryManager(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}

		public IEventRepository Event => _eventRepository ??= new EventRepository(_appDbContext);

		public async Task<int> SaveChangesAsync()
		{
			return await _appDbContext.SaveChangesAsync();
		}
	}
}