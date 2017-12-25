using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        webServicePrueba.Service1Client servicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServicePrueba.Service1Client)Application["WebServer"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (StreamReader readFile = new StreamReader("C:\\CSVFile\\tablero.csv"))
                {
                    string line;
                    string[] row;
                    int contador = 0;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            row = line.Split(',');
                            webServicePrueba.Pieza pieza = new webServicePrueba.Pieza();
                            if (row[3].StartsWith("Neosatelite"))
                            {
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 6;
                                pieza.Alcance = 0;
                                pieza.Danio = 2;
                                pieza.Vida = 10;
                                int fila = Convert.ToInt32(row[2]);
                                servicio.insertarenTablero(fila, row[1], 4, pieza);
                                
                            }
                            else if (row[3].StartsWith("Bombardero") )
                            {
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 7;
                                pieza.Alcance = 0;
                                pieza.Danio = 5;
                                pieza.Vida = 10;
                                
                                int fila = Convert.ToInt32(row[2]);
                                servicio.insertarenTablero(fila, row[1], 3, pieza);
                            }
                            else if (row[3].StartsWith("Caza"))
                            {
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 9;
                                pieza.Alcance = 1;
                                pieza.Danio = 2;
                                pieza.Vida = 20;

                                int fila = Convert.ToInt32(row[2]);
                                servicio.insertarenTablero(fila, row[1], 3, pieza);
                            }
                            else if (row[3].StartsWith("Helicóptero de combate"))
                            {
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 9;
                                pieza.Alcance = 1;
                                pieza.Danio = 3;
                                pieza.Vida = 15;
                                
                                int fila = Convert.ToInt32(row[2]);
                                servicio.insertarenTablero(fila, row[1], 3, pieza);
                            }
                            else if (row[3].StartsWith("Fragata"))
                            {
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 5;
                                pieza.Alcance = 6;
                                pieza.Danio = 3;
                                pieza.Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                servicio.insertarenTablero(fila, row[1], 2, pieza);

                            }
                            else if (row[3].StartsWith("Crucero"))
                            {
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 6;
                                pieza.Alcance = 1;
                                pieza.Danio = 3;
                                pieza.Vida = 15;

                                int fila = Convert.ToInt32(row[2]);
                                servicio.insertarenTablero(fila, row[1], 2, pieza);

                            }
                            else if (row[3].StartsWith("Submarino"))
                            {
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 5;
                                pieza.Alcance = 1;
                                pieza.Danio = 2;
                                pieza.Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                servicio.insertarenTablero(fila, row[1], 1, pieza);

                            }
                        }
                        contador++;
                    }

                    Label1.Text = servicio.recorrerCol();
                    Label2.Text = servicio.recorrerFila();
                }

            }
            catch
            {
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }
    }
}