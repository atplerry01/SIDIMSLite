using System;
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
    [Route("api/cardflows")]
    public class CardFlowsController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CardFlowsController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        
        
        #region CardIssuance
      
        [HttpPost("issuance/create")]
        public async Task<IActionResult> CreateClientCardIssuance([FromBody] CardIssuanceSaveResource entity)
        {
            var product = await context.SidProducts.SingleOrDefaultAsync(v => v.Id == entity.ProductId);
            if (product == null) return NotFound();

            var currentStock = context.ClientStockReports.Where(a => a.SidProductId == product.Id && (a.CreatedOn.Year == DateTime.Now.Year && a.CreatedOn.Month == DateTime.Now.Month && a.CreatedOn.Day == DateTime.Now.Day)).Take(1).FirstOrDefault();
            var vaultReport = await context.ClientVaultReports.SingleOrDefaultAsync(v => v.SidProductId == product.Id);

            if (vaultReport == null) {
                vaultReport = new ClientVaultReport() {
                    SidProductId = product.Id,
                    OpeningStock = 0,
                    ClosingStock = 0,
                    CurrentStock = 0,
                    CreateOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };
                context.ClientVaultReports.Add(vaultReport);
            }

            //Todo: Update previous closing stock base on the yesterday closing stock
            if (currentStock == null) {
                currentStock = new ClientStockReport() {
                    SidProductId= product.Id,
                    ClientVaultReportId = vaultReport.Id,
                    FileName = entity.Remark,
                    QtyIssued = entity.Quantity,
                    TotalQtyIssued = 0,
                    OpeningStock = vaultReport.ClosingStock,
                    CurrentStock = 0,
                    ClosingStock = 0,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };
                context.ClientStockReports.Add(currentStock);
            }

            var cardIssuance = await context.CardIssuances.SingleOrDefaultAsync(it => it.ClientStockReportId == currentStock.Id);

            if (cardIssuance == null) {
                cardIssuance = new CardIssuance() {
                    ProductId = product.Id,
                    ClientStockReportId = currentStock.Id,
                    Quantity = entity.Quantity
                };
                context.CardIssuances.Add(cardIssuance);
            }

            await context.SaveChangesAsync();

            ////
            if (vaultReport.CurrentStock <= entity.Quantity) return NotFound();

            vaultReport.CurrentStock -= entity.Quantity;
            context.ClientVaultReports.Attach(vaultReport);
            context.Entry(vaultReport).State = EntityState.Modified;

            // StockReport
            //Todo: Update previous closing stock base on the yesterday closing stock
            currentStock.FileName = entity.Remark;
            currentStock.OpeningStock = vaultReport.OpeningStock;
            currentStock.ClosingStock = vaultReport.ClosingStock;
            currentStock.CurrentStock = vaultReport.CurrentStock ;
            currentStock.QtyIssued = entity.Quantity;
            currentStock.TotalQtyIssued += entity.Quantity;
            currentStock.ModifiedOn = DateTime.Now;
            context.ClientStockReports.Attach(currentStock);
            context.Entry(currentStock).State = EntityState.Modified;

            await context.SaveChangesAsync();

            var result = mapper.Map<CardIssuance, CardIssuanceResource>(cardIssuance);
            return Ok(result);

        }

        #endregion


      
        #region CardReceipts
                  
        [HttpGet("cardreceipt")]
        public async Task<IEnumerable<CardReceiptResource>> GetClientCardReceipts()
        {
            var cardReceipts = await context.CardReceipts.ToListAsync();
            return mapper.Map<IEnumerable<CardReceipt>, IEnumerable<CardReceiptResource>>(cardReceipts);
        }

        [HttpPost("cardreceipt/create")]
        public async Task<IActionResult> CreateClientCardReceipt([FromBody] CardReceiptSaveResource entity)
        {

             var product = await context.SidProducts.SingleOrDefaultAsync(v => v.Id == entity.ProductId);
            if (product == null) return NotFound();

            var vaultReport = await context.ClientVaultReports.SingleOrDefaultAsync(v => v.SidProductId == product.Id);

            if (vaultReport == null) {
                vaultReport = new ClientVaultReport(){
                    SidProductId = product.Id,
                    OpeningStock = 0, //entity.Quantity,
                    ClosingStock = 0,
                    CurrentStock = 0,//entity.Quantity,
                    CreateOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                context.ClientVaultReports.Add(vaultReport);
            }

            var cardReceipt = new CardReceipt() {
                SidProductId = product.Id,
                ClientVaultReportId = vaultReport.Id,
                Quantity = entity.Quantity,
                Remark = entity.Remark
            };

            context.CardReceipts.Add(cardReceipt);            
            await context.SaveChangesAsync();

            // Update Vault
            vaultReport.CurrentStock += entity.Quantity;
            vaultReport.OpeningStock += entity.Quantity;
            context.ClientVaultReports.Attach(vaultReport);
            context.Entry(vaultReport).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var result = mapper.Map<CardReceipt, CardReceiptResource>(cardReceipt);

            return Ok(result);
        }



        #endregion

    }
}