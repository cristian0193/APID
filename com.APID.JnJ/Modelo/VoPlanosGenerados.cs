using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoPlanosGenerados
    {
        private int idCodigoCodigo;
        private String CodigoGenerado;
        private String Consecutivo;
        private String Revision;
        private String Descripcion;
        private String RazonCreacion;
        private DateTime FechaCreacion;
        private String RutaPlano;
        private String Usuario;
        private String Estado;
        private String Elaborador;
        private String UltimaFechaActualizacion;
       
        public VoPlanosGenerados()
        {
            this.idCodigoCodigo = 0;
            this.CodigoGenerado = "";
            this.Consecutivo = "";
            this.Revision = "";
            this.Descripcion = "";
            this.RazonCreacion = "";
            this.FechaCreacion = DateTime.Now;
            this.RutaPlano = "";
            this.Usuario = "";
            this.Estado = "";
            this.Elaborador = "";
            this.UltimaFechaActualizacion = "";
        }

        public VoPlanosGenerados(String codigogenerado, String consecutivo, String Revision, String Descripcion, String Razoncreacion, String Ruta, String usuario, String estado, String elaborador)
        {
            this.CodigoGenerado = codigogenerado.ToUpper();
            this.Consecutivo = consecutivo.ToUpper();
            this.Revision = Revision.ToUpper();
            this.Descripcion = Descripcion.ToUpper();
            this.RazonCreacion = Razoncreacion;
            this.FechaCreacion = DateTime.Now;
            this.RutaPlano = Ruta;
            this.Usuario = usuario;
            this.Estado = estado;
            this.Elaborador = elaborador;
        }

        public int idCodigoCodigo1
        {
            get { return idCodigoCodigo; }
            set { idCodigoCodigo = value; }
        }

        public String CodigoGenerado1
        {
            get { return CodigoGenerado; }
            set { CodigoGenerado = value; }
        }

        public String Consecutivo1
        {
            get { return Consecutivo; }
            set { Consecutivo = value; }
        }

        public String Revision1
        {
            get { return Revision; }
            set { Revision = value; }
        }

        public String Descripcion1
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public String RazonCreacion1
        {
            get { return RazonCreacion; }
            set { RazonCreacion = value; }
        }

        public DateTime FechaCreacion1
        {
            get { return FechaCreacion; }
            set { FechaCreacion = value; }
        }

        public String RutaPlano1
        {
            get { return RutaPlano; }
            set { RutaPlano = value; }
        }

        public String Usuario1
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        public String Elaborador1
        {
            get { return Elaborador; }
            set { Elaborador = value; }
        }

        public String Estado1
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public String UltimaFechaActualizacion1
        {
            get { return UltimaFechaActualizacion; }
            set { UltimaFechaActualizacion = value; }
        }

    }
}
