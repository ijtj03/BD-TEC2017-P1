using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;

namespace Proyecto1.Services
{
    public class PedidoService
    {
        public List<Pedido> GetAllPedidos()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Pedido where LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<Pedido> ListPedidos = new List<Pedido>();
            while (read.Read())
            {
                Pedido pedido = new Pedido();
                pedido.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedido.IdCedula = Convert.ToInt32(read["IdCedula"]);
                pedido.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                pedido.Estado = Convert.ToBoolean(read["Estado"]);
                pedido.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListPedidos.Add(pedido);

            }
            read.Close();
            conn.Close();
            return ListPedidos;
        }
        public int GetLastPedidoId()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select max(Pedido.IdPedido) as LastId from Pedido where LogicDelete = 0", conn);
            read = command.ExecuteReader();
            int ans = -1;
            while (read.Read())
            {
                ans = Convert.ToInt32(read["LastId"]);
            }
            read.Close();
            conn.Close();
            return ans;
        }
        public List<PedidosId> GetPedidos(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select Sucursal.Nombre,Sucursal.Provincia,Sucursal.Canton,Sucursal.Distrito,Pedido.IdPedido,Pedido.FechaRecojo from Pedido inner join Sucursal on Pedido.IdSucursal=Sucursal.IdSucursal where Pedido.Estado=0 and Pedido.LogicDelete=0 and Pedido.IdCedula=" + id.ToString(), conn);
            read = command.ExecuteReader();

            List<PedidosId> ListPedidos = new List<PedidosId>();
            while (read.Read())
            {
                PedidosId pedido = new PedidosId();
                pedido.NombreSucursal = Convert.ToString(read["Nombre"]);
                pedido.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedido.Provincia = Convert.ToString(read["Provincia"]);
                pedido.Canton = Convert.ToString(read["Canton"]);
                pedido.Distrito = Convert.ToString(read["Distrito"]);
                pedido.FechaRecojo = Convert.ToString(read["FechaRecojo"]);

                ListPedidos.Add(pedido);

            }
            read.Close();
            conn.Close();
            return ListPedidos;
        }

        public void PostPedido([FromBody] Pedido pedido)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = pedido.IdCedula;

            SqlParameter IdSucursal = new SqlParameter("@IdSucursal", System.Data.SqlDbType.Int);
            IdSucursal.Value = pedido.IdSucursal;

            SqlParameter Estado = new SqlParameter("@Estado", System.Data.SqlDbType.Bit);
            Estado.Value = pedido.Estado;

            SqlParameter FechaRecojo = new SqlParameter("@FechaRecojo", System.Data.SqlDbType.VarChar);
            FechaRecojo.Value = pedido.FechaRecojo;

            command = new SqlCommand("insert into Pedido(IdCedula,IdSucursal,Estado,FechaRecojo) VALUES (@IdCedula,@IdSucursal,@Estado,@FechaRecojo)", conn);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(IdSucursal);
            command.Parameters.Add(Estado);
            command.Parameters.Add(FechaRecojo);
            command.ExecuteNonQuery();

            conn.Close();

        }
        public void DeletePedido([FromBody] Pedido pedido)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdPedido = new SqlParameter("@IdPedido", System.Data.SqlDbType.Int);
            IdPedido.Value = pedido.IdPedido;

            command = new SqlCommand("update Pedido set LogicDelete=1 where IdPedido = @IdPedido", conn);
            command.Parameters.Add(IdPedido);
            command.ExecuteNonQuery();

            conn.Close();

        }


        public List<PedidoSucursal> GetPedidosSucursal(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select Sucursal.Nombre,Sucursal.Provincia,Sucursal.Canton,Sucursal.Distrito,Pedido.IdPedido,Pedido.IdCedula,Pedido.Estado,Pedido.Recogido,Pedido.Preparado,Pedido.FechaRecojo from Sucursal inner join Pedido on Sucursal.IdSucursal = Pedido.IdSucursal inner join Empresa on Sucursal.IdEmpresa=Empresa.IdEmpresa where Pedido.LogicDelete!=1 and Pedido.Recogido!=1 and Pedido.Preparado!=1 and Sucursal.IdSucursal=" + id.ToString() + " ORDER BY Pedido.FechaRecojo DESC", conn);
            read = command.ExecuteReader();

            List<PedidoSucursal> ListPedidos = new List<PedidoSucursal>();
            while (read.Read())
            {
                PedidoSucursal pedido = new PedidoSucursal();
                pedido.IdCedula = Convert.ToInt32(read["IdCedula"]);
                pedido.NombreSucursal = Convert.ToString(read["Nombre"]);
                pedido.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedido.Provincia = Convert.ToString(read["Provincia"]);
                pedido.Canton = Convert.ToString(read["Canton"]);
                pedido.Distrito = Convert.ToString(read["Distrito"]);
                pedido.Estado = Convert.ToBoolean(read["Estado"]);
                pedido.Preparado = Convert.ToBoolean(read["Preparado"]);
                pedido.Recogido = Convert.ToBoolean(read["Recogido"]);
                pedido.FechaRecojo = Convert.ToDateTime(read["FechaRecojo"]);

                ListPedidos.Add(pedido);

            }


            read.Close();
            conn.Close();
            return ListPedidos;
        }

        public List<PedidoSucursal> GetPedidosSucursalPreparado(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select Sucursal.Nombre,Sucursal.Provincia,Sucursal.Canton,Sucursal.Distrito,Pedido.IdPedido,Pedido.IdCedula,Pedido.Estado,Pedido.Recogido,Pedido.Preparado,Pedido.FechaRecojo from Sucursal inner join Pedido on Sucursal.IdSucursal = Pedido.IdSucursal inner join Empresa on Sucursal.IdEmpresa=Empresa.IdEmpresa where Pedido.LogicDelete!=1 and Pedido.Recogido=0 and Pedido.Preparado=1 and Sucursal.IdSucursal=" + id.ToString() + " ORDER BY Pedido.FechaRecojo DESC", conn);
            read = command.ExecuteReader();

            List<PedidoSucursal> ListPedidos = new List<PedidoSucursal>();
            while (read.Read())
            {
                PedidoSucursal pedido = new PedidoSucursal();
                pedido.IdCedula = Convert.ToInt32(read["IdCedula"]);
                pedido.NombreSucursal = Convert.ToString(read["Nombre"]);
                pedido.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedido.Provincia = Convert.ToString(read["Provincia"]);
                pedido.Canton = Convert.ToString(read["Canton"]);
                pedido.Distrito = Convert.ToString(read["Distrito"]);
                pedido.Estado = Convert.ToBoolean(read["Estado"]);
                pedido.Preparado = Convert.ToBoolean(read["Preparado"]);
                pedido.Recogido = Convert.ToBoolean(read["Recogido"]);
                pedido.FechaRecojo = Convert.ToDateTime(read["FechaRecojo"]);

                ListPedidos.Add(pedido);

            }


            read.Close();
            conn.Close();
            return ListPedidos;
        }





        public List<PedidoSucursal> GetPedidosSucursalRecogido(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select Sucursal.Nombre,Sucursal.Provincia,Sucursal.Canton,Sucursal.Distrito,Pedido.IdPedido,Pedido.IdCedula,Pedido.Estado,Pedido.Recogido,Pedido.Preparado,Pedido.FechaRecojo from Sucursal inner join Pedido on Sucursal.IdSucursal = Pedido.IdSucursal inner join Empresa on Sucursal.IdEmpresa=Empresa.IdEmpresa where Pedido.LogicDelete!=1 and Pedido.Recogido=1 and Pedido.Preparado=1 and Sucursal.IdSucursal=" + id.ToString() + " ORDER BY Pedido.FechaRecojo DESC", conn);
            read = command.ExecuteReader();

            List<PedidoSucursal> ListPedidos = new List<PedidoSucursal>();
            while (read.Read())
            {
                PedidoSucursal pedido = new PedidoSucursal();
                pedido.IdCedula = Convert.ToInt32(read["IdCedula"]);
                pedido.NombreSucursal = Convert.ToString(read["Nombre"]);
                pedido.IdPedido = Convert.ToInt32(read["IdPedido"]);
                pedido.Provincia = Convert.ToString(read["Provincia"]);
                pedido.Canton = Convert.ToString(read["Canton"]);
                pedido.Distrito = Convert.ToString(read["Distrito"]);
                pedido.Estado = Convert.ToBoolean(read["Estado"]);
                pedido.Preparado = Convert.ToBoolean(read["Preparado"]);
                pedido.Recogido = Convert.ToBoolean(read["Recogido"]);
                pedido.FechaRecojo = Convert.ToDateTime(read["FechaRecojo"]);

                ListPedidos.Add(pedido);

            }


            read.Close();
            conn.Close();
            return ListPedidos;
        }

        public void PrepararPedido(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();



            command = new SqlCommand("UPDATE Pedido SET Preparado=1 where IdPedido=" + id.ToString(), conn);

            command.ExecuteNonQuery();

            conn.Close();




        }

        public void NoPrepararPedido(int id)
        {

            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();



            command = new SqlCommand("UPDATE Pedido SET Preparado=0 where IdPedido=" + id.ToString(), conn);

            command.ExecuteNonQuery();

            conn.Close();

        }

        public void RecogerPedido(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();



            command = new SqlCommand("UPDATE Pedido SET Recogido=1 where IdPedido=" + id.ToString(), conn);

            command.ExecuteNonQuery();

            conn.Close();



        }

        public void PostPedidoImage([FromBody] PedidoImage pedido)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = pedido.IdCedula;

            SqlParameter IdSucursal = new SqlParameter("@IdSucursal", System.Data.SqlDbType.Int);
            IdSucursal.Value = pedido.IdSucursal;

            SqlParameter Estado = new SqlParameter("@Estado", System.Data.SqlDbType.Bit);
            Estado.Value = pedido.Estado;

            SqlParameter Recogido = new SqlParameter("@Recogido", System.Data.SqlDbType.Bit);
            Recogido.Value = pedido.Recogido;

            SqlParameter Preparado = new SqlParameter("@Preparado", System.Data.SqlDbType.Bit);
            Preparado.Value = pedido.Preparado;

            SqlParameter FechaRecojo = new SqlParameter("@FechaRecojo", System.Data.SqlDbType.Date);
            FechaRecojo.Value = Convert.ToDateTime(pedido.FechaRecojo);

            SqlParameter RecetaImg = new SqlParameter("@RecetaImg", System.Data.SqlDbType.VarChar);
            RecetaImg.Value = pedido.RecetaImg;

            command = new SqlCommand("insert into Pedido(IdCedula,IdSucursal,Estado,Recogido,Preparado,FechaRecojo,RecetaImg) VALUES (@IdCedula,@IdSucursal,@Estado,@Recogido,@Preparado,@FechaRecojo,@RecetaImg)", conn);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(IdSucursal);
            command.Parameters.Add(Estado);
            command.Parameters.Add(Recogido);
            command.Parameters.Add(Preparado);
            command.Parameters.Add(FechaRecojo);
            command.Parameters.Add(RecetaImg);
            command.ExecuteNonQuery();

            conn.Close();

        }


        public string GetImagePedido()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select RecetaImg from Pedido where IdPedido=13", conn);
            read = command.ExecuteReader();

            string img = "";


            while (read.Read())
            {

                img = read["RecetaImg"].ToString();

            }

            read.Close();
            conn.Close();

            return img;
        }



    }

}