using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IEventRepository
	{
		Task CreateEventAsync(Event eventToAdd);

		void UpdateEvent(Event eventToUpdate);

		void DeleteEvent(Event eventToDelete);

		Task<IList<Event>> GetAllEventsAsync(bool trackChanges);

		Task<Event> GetEventAsync(Guid eventID, bool trackChanges);
	}
}