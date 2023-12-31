﻿using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.FiltersDb;
using LibraryAPI.Services;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController:ControllerBase
    {
        private readonly IRentalRepository _repo;
        private readonly IRentalService _rentalService;

        public RentalController(IRentalRepository repo,IRentalService rentalUser)
        {
            _repo = repo;
            _rentalService = rentalUser;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateRentalDto createRentalDto)
        {
          var result = await _rentalService.CreateAsync(createRentalDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _rentalService.GetAsync();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _rentalService.GetByIdAsync(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateRentalDto updateRentalDto)
        {
            var result = await _rentalService.UpdateAsync(updateRentalDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] FilterDb request)
        {
            var result = await _rentalService.GetPagedAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetRented()
        {
            var result = await _rentalService.Dash();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
    }
}