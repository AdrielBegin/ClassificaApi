using ClassificaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ClassificaApi.Repositories
{
    public class UsuariosRepostitory : IUsuariosRepostitory
    {
        private readonly ClassificaContext _context;

        public UsuariosRepostitory(ClassificaContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> Create(Usuarios usuarios)
        {
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();
            return usuarios;
        }
        public async Task<IEnumerable<Usuarios>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuarios> Get(int Id, string Senha)
        {
            return await _context.Usuarios.FindAsync(Id);
        }

    }
}
