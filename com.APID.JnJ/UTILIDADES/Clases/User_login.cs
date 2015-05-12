using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTILIDADES.Clases
{
    public class User_login
    {
        #region "Atributos"

        private string nombre = "";
        private string apellido = "";
        private string nombreRol = "";
        private string idRol = "";
        private string estado = "";
        private string usuario = "";
        private string idUsuario = "";

        #endregion

        #region "Metodos"

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }

        public string NombreRol
        {
            get
            {
                return nombreRol;
            }
            set
            {
                nombreRol = value;
            }
        }

        public string IdRol
        {
            get
            {
                return idRol;
            }
            set
            {
                idRol = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        public string IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
            }
        }

        #endregion
    }
}
