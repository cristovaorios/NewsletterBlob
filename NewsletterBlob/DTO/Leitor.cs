using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Model
{
    public class Leitor
    {
        //Atributtes
        private int id;
        private string nome;
        private string email;
        private string cpf;
        private string endereco;
        private string telefone;
        private string senha;
        private DateTime dataDeNascimento;
        private byte[] imagemPerfil;

        //Construtor
        public Leitor(string nome, string email, DateTime dataDeNascimento, string cpf, string endereco, string telefone, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.dataDeNascimento = dataDeNascimento;
            this.cpf = cpf;
            this.endereco = endereco;
            this.telefone = telefone;
            this.senha = senha;
        }
        public Leitor(string nome, string email, string cpf, string endereco, string telefone, string senha, DateTime dataDeNascimento, byte[] imagemPerfil)
        {
            this.nome = nome;
            this.email = email;
            this.cpf = cpf;
            this.endereco = endereco;
            this.telefone = telefone;
            this.senha = senha;
            this.dataDeNascimento = dataDeNascimento;
            this.imagemPerfil = imagemPerfil;
        }
        public Leitor()
        {
            //Empty
        }

        //Getters and Setters
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Senha { get => senha; set => senha = value; }
        public DateTime DataDeNascimento { get => dataDeNascimento; set => dataDeNascimento = value; }
        public byte[] ImagemPerfil { get => imagemPerfil; set => imagemPerfil = value; }
    }
}
