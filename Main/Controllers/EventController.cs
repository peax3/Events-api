using AutoMapper;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public EventController(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this._repositoryManager = repositoryManager;
			this._mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IList<Event>>> GetEvents()
		{
			var events = await _repositoryManager.Event.GetAllEventsAsync(false);
			return Ok(events);
		}

		[HttpGet("{eventId}")]
		public async Task<ActionResult<Event>> GetEvent(Guid eventId)
		{
			var eventToReturn = await _repositoryManager.Event.GetEventAsync(eventId, false);
			return Ok(eventToReturn);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEvent([FromBody] EventForCreationDto eventInputDto)
		{
			var eventToAdd = _mapper.Map<Event>(eventInputDto);
			await _repositoryManager.Event.CreateEventAsync(eventToAdd);
			await _repositoryManager.SaveChangesAsync();
			return new StatusCodeResult(201);
		}

		[HttpPut("{eventId}")]
		public async Task<IActionResult> UpdateEvent(Guid eventId, [FromBody] EventForCreationDto eventInputDto)
		{
			var eventToUpdate = await _repositoryManager.Event.GetEventAsync(eventId, true);
			_mapper.Map(eventInputDto, eventToUpdate);
			await _repositoryManager.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{eventId}")]
		public async Task<IActionResult> DeleteEvent(Guid eventId)
		{
			var eventToDelete = await _repositoryManager.Event.GetEventAsync(eventId, true);
			_repositoryManager.Event.DeleteEvent(eventToDelete);
			await _repositoryManager.SaveChangesAsync();
			return Ok();
		}
	}
}