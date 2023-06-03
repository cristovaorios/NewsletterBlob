﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Model
{
    public class Comentario
    {
        //Atributtes
        private int idComentario;
        private int idNoticia;
        private int idAutor;
        private byte[] imagemAutor;
        private string texto;

        //Constructor

        public Comentario(int idNoticia, int idAutor, byte[] imagemAutor, string texto)
        {
            this.idNoticia = idNoticia;
            this.idAutor = idAutor;
            this.imagemAutor = imagemAutor;
            this.texto = texto;
        }

        public Comentario()
        {
        }

        //Getters and Setters
        public int IdNoticia { get => idNoticia; set => idNoticia = value; }
        public int IdAutor { get => idAutor; set => idAutor = value; }
        public byte[] ImagemAutor { get => imagemAutor; set => imagemAutor = value; }
        public string Texto { get => texto; set => texto = value; }
        public int IdComentario { get => idComentario; set => idComentario = value; }
    }
}
