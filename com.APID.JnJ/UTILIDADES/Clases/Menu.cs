using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.WebControls;


    public class Menu_Principal
    {
        #region Atributos

        private string nameMenu = "";
        private List<SubMenus> subMenus = new List<SubMenus>();
        private Menu menu;

        #endregion

        #region Constructor

        public Menu_Principal(string nm,Menu mn)
        {
            this.nameMenu = nm;
            this.menu = mn;
        }

        #endregion

        #region Metodos

        public void SetSubMenus(SubMenus sMenu)
        {
            this.subMenus.Add(sMenu);
        }

        public void CargarMenuPrincipal()
        {
            foreach (SubMenus subMenu in this.subMenus)
            {
                MenuItem padre;
                if(subMenu.GetUrl() == null)
                    padre = new MenuItem(subMenu.GetPadre(), subMenu.GetValue().ToString(),null,"");
                else
                    padre = new MenuItem(subMenu.GetPadre(), subMenu.GetValue().ToString(),null, subMenu.GetUrl());
                this.menu.Items.Add(padre);
                for (int i = 0; i < subMenu.GetHijos().Count; i++)
                {
                    MenuItem hijo = new MenuItem(subMenu.GetHijos()[i].GetNameOpcion(), subMenu.GetHijos()[i].GetValue().ToString(),null, subMenu.GetHijos()[i].GetUrlOpcion());
                    padre.ChildItems.Add(hijo);
                }
            }
        }

        #endregion
    }
