using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace capaDeDatos
{
   public class DPresentacion
    {
        //Atributos de presentacion
        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _Textobuscar;
        //Atributos encapsulados
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _Textobuscar; set => _Textobuscar = value; }

        //constructor vacio
        public DPresentacion() { }

        //constructor con argumentos
        public DPresentacion(int idpresentacion, string nombre, string descripcion, string textobuscar)
        {
            this.Idpresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Insertar dentro de la tabla presentacion
        public string Insertar(DPresentacion Presentacion)
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
                SqlCommand.CommandText = "spinsertar_presentacion";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Direction = ParameterDirection.Output;
                SqlCommand.Parameters.Add(ParIdPresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCommand.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando para insertar
                respuesta = SqlCommand.ExecuteNonQuery() == 1 ? "Se ingreso correctamente" : "No se ingreso el registro";

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
        public string Editar(DPresentacion Presentacion)
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
                SqlCommand.CommandText = "speditar_categoria";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCommand.Parameters.Add(ParIdPresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCommand.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando para insertar
                respuesta = SqlCommand.ExecuteNonQuery() == 1 ? "Se ingreso correctamente" : "No se editó el registro";

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
        public string Eliminar(DPresentacion Presentacion)
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
                SqlCommand.CommandText = "speliminar_presentacion";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCommand.Parameters.Add(ParIdPresentacion);

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
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spmostrar_presentacion";
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
        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spbuscar_presentacion_nombre";
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Presentacion.TextoBuscar;
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
