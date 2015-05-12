using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoPlanta
    {
        private int idCodigo;
        private String Nombre_Planta;
        private String Referencia_Planta;
        private DateTime Fecha_Creacion;

         public VoPlanta()
        {
            this.idCodigo = 0;
            this.Nombre_Planta = "";
            this.Referencia_Planta = "";
            this.Fecha_Creacion = DateTime.Now;
        }

         public VoPlanta(String nombreTipo, String Indicativo)
        {
            this.Nombre_Planta = nombreTipo.ToUpper();
            this.Referencia_Planta = Indicativo.ToUpper();
            this.Fecha_Creacion = DateTime.Now;
        }

         public int IdCodigo
         {
             get { return idCodigo; }
             set { idCodigo = value; }
         }

        public String NombrePlanta1
        {
            get { return Nombre_Planta; }
            set { Nombre_Planta = value; }
        }

        public String ReferenciaPlanta1
        {
            get { return Referencia_Planta; }
            set { Referencia_Planta = value; }
        }

        public DateTime Fecha_Creacion1
        {
            get { return Fecha_Creacion; }
            set { Fecha_Creacion = value; }
        }

    }
}
