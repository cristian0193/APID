using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoUsuarios
    {
        private int wwid;
        private String Nombres;
        private String Apellidos;
        private String Password;
        private String Celular;
        private String CorreoElectronico;
        private DateTime FechaCreacion;
        private String TituloProfesional;
        private String Observaciones;
        private String Areas;
        private String Cargos;
        private String Roles;
        private String Estado;

       
        public VoUsuarios()
        {
            this.wwid = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Password = "";
            this.Celular = "";
            this.CorreoElectronico = "";
            this.FechaCreacion = DateTime.Now;
            this.TituloProfesional = "";
            this.Observaciones = "";
            this.Areas = "";
            this.Cargos = "";
            this.Roles = "";
            this.Estado = "";
        }

        public VoUsuarios(int codigo, String nombreUsuario, String apellidoUsuario, String passwordUsuario, String celular, String correo, String titulo, String Observacion, String area, String cargo, String rol, String estado)
        {
            this.wwid = codigo;
            this.Nombres = nombreUsuario.ToUpper();
            this.Apellidos = apellidoUsuario.ToUpper();
            this.Password = passwordUsuario.ToUpper();
            this.Celular = celular.ToUpper();
            this.CorreoElectronico = correo;
            this.FechaCreacion = DateTime.Now;
            this.TituloProfesional = titulo;
            this.Observaciones = Observacion;
            this.Areas = area;
            this.Cargos = cargo;
            this.Roles = rol;
            this.Estado = estado;
        }

        public int Wwid
        {
            get { return wwid; }
            set { wwid = value; }
        }

        public String Nombres1
        {
            get { return Nombres; }
            set { Nombres = value; }
        }

        public String Apellidos1
        {
            get { return Apellidos; }
            set { Apellidos = value; }
        }

        public String Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        public String Celular1
        {
            get { return Celular; }
            set { Celular = value; }
        }

        public String CorreoElectronico1
        {
            get { return CorreoElectronico; }
            set { CorreoElectronico = value; }
        }

        public DateTime FechaCreacion1
        {
            get { return FechaCreacion; }
            set { FechaCreacion = value; }
        }

        public String TituloProfesional1
        {
            get { return TituloProfesional; }
            set { TituloProfesional = value; }
        }

        public String Observaciones1
        {
            get { return Observaciones; }
            set { Observaciones = value; }
        }

        public String Areas1
        {
            get { return Areas; }
            set { Areas = value; }
        }

        public String Cargos1
        {
            get { return Cargos; }
            set { Cargos = value; }
        }

        public String Roles1
        {
            get { return Roles; }
            set { Roles = value; }
        }

        public String Estado1
        {
            get { return Estado; }
            set { Estado = value; }
        }

    }
}
