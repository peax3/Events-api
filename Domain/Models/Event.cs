using System;

namespace Domain.Models
{
	public class Event
	{
		public Guid EventId { get; set; }
		public string Title { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string Venue { get; set; }
		public bool IsCancelled { get; set; }
	}
}