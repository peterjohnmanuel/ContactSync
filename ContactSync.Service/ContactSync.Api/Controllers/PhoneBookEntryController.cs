using System;
using System.Collections.Generic;
using AutoMapper;
using ContactSync.Common;
using ContactSync.Dto;
using ContactSync.Entities;
using ContactSync.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace ContactSync.Api.Controllers
{
    [Route("api/PhoneBook/{phoneBookId}/PhoneBookEntry")]
    public class PhoneBookEntryController : BaseController
    {
        private readonly IPhoneBookEntryBusinessLogic phoneBookEntryBusinessLogic;

        public PhoneBookEntryController(IMapper mapper, IPhoneBookEntryBusinessLogic phoneBookEntryBusinessLogic) : base (mapper)
        {
            this.phoneBookEntryBusinessLogic = phoneBookEntryBusinessLogic;
        }

        [HttpGet]
        public IActionResult Search(long phoneBookId, [FromQuery] string search)
        {
            try
            {
                var phoneBookEntries = phoneBookEntryBusinessLogic.SearchPhoneBookEntries(phoneBookId, search);

                return Ok(Mapper.Map<IEnumerable<PhoneBookEntry>, IEnumerable<PhoneBookEntryDto>>(phoneBookEntries));
            }
            catch (BusinessRuleException bre)
            {
                return BadRequest(bre.Message);
            }
            catch (Exception ex)
            {
                // todo: Remove generic exception.
                // todo: Add logging exception.
                return BadRequest("");
            }
        }


        [HttpGet]
        [Route("{phoneBookEntryId}")]
        public IActionResult GetByPhoneBookEntryId(long phoneBookId, long phoneBookEntryId)
        {
            try
            {
                var phoneBookEntry = phoneBookEntryBusinessLogic.GetPhoneBookEntryById(phoneBookId, phoneBookEntryId);

                return Ok(Mapper.Map<PhoneBookEntry, PhoneBookEntryDto>(phoneBookEntry));
            }
            catch (BusinessRuleException bre)
            {
                return BadRequest(bre.Message);
            }
            catch (Exception ex)
            {
                // todo: Remove generic exception.
                // todo: Add logging exception.
                return BadRequest("");
            }
        }


        [HttpPost]
        public IActionResult Post(long phoneBookId, [FromBody]PhoneBookEntryDto phoneBookEntryDto)
        {
            try
            {
                var phoneBookEntry = Mapper.Map<PhoneBookEntryDto, PhoneBookEntry>(phoneBookEntryDto);

                phoneBookEntryBusinessLogic.AddPhoneBookEntryToPhoneBook(phoneBookId, phoneBookEntry);
               
                return Created($"/api/PhoneBook/{phoneBookEntry.PhoneBook.Id}/PhoneBookEntry/{phoneBookEntry.Id}", Mapper.Map<PhoneBookEntry,PhoneBookEntryDto>(phoneBookEntry));
            }
            catch(BusinessRuleException bre)
            {
                return BadRequest(bre.Message);
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