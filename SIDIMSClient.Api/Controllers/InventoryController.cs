using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIDIMSClient.Api.Models.Inventory;
using SIDIMSClient.Api.Persistence;
using SIDIMSClient.Api.ViewModel;

namespace SIDIMSClient.Api.Controllers
{
    [Route("api/inventory/")]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public InventoryController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

    }
}