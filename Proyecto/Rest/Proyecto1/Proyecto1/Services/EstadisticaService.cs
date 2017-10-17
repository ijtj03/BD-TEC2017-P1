using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class EstadisticaService
    {
        public List<ProductosVentas> GetAllProductosVendidos()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("select Medicamento.Nombre,sum(PedidoxMedicamento.Cantidad) as 'Cantidad' from PedidoxMedicamento left join Medicamento on Medicamento.IdMedicamento=PedidoxMedicamento.IdMedicamento group by (Medicamento.Nombre) order by sum(PedidoxMedicamento.Cantidad) desc", conn);
            read = command.ExecuteReader();

            List<ProductosVentas> ListProductos = new List<ProductosVentas>();
            while (read.Read())
            {
                ProductosVentas pro = new ProductosVentas();
                pro.Nombre = read["Nombre"].ToString();
                pro.Cantidad = Convert.ToInt32(read["Cantidad"]);

                ListProductos.Add(pro);

            }

            command.ExecuteNonQuery();
            conn.Close();
            return ListProductos;

        }

        public List<ProductosVentas> GetAllProductosVendidosxCompania(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("select Medicamento.Nombre,sum(PedidoxMedicamento.Cantidad) as 'Cantidad'   from PedidoxMedicamento left join Medicamento on Medicamento.IdMedicamento=PedidoxMedicamento.IdMedicamento left join Pedido on Pedido.IdPedido=PedidoxMedicamento.IdPedido left join Sucursal on Pedido.IdSucursal=Sucursal.IdSucursal left  join Empresa on Empresa.IdEmpresa=Sucursal.IdEmpresa where Empresa.IdEmpresa="+id.ToString()+" group by (Medicamento.Nombre) order by sum(PedidoxMedicamento.Cantidad) desc", conn);
            read = command.ExecuteReader();

            List<ProductosVentas> ListProductos = new List<ProductosVentas>();
            while (read.Read())
            {
                ProductosVentas pro = new ProductosVentas();
                pro.Nombre = read["Nombre"].ToString();
                pro.Cantidad = Convert.ToInt32(read["Cantidad"]);

                ListProductos.Add(pro);

            }

            command.ExecuteNonQuery();
            conn.Close();
            return ListProductos;

        }

        public List<ProductoxVenta> GetAllEmpresasxVentas()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("select Empresa.Nombre,count(*) as 'Ventas'   from Pedido left join Sucursal on Sucursal.IdSucursal=Pedido.IdSucursal left join Empresa on Sucursal.IdEmpresa = Empresa.IdEmpresa group by (Empresa.Nombre) order by count(*) desc", conn);
            read = command.ExecuteReader();

            List<ProductoxVenta> ListProductos = new List<ProductoxVenta>();
            while (read.Read())
            {
                ProductoxVenta pro = new ProductoxVenta();
                pro.Nombre = read["Nombre"].ToString();
                pro.Venta = Convert.ToInt32(read["Ventas"]);

                ListProductos.Add(pro);

            }

            command.ExecuteNonQuery();
            conn.Close();
            return ListProductos;

        }
    }
}