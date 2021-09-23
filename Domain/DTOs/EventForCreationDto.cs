using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
	public class EventForCreationDto
	{
		[Required(ErrorMessage = "Title is a required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Date is a required.")]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "Description is a required.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Category is a required.")]
		public string Category { get; set; }

		[Required(ErrorMessage = "Venue is a required.")]
		public string Venue { get; set; }

		public bool IsCancelled { get; set; }
	}
}