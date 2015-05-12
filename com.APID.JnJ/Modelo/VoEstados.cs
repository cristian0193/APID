using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoEstados
    {
        private int idCodigo;
        private String NombreEstado;
        private String Referencia_Estado;
        private String Referencia_Tipo;
        private DateTime Fecha_Creacion;

         public VoEstados()
        {
            this.idCodigo = 0;
            this.NombreEstado = "";
            this.Referencia_Estado = "";
            this.Referencia_Tipo = "";
            this.Fecha_Creacion = DateTime.Now;
        }

         public VoEstados(String nombreEstado, String Referencia_Estado, String Referencia_Tipo)
        {
            this.NombreEstado = nombreEstado.ToUpper();
            this.Referencia_Estado = Referencia_Estado.ToUpper();
            this.Fecha_Creacion = DateTime.Now;
        }

         public int IdCodigo
         {
             get { return idCodigo; }
             set { idCodigo = value; }
         }

        public String NombreEstado1
        {
            get { return NombreEstado; }
            set { NombreEstado = value; }
        }

        public String NombreReferencia_Estado1
        {
            get { return Referencia_Estado; }
            set { Referencia_Estado = value; }
        }

        public String NombreReferencia_Tipo1
        {
            get { return Referencia_Tipo; }
            set { Referencia_Tipo = value; }
        }

        public DateTime Fecha_Creacion1
        {
            get { return Fecha_Creacion; }
            set { Fecha_Creacion = value; }
        }


    }
}
