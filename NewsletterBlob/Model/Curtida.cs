using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Model
{
    internal class Curtida
    {
        private bool estaCurtido;

        public bool EstaCurtido
        {
            get { return estaCurtido; }
            set { estaCurtido = value; }
        }
    }
}
