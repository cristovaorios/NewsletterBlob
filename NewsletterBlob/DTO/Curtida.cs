using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Model
{
    internal class Curtida
    {
        private int idNoticia;
        private int idAutor;
        private bool estaCurtido;

        public Curtida(int idNoticia, int idAutor, bool estaCurtido)
        {
            this.idNoticia = idNoticia;
            this.idAutor = idAutor;
            this.estaCurtido = estaCurtido;
        }

        public int IdNoticia { get => idNoticia; set => idNoticia = value; }
        public int IdAutor { get => idAutor; set => idAutor = value; }
        public bool EstaCurtido { get => estaCurtido; set => estaCurtido = value; }
    }
}
