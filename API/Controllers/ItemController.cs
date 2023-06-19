using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemRepository itemRepository;
        private IMapper _mapper;
        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this._mapper = mapper;
        }

        [HttpPost("CreateItem")]
        public async Task<ActionResult> createItem(ItemDTO itemDTO)
        {
            DefItem item = _mapper.Map<DefItem>(itemDTO);
            //DefItem item = new DefItem()
            //{
            //    ItemSerial = itemDTO.ItemSerial,
            //    ItemEnName = itemDTO.ItemEnName,
            //    ItemArName = itemDTO.ItemArName,
            //    Notes=itemDTO.Notes,
            //    Price=itemDTO.Price,
            //    Vat=itemDTO.Vat
            //};
            return Ok(itemRepository.AddItem(item));

        }
        
        // for grid
        [HttpGet("Items")]
        public async Task<ActionResult> GetItems()
        {
            return Ok(itemRepository.GetItems());
        }

        // for grid
        [HttpPost("CreateInvoiceDetails")]
        public async void CreateInvoice(InvoiceDetailsDTO invoiceDetailsDTO)
        {
            TrxInvoiceDetails invoice = _mapper.Map<TrxInvoiceDetails>(invoiceDetailsDTO);
            itemRepository.CreateInvoice(invoice);
        }

        [HttpPost("CreateInvoiceHead")]
        public async void CreateInvoiceHead(nvoiceHeadDTO nvoiceHeadDTO)
        {
            TrxInvoiceHead invoice = _mapper.Map<TrxInvoiceHead>(nvoiceHeadDTO);
            itemRepository.AddInvoiceHead(invoice);
        }


    }
}
