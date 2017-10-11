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

        public Sucursal GetSucursal(int IdSucursal)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT * from Sucursal WHERE IdCedula=" + IdSucursal.ToString(), conn);
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