using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace capaDeDatos
{
    public class DArticulo
    {
        
        public int Idarticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public int Idcategoria { get; set; }
        public int Idpresentacion { get; set; }
        public string TextoBuscar { get; set; }  
        
        public DArticulo() { }

        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;

        }


        //Insertar dentro de la tabla presentacion
        public string Insertar(DArticulo Articulo)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                //Codigo para insertar categorias
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlConnection.Open();
                //Establecer comando
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spinsertar_articulo";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Direction = ParameterDirection.Output;
                SqlCommand.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCommand.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCommand.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;                
                ParImagen.Value = Articulo.Imagen;
                SqlCommand.Parameters.Add(ParImagen);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;                
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCommand.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.VarChar;
                ParIdPresentacion.Value = Articulo.Idpresentacion;
                SqlCommand.Parameters.Add(ParIdPresentacion);

                //Ejecutamos nuestro comando para insertar
                respuesta = SqlCommand.ExecuteNonQuery() == 1 ? "Se ingreso correctamente" : "No se ingreso el Articulo";

            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open) SqlConnection.Close();
            }
            return respuesta;
        }
        //Metodo Editar categoria
        public string Editar(DArticulo Articulo)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                //Codigo para editar categorias
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlConnection.Open();
                //Establecer comando
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "speditar_articulo";
                SqlCommand.CommandType = CommandType.StoredProcedure;

                //comando para insertar id categoria
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Articulo.Idarticulo;
                SqlCommand.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCommand.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCommand.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCommand.Parameters.Add(ParImagen);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCommand.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.VarChar;
                ParIdPresentacion.Value = Articulo.Idpresentacion;
                SqlCommand.Parameters.Add(ParIdPresentacion);
                //Ejecutamos nuestro comando para insertar
                respuesta = SqlCommand.ExecuteNonQuery() == 1 ? "Se ingreso correctamente" : "No se editó el articulo";

            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open) SqlConnection.Close();
            }
            return respuesta;
        }

        //metodo eliminar categoria
        public string Eliminar(DArticulo Articulo)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                //Codigo para editar categorias
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlConnection.Open();
                //Establecer comando
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "speliminar_articulo";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idpresentacion";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Articulo.Idarticulo;
                SqlCommand.Parameters.Add(ParIdArticulo);

                //Ejecutamos nuestro comando para insertar
                respuesta = SqlCommand.ExecuteNonQuery() == 1 ? "Se ingreso correctamente" : "No se eliminó el registro";

            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open) SqlConnection.Close();
            }
            return respuesta;
        }

        //Mostrar categorias
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spmostrar_articulo";
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(DtResultado);

            }
            catch (Exception ex)
            {

                DtResultado = null;
            }
            return DtResultado;


        }

        //Metodo buscar Categoria por nombre
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spbuscar_articulo_nombre";
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
                SqlCommand.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(DtResultado);

            }
            catch (Exception ex)
            {

                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
