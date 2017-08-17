using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaDeDatos;
using System.Data;

namespace capaControlador
{
    public class NArticulo
    {
        //Método Insertar que llama al método Insertar de la clase DPresentacion
        //de la capaDatos
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Insertar de la clase DCategoria
        //de la capaDatos
        public static string Editar(int idarticulo,string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Insertar de la clase DCategoria
        //de la capaDatos
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama almétodo Insertar de la clase DPresentacion
        //de la capaDatos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método Insertar de la clase DArticulo
        //de la capaDatos
        public static DataTable Buscar(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
