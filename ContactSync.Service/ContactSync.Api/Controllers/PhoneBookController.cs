using System;
using System.Collections.Generic;
using AutoMapper;
using ContactSync.Dto;
using ContactSync.Entities;
using ContactSync.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ContactSync.Api.Controllers
{
    [Route("api/[controller]")]
    public class PhoneBookController : BaseController
    {
        private readonly IPhoneBookRepository phoneBookRepository;

        public PhoneBookController(IMapper mapper, IPhoneBookRepository phoneBookRepository) : base(mapper)
        {
            this.phoneBookRepository = phoneBookRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var phoneBooks = phoneBookRepository.GetAllPhoneBooks();
                var dtoPhoneBooks = Mapper.Map<IEnumerable<PhoneBook>, IEnumerable<PhoneBookDto>>(phoneBooks);

                return Ok(dtoPhoneBooks);
            }
            catch (Exception ex)
            {
                // todo: Remove generic exception.
                // todo: Add logging exception.
                return BadRequest("");
            }
        }
    }
}