using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars.Core.Data;
using StarWars.Core.Models;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PeopleController : ControllerBase
    {

        private readonly IPeopleRepository _repository;

        public PeopleController(IPeopleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<People>> GetPeople()
        {
            return await _repository.GetMostAppearedPerson();
        }
    }
}
