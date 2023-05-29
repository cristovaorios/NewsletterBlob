using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    internal class Noticia
    {
        //Atributtes
        private int id;
        private int idAutor;
        private string titulo;
        private string subtitulo;
        private string texto;
        private byte[] imagem;
        private string categoria;
        private string autores;
        private DateTime dataPublicacao;
        private List<Comentario> comentarios;
        private int qtdCurtidas;

        //Constructor
        public Noticia(string titulo, string subtitulo, string texto, byte[] imagem, string categoria, string autores, DateTime dataPublicacao)
        {
            this.titulo = titulo;
            this.subtitulo = subtitulo;
            this.texto = texto;
            this.imagem = imagem;
            this.categoria = categoria;
            this.autores = autores;
            this.dataPublicacao = dataPublicacao;
        }
        public Noticia(int id, int idAutor, string titulo, string subtitulo, string texto, byte[] imagem, string categoria, string autores, DateTime dataPublicacao, int qtdCurtidas)
        {
            this.id = id;
            this.idAutor = idAutor;
            this.titulo = titulo;
            this.subtitulo = subtitulo;
            this.texto = texto;
            this.imagem = imagem;
            this.categoria = categoria;
            this.autores = autores;
            this.dataPublicacao = dataPublicacao;
            this.qtdCurtidas = qtdCurtidas;
        }
        public Noticia( int id, string titulo, string subtitulo, string texto, byte[] imagem, string categoria, string autores, DateTime dataPublicacao)
        {
            this.id = id;
            this.titulo = titulo;
            this.subtitulo = subtitulo;
            this.texto = texto;
            this.imagem = imagem;
            this.categoria = categoria;
            this.autores = autores;
            this.dataPublicacao = dataPublicacao;
        }
        public Noticia(int id, string titulo, string subtitulo, string texto, byte[] imagem, string categoria, string autores, DateTime dataPublicacao, int qtdCurtidas)
        {
            this.id = id;
            this.titulo = titulo;
            this.subtitulo = subtitulo;
            this.texto = texto;
            this.imagem = imagem;
            this.categoria = categoria;
            this.autores = autores;
            this.dataPublicacao = dataPublicacao;
            this.qtdCurtidas = qtdCurtidas;
        }
        public Noticia()
        {
            //Empty
        }

        //Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdAutor
        {
            get { return idAutor; }
            set { idAutor = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string SubTitulo
        {
            get { return subtitulo; }
            set { subtitulo = value; }
        }
        public string Texto
        {
            get { return texto; }
            set { texto =  value; }
        }
        public byte[] Imagem
        {
            get { return imagem; }
            set { imagem = value; }
        }
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public string Autores
        {
            get { return autores; }
            set { autores = value; }
        }
        public DateTime DataPublicacao
        {
            get { return dataPublicacao; }
            set { dataPublicacao = value; }
        }
        public List<Comentario> Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }
        public int QtdCurtidas
        {
            get { return qtdCurtidas; }
            set { qtdCurtidas = value; }
        }

    }
}
