using ClassificaApi.Model;

namespace ClassificaApi.Repositories
{
    public interface IClassificadosRepository
    {
        Task<IEnumerable<Classificados>> Get();
        Task<Classificados> Get(int Id);        
        Task<Classificados> Create (Classificados classificados);
        Task Update(Classificados classificados);
        Task Delete(int Id);
        
    }
}
