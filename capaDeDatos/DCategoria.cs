using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDeDatos
{
   public class DCategoria
    {
        //Atributos de categorias
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        //Atributo para buscar un categoria
        private string _TextoBuscar;
        //Atributos de categoria, tipo MVC
        public int Idcategoria{get => _Idcategoria;set => _Idcategoria = value;}
        public string Nombre{get => _Nombre;set => _Nombre = value;}
        public string Descripcion{get => _Descripcion;set => _Descripcion = value;}
        public string TextoBuscar{get => _TextoBuscar;set => _TextoBuscar = value;}
        
        //constructor vacio
        public DCategoria()
        {

        }
        //constructor con datos
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;

        }

        //metodo de insertar categoria
        public string Insertar(DCategoria Categoria)
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
                SqlCommand.CommandText = "spinsertar_categoria";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                 //comando para insertar id categoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Direction = ParameterDirection.Output;
                SqlCommand.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;                
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
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
        public string Editar(DCategoria Categoria)
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
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.Idcategoria;
                SqlCommand.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;                
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
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
        public string Eliminar(DCategoria Categoria)
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
                SqlCommand.CommandText = "speliminar_categoria";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.Idcategoria;
                SqlCommand.Parameters.Add(ParIdCategoria);
               
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
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spmostrar_categoria";
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
        public DataTable Buscar(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spbuscar_categoria";
                SqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
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
