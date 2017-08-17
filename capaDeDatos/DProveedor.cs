using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace capaDeDatos
{
   public class DProveedor
    {
        //Variables
        private int _Idproveedor;
        private string _Razon_Social;
        private string _Sector_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;



        //Propiedades
        public int Idproveedor
        {
            get => _Idproveedor;
            set => _Idproveedor = value;
        }
        public string Razon_Social
        {
            get => _Razon_Social;
            set => _Razon_Social = value;
        }
        public string Sector_Comercial
        {
            get => _Sector_Comercial;
            set => _Sector_Comercial = value;
        }
        public string Tipo_Documento
        {
            get => _Tipo_Documento;
            set => _Tipo_Documento = value;
        }
        public string Num_Documento
        {
            get => _Num_Documento;
            set => _Num_Documento = value;
        }
        public string Direccion
        {
            get => _Direccion;
            set => _Direccion = value;
        }
        public string Telefono
        {
            get => _Telefono;
            set => _Telefono = value;
        }
        public string Email
        {
            get => _Email;
            set => _Email = value;
        }
        public string Url
        {
            get => _Url;
            set => _Url = value;
        }
        public string TextoBuscar
        {
            get => _TextoBuscar;
            set => _TextoBuscar = value;
        }
       

        //Constructores
        public DProveedor()
        {

        }

        public DProveedor(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.Razon_Social = razon_social;
            this.Sector_Comercial = sector_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;
        }

        //Métodos

        //metodo de insertar Proveedor
        public string Insertar(DProveedor Proveedor)
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
                SqlCommand.CommandText = "spinsertar_proveedor";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id Proveedor
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                SqlCommand.Parameters.Add(ParIdProveedor);

                SqlParameter ParRazon_Social = new SqlParameter();
                ParRazon_Social.ParameterName = "@razon_social";
                ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                ParRazon_Social.Size = 150;
                ParRazon_Social.Value = Proveedor.Razon_Social;
                SqlCommand.Parameters.Add(ParRazon_Social);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.Sector_Comercial;
                SqlCommand.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Proveedor.Tipo_Documento;
                SqlCommand.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_Documento;
                SqlCommand.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCommand.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCommand.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 11;
                ParEmail.Value = Proveedor.Email;
                SqlCommand.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 11;
                ParUrl.Value = Proveedor.Url;
                SqlCommand.Parameters.Add(ParUrl);

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
        public string Editar(DProveedor Proveedor)
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
                SqlCommand.CommandText = "speditar_proveedor";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.Idproveedor;
                SqlCommand.Parameters.Add(ParIdProveedor);


                SqlParameter ParRazon_Social = new SqlParameter();
                ParRazon_Social.ParameterName = "@razon_social";
                ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                ParRazon_Social.Size = 150;
                ParRazon_Social.Value = Proveedor.Razon_Social;
                SqlCommand.Parameters.Add(ParRazon_Social);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.Sector_Comercial;
                SqlCommand.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Proveedor.Tipo_Documento;
                SqlCommand.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_Documento;
                SqlCommand.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCommand.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCommand.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 11;
                ParEmail.Value = Proveedor.Email;
                SqlCommand.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 11;
                ParUrl.Value = Proveedor.Url;
                SqlCommand.Parameters.Add(ParUrl);

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
        public string Eliminar(DProveedor Proveedor)
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
                SqlCommand.CommandText = "speliminar_proveedor";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                //comando para insertar id categoria
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.Idproveedor;
                SqlCommand.Parameters.Add(ParIdProveedor);

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
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.Connection = SqlConnection;
                SqlCommand.CommandText = "spmostrar_proveedor";
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

        //Método BuscarNombre
        public DataTable BuscarRazon_Social(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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

        public DataTable BuscarNum_Documento(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connection.ApplicationDbContext;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
