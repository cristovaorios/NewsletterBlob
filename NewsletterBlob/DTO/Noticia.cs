using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterBlob.Model
{
    public class Noticia
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
        public int Id { get => id; set => id = value; }
        public int IdAutor { get => idAutor; set => idAutor = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Subtitulo { get => subtitulo; set => subtitulo = value; }
        public string Texto { get => texto; set => texto = value; }
        public byte[] Imagem { get => imagem; set => imagem = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Autores { get => autores; set => autores = value; }
        public DateTime DataPublicacao { get => dataPublicacao; set => dataPublicacao = value; }
        public List<Comentario> Comentarios { get => comentarios; set => comentarios = value; }
        public int QtdCurtidas { get => qtdCurtidas; set => qtdCurtidas = value; }
    }
}
