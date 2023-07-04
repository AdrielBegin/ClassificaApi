using ClassificaApi.Model;

namespace ClassificaApi.Repositories
{
    public interface IUsuariosRepostitory
    {
        Task<IEnumerable<Usuarios>> Get();
        Task<Usuarios> Get(int Id, string Senha);
        Task<Usuarios> Create(Usuarios usuarios);

    }
}
