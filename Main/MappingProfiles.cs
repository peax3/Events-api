using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace Main
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<EventForCreationDto, Event>();
		}
	}
}