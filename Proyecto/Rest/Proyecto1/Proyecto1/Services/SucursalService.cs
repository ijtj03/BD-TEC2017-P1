using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;

namespace Proyecto1.Services
{
    public class SucursalService
    {
        public List<Sucursal> GetAllSucursales()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Sucursal where LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<Sucursal> ListSucursales = new List<Sucursal>();
            while (read.Read())
            {
                Sucursal sucursal = new Sucursal();
                sucursal.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                sucursal.IdEmpresa = Convert.ToInt32(read["IdEmpresa"]);
                sucursal.Administrador = Convert.ToInt32(read["Administrador"]);
                sucursal.Nombre = read["Nombre"].ToString();
                sucursal.Provincia = read["Provincia"].ToString();
                sucursal.Canton = read["Canton"].ToString();
                sucursal.Distrito = read["Distrito"].ToString();
                sucursal.DescripcionDireccion = read["DescripcionDireccion"].ToString();
                sucursal.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListSucursales.Add(sucursal);

            }
            read.Close();
            conn.Close();
            return ListSucursales;
        }

        public List<String> GetAllNombreSucursales(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT S.Nombre FROM Sucursal AS S INNER JOIN Empresa AS E ON S.IdEmpresa = E.IdEmpresa WHERE E.LogicDelete = 0 and S.LogicDelete = 0 and S.IdEmpresa=" + id.ToString(), conn);
            read = command.ExecuteReader();

            List<String> ListSucursales = new List<String>();
            while (read.Read())
            {
                String Nombre = read["Nombre"].ToString();
                ListSucursales.Add(Nombre);

            }
            read.Close();
            conn.Close();
            return ListSucursales;
        }

        public int GetIdSucursal(String nombre)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT IdSucursal FROM Sucursal WHERE LogicDelete = 0 and Nombre ='" + nombre + "'", conn);
            read = command.ExecuteReader();

            int idSucursal = -1;
            while (read.Read())
            {
                idSucursal = Convert.ToInt32(read["IdSucursal"]);

            }
            read.Close();
            conn.Close();
            return idSucursal;
        }

        public int GetLastSucursalId()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select max(Sucursal.IdSucursal) as LastId from Sucursal where LogicDelete = 0", conn);
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

        public Sucursal GetSucursal(int IdSucursal)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT * from Sucursal WHERE LogicDelete=0 and  IdSucursal=" + IdSucursal.ToString(), conn);
            read = command.ExecuteReader();

            Sucursal sucursal = new Sucursal();
            while (read.Read())
            {
                sucursal.IdEmpresa = Convert.ToInt32(read["IdEmpresa"]);
                sucursal.Nombre = read["Nombre"].ToString();
                sucursal.Provincia = read["Provincia"].ToString();
                sucursal.Canton = read["Canton"].ToString();
                sucursal.Distrito = read["Distrito"].ToString();
                sucursal.DescripcionDireccion = read["DescripcionDireccion"].ToString();
                sucursal.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);


            }
            read.Close();
            conn.Close();
            return sucursal;
        }

        public void PostSucursal([FromBody] Sucursal sucursal)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdEmpresa = new SqlParameter("@IdEmpresa", System.Data.SqlDbType.Int);
            IdEmpresa.Value = sucursal.IdEmpresa;

            SqlParameter Administrador = new SqlParameter("@Administrador", System.Data.SqlDbType.Int);
            Administrador.Value = sucursal.Administrador;

            SqlParameter Nombre = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
            Nombre.Value = sucursal.Nombre;

            SqlParameter Provincia = new SqlParameter("@Provincia", System.Data.SqlDbType.VarChar);
            Provincia.Value = sucursal.Provincia;

            SqlParameter Canton = new SqlParameter("@Canton", System.Data.SqlDbType.VarChar);
            Canton.Value = sucursal.Canton;

            SqlParameter Distrito = new SqlParameter("@Distrito", System.Data.SqlDbType.VarChar);
            Distrito.Value = sucursal.Distrito;

            SqlParameter DescripcionDireccion = new SqlParameter("@DescripcionDireccion", System.Data.SqlDbType.VarChar);
            DescripcionDireccion.Value = sucursal.DescripcionDireccion;


            command = new SqlCommand("insert into Sucursal(IdEmpresa,Administrador,Nombre,Provincia,Canton,Distrito,DescripcionDireccion) VALUES (@IdEmpresa,@Administrador,@Nombre,@Provincia,@Canton,@Distrito,@DescripcionDireccion)", conn);
            command.Parameters.Add(IdEmpresa);
            command.Parameters.Add(Administrador);
            command.Parameters.Add(Nombre);
            command.Parameters.Add(Provincia);
            command.Parameters.Add(Canton);
            command.Parameters.Add(Distrito);
            command.Parameters.Add(DescripcionDireccion);

            command.ExecuteNonQuery();

            conn.Close();

        }

        public void UpdateSucursal([FromBody] Sucursal sucursal)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            String comm = "Update Sucursal SET Nombre=\'" + sucursal.Nombre +
                "\',DescripcionDireccion=\'" + sucursal.DescripcionDireccion + "\',Provincia=\'" + sucursal.Provincia + "\'" +
                ",Canton=\'" + sucursal.Canton + "\',Distrito=\'" + sucursal.Distrito + "\' WHERE IdSucursal=" + sucursal.IdSucursal;


            command = new SqlCommand(comm, conn);

            command.ExecuteNonQuery();
            conn.Close();
        }


        public void DeleteSucursal([FromBody] int IdSucursal)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("UPDATE Sucursal SET LogicDelete = 1  WHERE IdSucursal=" + IdSucursal.ToString(), conn);
            command.ExecuteNonQuery();
            conn.Close();

        }
    }
}