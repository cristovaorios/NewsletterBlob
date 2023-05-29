using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Model
{
    internal class Comentario
    {
        //Atributtes
        private string nomeLeitor;
        private string texto;

        //
        public string NomeLeitor
        {
            get { return nomeLeitor; }
            set { nomeLeitor = value; }
        }

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
    }
}
