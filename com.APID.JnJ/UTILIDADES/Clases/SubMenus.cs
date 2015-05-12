using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class SubMenus
    {
        #region Atributos

        private string padre = "";
        private List<OpcionesSubMenu> hijos = new List<OpcionesSubMenu>();
        private int value = 0;
        private string url = "";
        private string image = "";

        #endregion

        #region Constructor

        public SubMenus(string np,int val,string image)
        {
            this.image = image;
            this.padre = np;
            this.value = val;
            this.url = "";
        }

        #endregion

        #region Metodos

        public SubMenus(string np,string u, int val,string image)
        {
            this.image = image;
            this.padre = np;
            this.value = val;
            this.url = u;
        }

        public void SetHijos(OpcionesSubMenu opc_sub_mn )
        {
            this.hijos.Add(opc_sub_mn);
        }

        public List<OpcionesSubMenu> GetHijos()
        {
            return this.hijos;
        }

        public string GetPadre()
        {
            return this.padre;
        }

        public string GetUrl()
        {
            return this.url;
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
