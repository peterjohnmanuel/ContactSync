using System;
using System.Collections.Generic;
using AutoMapper;
using ContactSync.Dto;
using ContactSync.Entities;
using ContactSync.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace ContactSync.Api.Controllers
{
    [Route("api/[controller]")]
    public class PhoneBookController : BaseController
    {
        private readonly IPhoneBookBusinessLogic phoneBookBusinessLogic;

        public PhoneBookController(IMapper mapper, IPhoneBookBusinessLogic phoneBookBusinessLogic) : base(mapper)
        {
            this.phoneBookBusinessLogic = phoneBookBusinessLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var phoneBooks = phoneBookBusinessLogic.GetAllPhoneBooks();
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