using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIDIMSClient.Api.Models.Inventory;
using SIDIMSClient.Api.Persistence;
using SIDIMSClient.Api.ViewModel;

namespace SIDIMSClient.Api.Controllers
{
    [Route("api/cardissuance/{clientId}")]
    public class IssuancesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public IssuancesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<CardIssuanceResource>> GetClientIssuances(int clientId)
        {
            var products = await context.CardIssuances
                .ToListAsync();

            return mapper.Map<IEnumerable<CardIssuance>, IEnumerable<CardIssuanceResource>>(products);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateClientIssuance([FromBody] CardIssuanceSaveResource entity)
        {
           return null;
        }

    }
}