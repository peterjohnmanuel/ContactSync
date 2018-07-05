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
    [Route("api/ContactGroup/{contactGroupId}/Contact")]
    public class ContactController : BaseController
    {
        private readonly IContactBusinessLogic contactBusinessLogic;

        public ContactController(IMapper mapper, IContactBusinessLogic contactBusinessLogic) : base (mapper)
        {
            this.contactBusinessLogic = contactBusinessLogic;
        }

        [HttpGet]
        public IActionResult Search(long contactGroupId, [FromQuery] string search)
        {
            try
            {
                var contacts = contactBusinessLogic.SearchContacts(contactGroupId, search);

                return Ok(Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDto>>(contacts));
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
        [Route("{contactId}")]
        public IActionResult GetByContactById(long contactGroupId, long contactId)
        {
            try
            {
                var contact = contactBusinessLogic.GetContactById(contactGroupId, contactId);

                return Ok(Mapper.Map<Contact, ContactDto>(contact));
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
        public IActionResult Post(long contactGroupId, [FromBody]ContactDto contactDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = Mapper.Map<ContactDto, Contact>(contactDto);

                    contactBusinessLogic.AddContactToContactGroup(contactGroupId, contact);

                    return Created($"/api/ContactGroup/{contact.ContactGroup.Id}/Contact/{contact.Id}", Mapper.Map<Contact, ContactDto>(contact));
                }

                return BadRequest(ModelState);
                
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

        [HttpPatch]
        [Route("{contactId}")]
        public IActionResult Patch(long contactGroupId, long contactId, [FromBody]ContactDto contactDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = Mapper.Map<ContactDto, Contact>(contactDto);

                    var updatedContact = contactBusinessLogic.UpdateContactInfo(contactGroupId, contactId, contact);

                    return Ok(Mapper.Map<Contact, ContactDto>(updatedContact));
                }

                return BadRequest(ModelState);

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
    }
}