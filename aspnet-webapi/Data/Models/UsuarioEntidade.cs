using System;

namespace aspnet_webapi.Data.Models
{
    public class UsuarioEntidade
    {
        private static int totalUsuarios {get; set;}
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public int Idade { get => this.CalcularIdade(this.DataNascimento); }
        public DateTime DataNascimento { get; private set; }

        public UsuarioEntidade(string nome, string email, DateTime? dataNascimento)
            : this(0, nome, email, dataNascimento)
        {
            
        }

        public UsuarioEntidade(int id, string nome, string email, DateTime? dataNascimento)
        {
            if (dataNascimento == null || dataNascimento > DateTime.Now)
                throw new ArgumentException($"O argumento {nameof(dataNascimento)} possui um valor inválido.");
            
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento.GetValueOrDefault();

            if (id == 0){
                totalUsuarios++;
                Id = totalUsuarios;
            }
            else
            {
                Id = id;
            }
        }

        private int CalcularIdade(DateTime dataNascimento){
            int idade = DateTime.Now.Year - dataNascimento.Year;

            if(DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
                idade--;

            return idade;
        }
    }
}