using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
	public class EventRepository : RepositoryBase<Event>, IEventRepository
	{
		public EventRepository(AppDbContext appDbContext)
			: base(appDbContext)
		{
		}

		public async Task CreateEventAsync(Event eventToAdd)
		{
			await CreateAsync(eventToAdd);
		}

		public async Task<IList<Event>> GetAllEventsAsync(bool trackChanges)
		{
			return await FindAll(trackChanges).ToListAsync();
		}

		public async Task<Event> GetEventAsync(Guid eventID, bool trackChanges)
		{
			return await FindByCondition(e => e.EventId == eventID, trackChanges).SingleOrDefaultAsync();
		}

		public void UpdateEvent(Event eventToUpdate)
		{
			Update(eventToUpdate);
		}

		public void DeleteEvent(Event eventToDelete)
		{
			Delete(eventToDelete);
		}
	}
}