using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoAreas
    {
        private int idCodigo;
        private String NombreAreas;
        private DateTime Fecha_Creacion;

         public VoAreas()
        {
            this.idCodigo = 0;
            this.NombreAreas = "";
            this.Fecha_Creacion = DateTime.Now;
        }

         public VoAreas(String nombreAreas)
        {
            this.NombreAreas = nombreAreas.ToUpper();
            this.Fecha_Creacion = DateTime.Now;
        }

         public int IdCodigo
         {
             get { return idCodigo; }
             set { idCodigo = value; }
         }

        public String NombreAreas1
        {
            get { return NombreAreas; }
            set { NombreAreas = value; }
        }

        public DateTime Fecha_Creacion1
        {
            get { return Fecha_Creacion; }
            set { Fecha_Creacion = value; }
        }

    }
}
