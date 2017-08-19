using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using capaDeDatos;
namespace capaControlador
{
    public class NCliente
    {
        //metodos para comunicarnos con la capa datos

        //Método Insertar que llama al método Insertar de la clase DCliente
        //de la 
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;         
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Insertar de la clase DProveedor
        //de la capaDatos
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Insertar de la clase DProveedor
        //de la capaDatos
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama almétodo Insertar de la clase DProveedor
        //de la capaDatos
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Método BuscarRazon_Social que llama al método Insertar de la clase DProveedor
        //de la capaDatos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        //Método BuscarNum_Documento que llama al método Insertar de la clase DProveedor
        //de la capaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
