using CryptoAPI.Modules;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoAPI.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly CryptoContext _context;

        public CryptoRepository(CryptoContext context)
        {
            _context = context;
        }

        public async Task<Crypto> Create(Crypto crypto)
        {
            _context.Coins.Add(crypto);
            await _context.SaveChangesAsync();
            return crypto;
        }

        public async Task Delete(int id)
        {
            var cryptoToDelete = await _context.Coins.FindAsync(id);
            _context.Coins.Remove(cryptoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Crypto>> Get()
        {
            return await _context.Coins.ToListAsync();
        }

        public async Task<Crypto> Get(int id)
        {
            return await _context.Coins.FindAsync(id);
        }

        public async Task Update(Crypto crypto)
        {
             _context.Entry(crypto).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
    }
}
