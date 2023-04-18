using ClassificaApi.Model;
using ClassificaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassificaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificadosController : ControllerBase
    {
        private readonly IClassificadosRepository _classificadosRepository;
        public ClassificadosController(IClassificadosRepository classificadosRepository)
        {
            _classificadosRepository = classificadosRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Classificados>> GetClassificados()
        {
            return await _classificadosRepository.Get();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Classificados>> GetClassificados( int Id)
        {
            return await _classificadosRepository.Get(Id);
        }
        [HttpPost]
        public async  Task<ActionResult<Classificados>> PostClassificados([FromBody] Classificados classificados) 
        {
            var newClassificados = await _classificadosRepository.Create(classificados);

            return CreatedAtAction(nameof(GetClassificados),new {id = newClassificados.Id},newClassificados);
        }
        [HttpDelete("{Id}")]
        public async Task<AcceptedResult> Delete(int Id) 
        {
            var classificadosToDelete = await _classificadosRepository.Get(Id);
            if (classificadosToDelete == null)
                await _classificadosRepository.Delete(classificadosToDelete.Id);
            return null;
        }
        [HttpPut]
        public async Task<AcceptedResult> PutClassificados(int Id, [FromBody] Classificados classificados) 
        {
            if (Id == classificados.Id)
                await _classificadosRepository.Update(classificados);
            return null;
        }


    }
}
