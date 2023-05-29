using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Model
{
    internal class Autor : Leitor
    {
        //Atributtes
        private string registroProfissional;

        //Construtor
        public Autor(string nome, string email, DateTime dataDeNascimento, string cpf, string endereco, string telefone, string senha)
        {
            Nome = nome;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
            Senha = senha;
        }
        public Autor(string nome, string email, string cpf, string endereco, string telefone, string senha, DateTime dataDeNascimento, byte[] imagemPerfil)
        {
            Nome = nome;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
            Senha = senha;
            ImagemPerfil = imagemPerfil;
        }
        public Autor()
        {
            //Empty
        }

        //Getters and Setters
        public string RegisttroProfissional
        {
            get { return registroProfissional; }
            set { registroProfissional = value; }
        }

        //Methods
        public void publicarNoticia()
        {

        }
    }
}
