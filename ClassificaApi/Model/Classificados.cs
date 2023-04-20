using static System.DateTime;

namespace ClassificaApi.Model
{
    public class Classificados
    {
        public Classificados()
        {
            DataHora = DateTime.Now;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get;}

    }
}
