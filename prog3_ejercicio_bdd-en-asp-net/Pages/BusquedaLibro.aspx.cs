using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prog3_ejercicio_bdd_en_asp_net.Pages
{
    public partial class BusquedaLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            //añadir pagina para buscar autor
            //añadir pagina para dar de alta o baja un libro

            string selectedDdn = "titulo";
            string selectedQuery = string.Empty;
            string query1 = $"select libro.titulo as Titulo, libro.descripcion as Descripcion, libro.ano as Año, autor.nombre as Autor from libro, autor where libro.{selectedDdn} like '%{txtBuscarLibro.Text}%' and autor.id = libro.idAutor";
            string query2 = $"select libro.titulo as Titlo, libro.descripcion as Descripcion, libro.ano as Año, autor.nombre as Autor from libro, autor where autor.nombre like '%{txtBuscarLibro.Text}%' and libro.idAutor = autor.id";

            switch (ddwFiltroLibro.Text)
            {
                case "Titulo":
                    selectedDdn = "titulo";
                    selectedQuery = query1;
                    break;
                case "Año":
                    selectedDdn = "ano";
                    selectedQuery = query1;
                    break;
                case "Autor":
                    selectedDdn = "autor";
                    selectedQuery = query2;
                    break;
            }

            string connectionString = "Data Source=LAPTOP-ATPC1STH\\SQLEXPRESS;Initial Catalog=PROG3Biblioteca;Integrated Security=true";
            string query = selectedQuery;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    gvLibros.DataSource = null;
                    gvLibros.DataBind();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    gvLibros.DataSource = reader;
                    gvLibros.DataBind();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        protected void ddwFiltroLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}