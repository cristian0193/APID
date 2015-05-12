using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Globalization;
using UTILIDADES.Clases;
using System.Data;

namespace UTILIDADES
{
    public class Utilidad
    {
        #region "Metodos generales"

        public void Cargar_lista(DropDownList lista, ArrayList elementos)
        {
            lista.Items.Clear();
            ListItem item = new ListItem("Seleccionar", "-1");
            lista.Items.Add(item);
            foreach (string rol in elementos)
            {
                item = new ListItem(rol.Split(',')[0], rol.Split(',')[1]);
                lista.Items.Add(item);
            }
        }

        public string Esconder_password(string password)
        {
            string resultado = "";
            for (int index = 0; index < password.Length; index++)
            {
                resultado += "*";
            }
            return resultado;
        }

        public string Generar_clave()
        {
            int index = 0;
            string clave = "";
            string[] alfabeto = { "ª", "!", "$", "&", "/", "?", "¿", "¡", "*", "+", "ç", "1", "a", "A", "b", "B", "c", "C", "d", "D", "e", "2", "E", "f", "F", "3", "g", "G", "4", "h", "H", "5", "i", "I", "6", "j", "J", "k", "7", "K", "l", "L", "8", "m", "M", "n", "N", "9", "o", "O", "p", "P", "q", "Q", "r", "R", "0", "s", "S", "t", "T", "u", "U", "w", "W", "x", "X", "y", "Y", "z", "Z" };
            Random aleatorio = new Random();
            while (index < 8)
            {
                clave += alfabeto[aleatorio.Next(0, 70)];
                index++;
            }
            return clave;
        }

        public bool Valida_Fecha(string fecha)
        {
            bool diaAct = false;
            string[] ffinal = fecha.Split('/');
            if (ffinal.Length == 3)
            {
                if (ffinal[2].Length == 4)
                {
                    try
                    {
                        int year = int.Parse(ffinal[2]);
                        if (ffinal[0].Length == 2)
                        {
                            try
                            {
                                int mes = int.Parse(ffinal[0].Replace("0", ""));
                                if (mes <= 12)
                                {
                                    if (ffinal[1].Length == 2)
                                    {
                                        try
                                        {
                                            int dia = int.Parse(ffinal[1].Replace("0", ""));
                                            if (dia <= 31)
                                            {
                                                switch (mes)
                                                {
                                                    case 1:
                                                        if (dia <= 31)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 2:
                                                        if (year % 4 == 0)
                                                        {
                                                            if (dia <= 29)
                                                                diaAct = true;
                                                            else
                                                                diaAct = false;
                                                        }
                                                        else
                                                        {
                                                            if (dia <= 28)
                                                                diaAct = true;
                                                            else
                                                                diaAct = false;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (dia <= 31)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 4:
                                                        if (dia <= 30)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 5:
                                                        if (dia <= 31)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 6:
                                                        if (dia <= 30)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 7:
                                                        if (dia <= 31)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 8:
                                                        if (dia <= 31)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 9:
                                                        if (dia <= 30)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 10:
                                                        if (dia <= 31)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 11:
                                                        if (dia <= 30)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                    case 12:
                                                        if (dia <= 31)
                                                            diaAct = true;
                                                        else
                                                            diaAct = false;
                                                        break;
                                                }
                                                if (diaAct)
                                                    return true;
                                                else
                                                    return false;
                                            }
                                            else
                                                return false;
                                        }
                                        catch (Exception) { }
                                    }
                                    else
                                        return false;
                                }
                                else
                                    return false;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    catch (Exception) { return false; }
                }
                else
                    return false;
            }
            else
                return false;
        }

        public string Convert_fecha(string fecha)
        {
            string fresult = "";
            string[] ffinal = fecha.Split('/');
            fresult = string.Format("{0:c}", ffinal[2]) + string.Format("{0:c}", ffinal[1]) + string.Format("{0:c}", ffinal[0]);
            return fresult;
        }

        public int Meses(string mes)
        {
            int numeroMes = 1;
            switch (mes)
            {
                case "Enero":
                    numeroMes = 1;
                    break;
                case "Febrero":
                    numeroMes = 2;
                    break;
                case "Marzo":
                    numeroMes = 3;
                    break;
                case "Abril":
                    numeroMes = 4;
                    break;
                case "Mayo":
                    numeroMes = 5;
                    break;
                case "Junio":
                    numeroMes = 6;
                    break;
                case "Julio":
                    numeroMes = 7;
                    break;
                case "Agosto":
                    numeroMes = 8;
                    break;
                case "Septiembre":
                    numeroMes = 9;
                    break;
                case "Octubre":
                    numeroMes = 10;
                    break;
                case "Noviembre":
                    numeroMes = 11;
                    break;
                case "Diciembre":
                    numeroMes = 12;
                    break;
            }
            return numeroMes;
        }

        public string Meses(int mes)
        {
            string numeroMes = "Enero";
            switch (mes)
            {
                case 1:
                    numeroMes = "Enero";
                    break;
                case 2:
                    numeroMes = "Febrero";
                    break;
                case 3:
                    numeroMes = "Marzo";
                    break;
                case 4:
                    numeroMes = "Abril";
                    break;
                case 5:
                    numeroMes = "Mayo";
                    break;
                case 6:
                    numeroMes = "Junio";
                    break;
                case 7:
                    numeroMes = "Julio";
                    break;
                case 8:
                    numeroMes = "Agosto";
                    break;
                case 9:
                    numeroMes = "Septiembre";
                    break;
                case 10:
                    numeroMes = "Octubre";
                    break;
                case 11:
                    numeroMes = "Noviembre";
                    break;
                case 12:
                    numeroMes = "Diciembre";
                    break;
            }
            return numeroMes;
        }

        #endregion
    }
}