using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Model
{
    public class Curtida
    {
        //Atributtes
        private int idNoticia;
        private int idAutor;
        private bool estaCurtido;

        //Constructor
        public Curtida(int idNoticia, int idAutor, bool estaCurtido)
        {
            this.idNoticia = idNoticia;
            this.idAutor = idAutor;
            this.estaCurtido = estaCurtido;
        }

        //Getters and Setters
        public int IdNoticia { get => idNoticia; set => idNoticia = value; }
        public int IdAutor { get => idAutor; set => idAutor = value; }
        public bool EstaCurtido { get => estaCurtido; set => estaCurtido = value; }
    }
}
