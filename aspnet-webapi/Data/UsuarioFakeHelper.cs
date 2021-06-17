using System;
using System.Collections.Generic;
using System.Linq;
using aspnet_webapi.Data.Models;

namespace aspnet_webapi.Data
{
    public class UsuarioFakeHelper : IUsuarioFakeHelper
    {
        private static DateTime dataMinima = new DateTime(1940, 1, 1);
        private static string[] nomesMasculinos = {"Miguel", "Arthur", "Davi", "Gabriel", "Bento", "Bernardo", "Joseph", "Pedro", "Fabio"};
        private static string[] nomesFemininos = {"Luciana", "Maria", "Silvia", "Stela", "Ana", "Patricia", "Tereza", "Sofia"};
        private static string[] sobrenomes = {"Silva", "Souza", "Camargo", "Baia", "Pereira", "Schmit", "Rodrigues", "Ferreira", "Alves", "Oliveira", "Lima", "Santos"};

        private Random randomizador = new Random();
        private List<string> nomesGerados = new List<string>();

        public IEnumerable<UsuarioEntidade> CriarUsuariosFake(int quantidade)
        {
            List<UsuarioEntidade> usuarios = new List<UsuarioEntidade>();
            
            for (int i = 0; i < quantidade; i++)
                usuarios.Add(CriarUsuarioFake());

            return usuarios.AsEnumerable();
        }

        private UsuarioEntidade CriarUsuarioFake()
        {
            var nomeAleatorio = GerarNomeAleatorio();
            return new UsuarioEntidade(nomeAleatorio, GerarEmail(nomeAleatorio), GerarDataNascimento());
        }
        
        private string GerarNomeAleatorio(){
            var nome = ObterValorPosicaoAleatoria(DateTime.Now.Ticks % 2 == 0 ? nomesMasculinos : nomesFemininos);
            var sobrenome = ObterValorPosicaoAleatoria(sobrenomes);

            var nomeCompleto = $"{nome} {sobrenome}";
            if (nomesGerados.Contains(nomeCompleto))
                return GerarNomeAleatorio();
            
            nomesGerados.Add(nomeCompleto);
            return nomeCompleto;
        }

        private string GerarEmail(string nomeAleatorio)
        {
            var nomeTratado = nomeAleatorio.ToLower().Replace(' ', '.');
            
            return string.Join('@', nomeTratado, "email.com.br");
        }

        private DateTime? GerarDataNascimento()
        {
            var dataInicial = dataMinima;
            int intervalo = (DateTime.Today - dataInicial).Days;           
            return dataInicial.AddDays(randomizador.Next(intervalo));
        }

        private string ObterSobrenomeAleatorio(){
            return ObterValorPosicaoAleatoria(sobrenomes);
        }

        private string ObterValorPosicaoAleatoria(string[] arrayNomes){
            var posicaoAleatoria = randomizador.Next(arrayNomes.Length - 1);
            return arrayNomes[posicaoAleatoria];
        }
    }
}