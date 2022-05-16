using CryptoAPI.Modules;
using CryptoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoRepository _cryptorepository;

        public CryptoController(ICryptoRepository cryptorepository)
        {
            _cryptorepository = cryptorepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Crypto>> GetCryptos()
        {
            return await _cryptorepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Crypto>> GetCrypto(int id)
        {
            return await _cryptorepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Crypto>> PostCrypto([FromBody]Crypto crypto)
        {
            var newCrypto = await _cryptorepository.Create(crypto);
            return CreatedAtAction(nameof(GetCrypto), new { id = newCrypto.Id }, newCrypto);
        }
        [HttpPut]
        public async Task<ActionResult<Crypto>> PutCrypto([FromBody]int id, Crypto crypto)
        {
            if(id != crypto.Id)
            {
                return BadRequest();
            }
            await _cryptorepository.Update(crypto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCrypto([FromBody]int id)
        {
            var bookToDelete = await _cryptorepository.Get(id);
            if (bookToDelete == null)
                return NotFound();

            await _cryptorepository.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}
