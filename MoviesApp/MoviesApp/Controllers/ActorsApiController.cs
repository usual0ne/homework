using System;
using System.Collections.Generic;
using System.Linq;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Services;
using MoviesApp.Services.Dto;
using Microsoft.AspNetCore.Authorization;

namespace MoviesApp.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsApiController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorsApiController(IActorService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorDto>))]
        [ProducesResponseType(404)]
        [Authorize]
        public ActionResult<IEnumerable<ActorDto>> GetActors()
        {
            return Ok(_service.GetAllActors());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ActorDto))]
        [ProducesResponseType(404)]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var actor = _service.GetActor(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<ActorDto> PostActor(ActorDto inputDto)
        {
            var actor = _service.AddActor(inputDto);

            return CreatedAtAction("GetById", new { id = actor.Id }, actor);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateActor(int id, ActorDto editDto)
        {
            var actor = _service.UpdateActor(editDto);

            if(actor == null)
            {
                return BadRequest();
            }

            return Ok(actor);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ActorDto> DeleteActor(int id)
        {
            var actor = _service.DeleteActor(id);
            if(actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }
    }
}
