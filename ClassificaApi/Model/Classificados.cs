using static System.DateTime;

namespace ClassificaApi.Model
{
    public class Classificados
    {
               
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInserir { get; set; }
        public DateTime? DataHoraAtualizar { get; set; }
        public void inserirData()
        {
            DataHoraInserir = DateTime.Now;
        }
        public void AtualizarData()
        {
            DataHoraAtualizar = DateTime.Now;
        }        
    }
}
