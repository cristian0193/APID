using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoTiposPlano
    {
        private int idCodigo;
        private String Nombre_Tipo;
        private String Referencia_Tipo;
        private DateTime Fecha_Creacion;

         public VoTiposPlano()
        {
            this.idCodigo = 0;
            this.Nombre_Tipo = "";
            this.Referencia_Tipo = "";
            this.Fecha_Creacion = DateTime.Now;
        }

         public VoTiposPlano(String nombreTipo, String Indicativo)
        {
            this.Nombre_Tipo = nombreTipo.ToUpper();
            this.Referencia_Tipo = Indicativo.ToUpper();
            this.Fecha_Creacion = DateTime.Now;
        }

         public int IdCodigo
         {
             get { return idCodigo; }
             set { idCodigo = value; }
         }

        public String NombreTipo1
        {
            get { return Nombre_Tipo; }
            set { Nombre_Tipo = value; }
        }

        public String Referencia1
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
