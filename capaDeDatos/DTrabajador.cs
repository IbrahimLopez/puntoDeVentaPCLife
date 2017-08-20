using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace capaDeDatos
{
    class DTrabajador
    {
        //propiedades de la clase DTrabajador
        public int Idtrabajador { get; set; }
        public string nombre { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Num_Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Acceso { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string TextoBuscar { get; set; }


        public DTrabajador() { }

        public DTrabajador(int idtrabajador, string nombre, string apellidos,
            string sexo, DateTime fecha_nacimiento, string num_documento, string direccion,
            string telefono, string email, string acceso, string usuario, string password,
            string textobuscar)
        {
            this.Idtrabajador = idtrabajador;
            this.nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;
           
        }

        //metodos del trabajador     
        public string Insertar(DTrabajador trabajador)
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
                SqlCommand.CommandText = "spinsertar_trabajador";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id Proveedor
                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Direction = ParameterDirection.Output;
                SqlCommand.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 150;
                ParNombre.Value = trabajador.nombre;
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = trabajador.Apellidos;
                SqlCommand.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 20;
                ParSexo.Value = trabajador.Sexo;
                SqlCommand.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.DateTime;
                ParFecha_Nacimiento.Value = trabajador.Fecha_Nacimiento;
                SqlCommand.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 11;
                ParNum_Documento.Value = trabajador.Num_Documento;
                SqlCommand.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = trabajador.Direccion;
                SqlCommand.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = trabajador.Telefono;
                SqlCommand.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 11;
                ParEmail.Value = trabajador.Email;
                SqlCommand.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 11;
                ParAcceso.Value = trabajador.Acceso;
                SqlCommand.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 11;
                ParUsuario.Value = trabajador.Usuario;
                SqlCommand.Parameters.Add(ParUsuario);


                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 11;
                ParPassword.Value = trabajador.Password;
                SqlCommand.Parameters.Add(ParPassword);

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
        public string Editar(DTrabajador trabajador)
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
                SqlCommand.CommandText = "speditar_trabajador";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idtrabajador";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = trabajador.Idtrabajador;
                SqlCommand.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 150;
                ParNombre.Value = trabajador.nombre;
                SqlCommand.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = trabajador.Apellidos;
                SqlCommand.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 20;
                ParSexo.Value = trabajador.Sexo;
                SqlCommand.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.DateTime;
                ParFecha_Nacimiento.Value = trabajador.Fecha_Nacimiento;
                SqlCommand.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 11;
                ParNum_Documento.Value = trabajador.Num_Documento;
                SqlCommand.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = trabajador.Direccion;
                SqlCommand.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = trabajador.Telefono;
                SqlCommand.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 11;
                ParEmail.Value = trabajador.Email;
                SqlCommand.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 11;
                ParAcceso.Value = trabajador.Acceso;
                SqlCommand.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 11;
                ParUsuario.Value = trabajador.Usuario;
                SqlCommand.Parameters.Add(ParUsuario);


                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 11;
                ParPassword.Value = trabajador.Password;
                SqlCommand.Parameters.Add(ParPassword);


                //Ejecutamos nuestro comando para insertar
                respuesta = SqlCommand.ExecuteNonQuery() == 1 ? "Se editó correctamente" : "No se editó el registro";

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
        public string Eliminar(DTrabajador trabajador)
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
                SqlCommand.CommandText = "speliminar_trabajador";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = trabajador.Idtrabajador;
                SqlCommand.Parameters.Add(ParIdTrabajador);

                //Ejecutamos nuestro comando para insertar
                respuesta = SqlCommand.ExecuteNonQuery() == 1 ? "Se eliminó correctamente" : "No se eliminó el registro";

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
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spmostrar_trabajador";
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

        public DataTable BuscarApellidos(DTrabajador trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_apellidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = trabajador.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        
        public DataTable BuscarNum_Documento(DTrabajador trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = trabajador.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
