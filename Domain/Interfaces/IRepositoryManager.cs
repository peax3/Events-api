using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IRepositoryManager
	{
		IEventRepository Event { get; }

		Task<int> SaveChangesAsync();
	}
}