namespace ClassificaApi.Model
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }        
        public virtual ICollection<Classificados> Classificados { get; set; }
    }
}
