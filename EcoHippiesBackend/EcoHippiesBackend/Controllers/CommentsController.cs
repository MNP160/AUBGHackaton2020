﻿using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Models;
using EcoHippiesBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController :ControllerBase
    {
        private CommentsService _service;

        public CommentsController(CommentsService service)
        {
            _service = service;

        }


        [HttpGet("")]

        public async Task<ActionResult<List<CommentsDTO>>> Get()
        {
            var values = await _service.Read();
            if (values != null)
            {
              
                return Ok(values);
            }
            else
            {
                return BadRequest("something broke");
            }

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CommentsDTO>> Get(int id)
        {
            var dto = await _service.ReadById(id);
            if (dto != null)
            {
                return Ok(dto);
            }

            else
            {
                return BadRequest("Didnt find Item");
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Put(Comments value)
        {

            var entity = await _service.Update(value);

            if (entity != null)
                return Ok(entity);
            else
            {
                return BadRequest("something broke");
            }


        }

        [HttpPost("")]

        public async Task<ActionResult<Comments>> Post(Comments value)
        {

            System.Diagnostics.Debug.WriteLine("Testing");
            var entity = await _service.Create(value);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest("something broke ");
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Comments>> Delete(int id)
        {
            var entity = await _service.Delete(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }
    }
}
