using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class OpcionesSubMenu
    {
        #region Atributos

        private string nameOpcion = "";
        private string urlOpcion = "";
        private int value = 0;
        private string image = "";

        #endregion

        #region Constructor

        public OpcionesSubMenu(string nopc,string uopc,int val,string image)
        {
            this.nameOpcion = nopc;
            this.urlOpcion = uopc;
            this.value = val;
            this.image = image;
        }

        #endregion

        #region Metodos

        public string GetNameOpcion()
        {
            return this.nameOpcion;
        }

        public string GetUrlOpcion()
        {
            return this.urlOpcion;
        }

        public string GetImage()
        {
            return this.image;
        }

        public int GetValue()
        {
            return this.value;
        }

        #endregion
    }
