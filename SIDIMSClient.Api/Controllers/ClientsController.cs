using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIDIMSClient.Api.Models.Inventory;
using SIDIMSClient.Api.Models.Lookups;
using SIDIMSClient.Api.Persistence;
using SIDIMSClient.Api.ViewModel;

namespace SIDIMSClient.Api.Controllers
{
    [Route("api/clients/")]
    public class ClientsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public ClientsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SidClientResource>> GetSidClients()
        {
            var results = await context.SidClients.ToListAsync();
            return mapper.Map<IEnumerable<SidClient>, IEnumerable<SidClientResource>>(results);
        }

        [HttpGet("{clientId}/products")]
        public async Task<IEnumerable<ProductResource>> GetSidProducts(int clientId)
        {
            var products = await context.SidProducts.Where(p => p.SidClientId == clientId)
                .Include(s => s.SidClient)
                .ToListAsync();

            return mapper.Map<IEnumerable<SidProduct>, IEnumerable<ProductResource>>(products);
        }

        [HttpGet("{clientId}/products/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await context.SidProducts
                .Include(i => i.SidClient)
                .SingleOrDefaultAsync(it => it.Id == id);

            if (product == null) return NotFound();

            var result = mapper.Map<SidProduct, ProductResource>(product);

            return Ok(result);
        }

        // [HttpGet("{clientId}/products/{id}/stocklists")]
        // public async Task<IActionResult> GetProductStock(int clientId, int id)
        // {
        //     var product = await context.ClientStockReports
        //         .SingleOrDefaultAsync(it => it.Id == id);

        //     if (product == null) return NotFound();

        //     var result = mapper.Map<SidProduct, ProductResource>(product);

        //     return Ok(result);
        // }

        [HttpGet("{clientId}/products/{productId}/stocklists")]
        public async Task<IEnumerable<ClientStockReportResource>> GetSidProductStocks(int clientId, int productId)
        {
            var stocks = await context.ClientStockReports.Where(p => p.SidProductId == productId)
                .Include(s => s.ClientVaultReport)
                .ToListAsync();

            return mapper.Map<IEnumerable<ClientStockReport>, IEnumerable<ClientStockReportResource>>(stocks);
        }




    }
}