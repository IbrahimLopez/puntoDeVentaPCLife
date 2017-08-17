using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDeDatos;
using System.Data;

namespace capaControlador
{
    public class NCategoria
    {

        //Método Insertar que llama al método Insertar de la clase DCategoria
        //de la capaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Insertar de la clase DCategoria
        //de la capaDatos
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Insertar de la clase DCategoria
        //de la capaDatos
        public static string Eliminar(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama almétodo Insertar de la clase DCategoria
        //de la capaDatos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        //Método BuscarNombre que llama al método Insertar de la clase DCategoria
        //de la capaDatos
        public static DataTable Buscar(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.Buscar(Obj);
        }
    }
}
