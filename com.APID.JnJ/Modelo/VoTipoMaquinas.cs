
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class VoTipoMaquinas
    {
        private int idCodigo;
        private String NombreTipoMaquina;
        private String referenciaTipoMaquina;
        private String Maquina;


        public VoTipoMaquinas()
        {
            this.idCodigo = 0;
            this.NombreTipoMaquina = "";
            this.referenciaTipoMaquina = "";
            this.Maquina = "";
        }

        public VoTipoMaquinas(String nombreTipoMaquina, String referenciaTipoMaquina, String maquina)
        {
            this.NombreTipoMaquina = nombreTipoMaquina.ToUpper();
            this.referenciaTipoMaquina = referenciaTipoMaquina.ToUpper();
            this.Maquina = maquina;
        }


        public int IdCodigo
        {
            get { return idCodigo; }
            set { idCodigo = value; }
        }

        public String NombreTipoMaquina1
        {
            get { return NombreTipoMaquina; }
            set { NombreTipoMaquina = value; }
        }

        public String referenciaTipoMaquina1
        {
            get { return referenciaTipoMaquina; }
            set { referenciaTipoMaquina = value; }
        }

        public String Maquina1
        {
            get { return Maquina; }
            set { Maquina = value; }
        }

    }
}
