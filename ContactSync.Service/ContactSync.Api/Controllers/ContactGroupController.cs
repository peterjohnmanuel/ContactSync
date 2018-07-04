﻿using System;
using System.Collections.Generic;
using AutoMapper;
using ContactSync.Dto;
using ContactSync.Entities;
using ContactSync.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace ContactSync.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContactGroupController : BaseController
    {
        private readonly IContactGroupBusinessLogic contactGroupBusinessLogic;

        public ContactGroupController(IMapper mapper, IContactGroupBusinessLogic contactGroupBusinessLogic) : base(mapper)
        {
            this.contactGroupBusinessLogic = contactGroupBusinessLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var contactGroups = contactGroupBusinessLogic.GetAllContactGroups();
                var dtoContactGroups = Mapper.Map<IEnumerable<ContactGroup>, IEnumerable<ContactGroupDto>>(contactGroups);

                return Ok(dtoContactGroups);
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