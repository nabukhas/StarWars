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
using StarWars.Core.ViewModel;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PlanetsController : ControllerBase
    {

        private readonly IPlanetsRepository _repository;

        public PlanetsController(IPlanetsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlanetsViewModel>>> GetPlanets()
        {
            return await _repository.GetMostAppearedPlanets();
        }
    }
}
