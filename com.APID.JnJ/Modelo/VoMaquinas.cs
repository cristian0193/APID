using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoMaquinas
    {
        private int idCodigo;
        private String NombreMaquina;
        private String ReferenciaMaquina;
        private String Planta;


        public VoMaquinas()
        {
            this.idCodigo = 0;
            this.NombreMaquina = "";
            this.ReferenciaMaquina = "";
            this.Planta = "";
        }

        public VoMaquinas(String nombreMaquina, String ReferenciaMaquina, String planta)
        {
            this.NombreMaquina = nombreMaquina.ToUpper();
            this.ReferenciaMaquina = ReferenciaMaquina.ToUpper();
            this.Planta = planta;
        }


        public int IdCodigo
        {
            get { return idCodigo; }
            set { idCodigo = value; }
        }

        public String NombreMaquina1
        {
            get { return NombreMaquina; }
            set { NombreMaquina = value; }
        }

        public String ReferenciaMaquina1
        {
            get { return ReferenciaMaquina; }
            set { ReferenciaMaquina = value; }
        }

        public String Planta1
        {
            get { return Planta; }
            set { Planta = value; }
        }

    }
}
