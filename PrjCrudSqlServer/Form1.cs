using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Lo necesitamos para poder conectarnos a la base de datos.
using System.Data.SqlClient;

namespace PrjCrudSqlServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*ClsTipoProducto producto = new ClsTipoProducto();
            producto.intIdTipoProducto = 1;
            producto.strTipo = "Frutas";
            producto.intIdTipoProducto = 2;
            producto.strTipo = "Verduras";

            //Forma de cargar el combobox 
             1.- Podemos llamar a la clase ClsTipo Producto y con set llamamos el valor que le ingresamos.
             2.- Desde codigo puedo insertar en el objeto combobox
             3.- DEsde el formulario
             4 .-Hacerlo directamente hacia tabla
             5.- Con un Entity Framework
             */
            // Codigo de Coneccion lo vimos hace dos semanas. 
            try { 
            SqlConnection conn = new SqlConnection(@"Data Source =AIEPTEACH07\SQLEXPRESS;Initial Catalog=PROG8001; User ID=sa ; password =F.6a1p3c4");
            //Voy a acceder al mi Combobox
            //Siempre limpiar las variables.
            cmbTipo.Items.Clear();
            //Abrimos la conecci{on a la base de datos.
            conn.Open();
            //Hacemos nuestra consulta hacia la base de datos.
            //Siempre llamen los campos necesarios, SELECT * FROM es una muy mala practica, lo que lleva un consumo exagerado de memoria RAM
            SqlCommand cmd = new SqlCommand("SELECT id, nombre FROM tblTipo", conn);
            //Ejecutamos el comando con el codigo SQL para que se guarde en un objeto data Reader
            SqlDataReader dr = cmd.ExecuteReader();
            //validamos si el data Reader tiene datos. Siempre realizar esta validacion.
            if (dr.HasRows){
                //Recorremos el data Reader 
                while (dr.Read())
                {
                    //Aca vamos agregar datos a nuestro combobox
                    cmbTipo.Items.Add(dr["nombre"].ToString());
                }
            }
            //Cerramos la coneccion
            conn.Close();
            //Aregamos un elemento a seleccionar
            cmbTipo.Items.Insert(0,"--- Seleccione un Item ---");
            //Dejemos nuestro indice como el primer dato a visualizar.
            cmbTipo.SelectedIndex = 0;

            //Vamos a llenar el DataGridView
  
            conn.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM tblProductos", conn);
            SqlDataAdapter da = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataViewProductos.DataSource = dt;
            dataViewProductos.Update();
            }
            catch (SqlException ex) {
                MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source =AIEPTEACH07\SQLEXPRESS;Initial Catalog=PROG8001; User ID=sa ; password =F.6a1p3c4");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tblProductos VALUES(@nombre, @tipo, @descripcion, @marca,@precio, @stock);", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@tipo", cmbTipo.SelectedIndex);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("@precio", int.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos Insertados Correctamente");
                conn.Close();
                txtNombre.Clear();
                cmbTipo.SelectedIndex = 0;
                txtDescripcion.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
            }
            catch (SqlException ex) {
                MessageBox.Show("Error: ",ex.Message,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source =AIEPTEACH07\SQLEXPRESS;Initial Catalog=PROG8001; User ID=sa ; password=F.6a1p3c4");
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tblProductos SET nombre = @nombre , tipo = @tipo, descripcion = @descripcion , marca = @marca , precio = @precio, stock = @stock WHERE id = @id);", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@tipo", cmbTipo.SelectedIndex);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("@precio", int.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos Actualizados Correctamente");
                conn.Close();
                txtNombre.Clear();
                cmbTipo.SelectedIndex = 0;
                txtDescripcion.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source =AIEPTEACH07\SQLEXPRESS;Initial Catalog=PROG8001; User ID=sa ; password =F.6a1p3c4");
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tblProductos WHERE id = @id);", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                MessageBox.Show("Datos Eliminados Correctamente");
                conn.Close();
                txtNombre.Clear();
                cmbTipo.SelectedIndex = 0;
                txtDescripcion.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
