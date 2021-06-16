namespace aspnet_webapi.Models
{
    public class Usuario
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public int Idade { get; private set; }

        public Usuario(string nome, string email, int idade)
        {
            Nome = nome;
            Email = email;
            Idade = idade;
        }
    }
}