using ClassificaApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading.Tasks;

namespace ClassificaApi.Repositories
{
    public class ClassificadosRepository : IClassificadosRepository
    {
        private readonly ClassificaContext _context;

        public ClassificadosRepository(ClassificaContext context) 
        {
            _context = context;
        }

        public async Task<Classificados> Create(Classificados classificados)
        {
            _context.Classificados.Add(classificados);
            await _context.SaveChangesAsync();
            return classificados;
        }

        public async Task Delete(int Id)
        {
            var classificadoDelete = await _context.Classificados.FindAsync(Id);
            _context.Classificados.Remove(classificadoDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Classificados>> Get()
        {
            return await _context.Classificados.ToListAsync();
        }
        public async Task<Classificados> Get(int Id)
        {
            return await _context.Classificados.FindAsync(Id);
        }

        public async Task Update(Classificados classificados)
        {
            _context.Entry(classificados).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task GetNow(Classificados classificados) 
        {          
          await _context.SaveChangesAsync();
        }


    }
}
