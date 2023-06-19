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
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreController(IStoreRepository storeRepository,IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [HttpGet("GetStore")]
        public IActionResult GetStore(int id) {
            return Ok(_storeRepository.GetStore(id));
        }

        [HttpPost("Createstore")]
        public async Task<ActionResult> CreateStore(StoreDTO storeDTO)
        {
            DefStore store = _mapper.Map<DefStore>(storeDTO);
            await _storeRepository.Createstore(store);
            return CreatedAtAction("GetStore",new {id = store.StoreID},store);
        }

        [HttpGet("GetStores")]
        public async Task<ActionResult<List<DefStore>>> GetStores()
        {
            List<DefStore> stores = await _storeRepository.GetAllStores();
            return Ok(_mapper.Map<List<StoreDTO>>(stores));
        }

    }
}
