using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoCargos
    {
        private int idCodigo;
        private String NombreCargos;
        private DateTime Fecha_Creacion;

         public VoCargos()
        {
            this.idCodigo = 0;
            this.NombreCargos = "";
            this.Fecha_Creacion = DateTime.Now;
        }

         public VoCargos(String nombreCargos)
        {
            this.NombreCargos = nombreCargos.ToUpper();
            this.Fecha_Creacion = DateTime.Now;
        }

         public int IdCodigo
         {
             get { return idCodigo; }
             set { idCodigo = value; }
         }

        public String NombreCargos1
        {
            get { return NombreCargos; }
            set { NombreCargos = value; }
        }

        public DateTime Fecha_Creacion1
        {
            get { return Fecha_Creacion; }
            set { Fecha_Creacion = value; }
        }

    }
}
