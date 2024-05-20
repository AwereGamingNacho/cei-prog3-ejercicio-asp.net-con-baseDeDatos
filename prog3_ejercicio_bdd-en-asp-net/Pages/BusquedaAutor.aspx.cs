using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prog3_ejercicio_bdd_en_asp_net.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddwFiltroAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscarAutor_Click(object sender, EventArgs e)
        {
            string selectedDdn = "nombre";
            string query1 = $"select id as ID, nombre as Nombre, apellido as Apellido, fechaNacimiento as 'Fecha de Nacimiento', nacionalidad as Nacionalidad from autor where {selectedDdn} like '%{txtBuscarAutor.Text}%'";

            switch (ddwFiltroAutor.Text)
            {
                case "Nombre":
                    selectedDdn = "nombre";
                    break;
                case "Apellido":
                    selectedDdn = "apellido";
                    break;
                case "Nacionalidad":
                    selectedDdn = "nacionalidad";
                    break;
            }

            string connectionString = "Data Source=LAPTOP-ATPC1STH\\SQLEXPRESS;Initial Catalog=PROG3Biblioteca;Integrated Security=true";
            string query = query1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    gvAutores.DataSource = null;
                    gvAutores.DataBind();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    gvAutores.DataSource = reader;
                    gvAutores.DataBind();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }
    }
}