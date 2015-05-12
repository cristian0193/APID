using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoRoles
    {
        private int idRoles;
        private String NombreRoles;
        private DateTime Fecha_Creacion;

         public VoRoles()
        {
            this.idRoles = 0;
            this.NombreRoles = "";
            this.Fecha_Creacion = DateTime.Now;
        }

         public VoRoles(String nombreRol)
        {
            this.NombreRoles = nombreRol.ToUpper();
            this.Fecha_Creacion = DateTime.Now;
        }

         public int IdRoles
         {
             get { return idRoles; }
             set { idRoles = value; }
         }

        public String NombreRoles1
        {
            get { return NombreRoles; }
            set { NombreRoles = value; }
        }

        public DateTime Fecha_Creacion1
        {
            get { return Fecha_Creacion; }
            set { Fecha_Creacion = value; }
        }

    }
}
