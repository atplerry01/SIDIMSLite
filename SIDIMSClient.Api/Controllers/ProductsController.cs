using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIDIMSClient.Api.Models.Lookups;
using SIDIMSClient.Api.Persistence;
using SIDIMSClient.Api.ViewModel;

namespace SIDIMSClient.Api.Controllers
{
    [Route("api/products/")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetSidProducts()
        {
            var products = await context.SidProducts
                .Include(s => s.SidClient)
                .ToListAsync();
            return mapper.Map<IEnumerable<SidProduct>, IEnumerable<ProductResource>>(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssueTracker(int id)
        {

            var issueTracker = await context.SidProducts
                .SingleOrDefaultAsync(it => it.Id == id);

            if (issueTracker == null) return NotFound();

            var issueTrackerResource = mapper.Map<SidProduct, ProductResource>(issueTracker);

            return Ok(issueTrackerResource);
        }



        [HttpPost("create")]
        public async Task<IActionResult> CreateProductResource([FromBody] ProductSaveResource productResource)
        {
            var SidProduct = mapper.Map<ProductSaveResource, SidProduct>(productResource);

            context.SidProducts.Add(SidProduct);
            await context.SaveChangesAsync();

            SidProduct = await context.SidProducts
                .SingleOrDefaultAsync(it => it.Id == SidProduct.Id);

            var result = mapper.Map<SidProduct, ProductResource>(SidProduct);
            return Ok(result);
        }



    }
}