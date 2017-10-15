using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;



namespace Proyecto1.Services
{
    public class MedicamentoxRecetaService
    {
        public void UpdateMedicamentoxReceta([FromBody] PedidoxMedicamento pedidoxMedicamento)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdReceta = new SqlParameter("@IdReceta", System.Data.SqlDbType.Int);
            IdReceta.Value = pedidoxMedicamento.IdPedido;

            SqlParameter IdMedicamento = new SqlParameter("@IdMedicamento", System.Data.SqlDbType.Int);
            IdMedicamento.Value = pedidoxMedicamento.IdMedicamento;

            SqlParameter Cantidad = new SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            Cantidad.Value = pedidoxMedicamento.Cantidad;

            command = new SqlCommand("update MedicamentoxReceta set Cantidad = @Cantidad where IdReceta=@IdReceta and IdMedicamento=@IdMedicamento", conn);
            command.Parameters.Add(IdReceta);
            command.Parameters.Add(IdMedicamento);
            command.Parameters.Add(Cantidad);

            command.ExecuteNonQuery();

            conn.Close();

        }
        /*public List<MedicamentosxPedido> GetMedicamentosxPedido(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select PedidoxMedicamento.IdMedicamento, PedidoxMedicamento.Cantidad, Medicamento.Nombre, MedicamentoxSucursal.PrecioSucursal from ((PedidoxMedicamento inner join Pedido on PedidoxMedicamento.IdPedido=Pedido.IdPedido)left join Medicamento on PedidoxMedicamento.IdMedicamento=Medicamento.IdMedicamento)left join  MedicamentoxSucursal on PedidoxMedicamento.IdMedicamento=MedicamentoxSucursal.IdMedicamento and Pedido.IdSucursal=MedicamentoxSucursal.IdSucursal where PedidoxMedicamento.IdPedido=" + id.ToString(), conn);
            read = command.ExecuteReader();

            List<MedicamentosxPedido> ListPedidosxMedicamento = new List<MedicamentosxPedido>();
            while (read.Read())
            {
                MedicamentosxPedido pedidoxMedicamento = new MedicamentosxPedido();
                pedidoxMedicamento.Cantidad = Convert.ToInt32(read["Cantidad"]);
                pedidoxMedicamento.Nombre = Convert.ToString(read["Nombre"]);
                pedidoxMedicamento.IdMedicamento = Convert.ToString(read["IdMedicamento"]);
                pedidoxMedicamento.Precio = Convert.ToInt32(read["PrecioSucursal"]);
                ListPedidosxMedicamento.Add(pedidoxMedicamento);

            }
            read.Close();
            conn.Close();
            return ListPedidosxMedicamento;
        }*/

        public void PostMedicamentoxReceta([FromBody] PedidoxMedicamento pedidoxMedicamento)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdReceta = new SqlParameter("@IdReceta", System.Data.SqlDbType.Int);
            IdReceta.Value = pedidoxMedicamento.IdPedido;

            SqlParameter IdMedicamento = new SqlParameter("@IdMedicamento", System.Data.SqlDbType.Int);
            IdMedicamento.Value = pedidoxMedicamento.IdMedicamento;

            SqlParameter Cantidad = new SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            Cantidad.Value = pedidoxMedicamento.Cantidad;

            /*SqlParameter RecetaImg = new SqlParameter("@RecetaImg", System.Data.SqlDbType.Image);
            RecetaImg.Value = pedidoxMedicamento.RecetaImg;*/

            command = new SqlCommand("insert into MedicamentoxReceta(IdReceta,IdMedicamento,Cantidad) VALUES (@IdReceta,@IdMedicamento,@Cantidad)", conn);
            command.Parameters.Add(IdReceta);
            command.Parameters.Add(IdMedicamento);
            command.Parameters.Add(Cantidad);
            command.ExecuteNonQuery();

            conn.Close();

        }
        public List<MedicamentosxPedido> GetMedicamentosxReceta(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select  MedicamentoxReceta.Cantidad, Medicamento.Nombre,Medicamento.IdMedicamento  from  MedicamentoxReceta inner join Medicamento on Medicamento.IdMedicamento=MedicamentoxReceta.IdMedicamento where MedicamentoxReceta.IdReceta=" + id.ToString(), conn);
            read = command.ExecuteReader();

            List<MedicamentosxPedido> ListPedidosxMedicamento = new List<MedicamentosxPedido>();
            while (read.Read())
            {
                MedicamentosxPedido pedidoxMedicamento = new MedicamentosxPedido();
                pedidoxMedicamento.Cantidad = Convert.ToInt32(read["Cantidad"]);
                pedidoxMedicamento.IdMedicamento = Convert.ToString(read["IdMedicamento"]);
                pedidoxMedicamento.Nombre = Convert.ToString(read["Nombre"]);
                ListPedidosxMedicamento.Add(pedidoxMedicamento);

            }
            read.Close();
            conn.Close();
            return ListPedidosxMedicamento;
        }

        /*public void UpdatePedidoxMedicamento([FromBody] PedidoxMedicamento pedidoxMedicamento)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdPedido = new SqlParameter("@IdPedido", System.Data.SqlDbType.Int);
            IdPedido.Value = pedidoxMedicamento.IdPedido;

            SqlParameter IdMedicamento = new SqlParameter("@IdMedicamento", System.Data.SqlDbType.Int);
            IdMedicamento.Value = pedidoxMedicamento.IdMedicamento;

            SqlParameter Cantidad = new SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            Cantidad.Value = pedidoxMedicamento.Cantidad;
            
            command = new SqlCommand("update PedidoxMedicamento set Cantidad = @Cantidad where IdPedido=@IdPedido and IdMedicamento=@IdMedicamento", conn);
            command.Parameters.Add(IdPedido);
            command.Parameters.Add(IdMedicamento);
            command.Parameters.Add(Cantidad);

            command.ExecuteNonQuery();

            conn.Close();

        }*/

    }
}