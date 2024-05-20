using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prog3_ejercicio_bdd_en_asp_net.Pages
{
    public partial class AltaBajaLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refrescarLista();
        }

        protected void gvLibrosAltaYBaja_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idLibroEliminar = string.Empty;
            string connectionString = "Data Source=LAPTOP-ATPC1STH\\SQLEXPRESS;Initial Catalog=PROG3Biblioteca;Integrated Security=true";
            string query = $"delete from libro where libro.id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    idLibroEliminar = gvLibrosAltaYBaja.Rows[e.RowIndex].Cells[1].Text;
                    cmd.Parameters.AddWithValue("@id", idLibroEliminar);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    refrescarLista();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        protected void refrescarLista()
        {
            string connectionString = "Data Source=LAPTOP-ATPC1STH\\SQLEXPRESS;Initial Catalog=PROG3Biblioteca;Integrated Security=true";
            string query = $"select libro.id as ID, libro.titulo as Titulo, libro.descripcion as Descripcion, libro.ano as Año, autor.id as 'ID del Autor' from libro, autor where autor.id = libro.idAutor";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    gvLibrosAltaYBaja.DataSource = null;
                    gvLibrosAltaYBaja.DataBind();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    gvLibrosAltaYBaja.DataSource = reader;
                    gvLibrosAltaYBaja.DataBind();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnAnadir_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-ATPC1STH\\SQLEXPRESS;Initial Catalog=PROG3Biblioteca;Integrated Security=true";
            string query = "insert into libro (titulo, idAutor, descripcion, ano) values (@param1, @param2, @param3, @param4)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@param1", txtTitulo.Text);
                    cmd.Parameters.AddWithValue("@param2", Int32.Parse(txtIDAutor.Text));
                    cmd.Parameters.AddWithValue("@param3", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@param4", Int32.Parse(txtAno.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    txtAno.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtIDAutor.Text = string.Empty;
                    txtTitulo.Text = string.Empty;
                    refrescarLista();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}