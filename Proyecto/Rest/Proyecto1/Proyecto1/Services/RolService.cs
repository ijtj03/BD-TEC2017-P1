using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;

namespace Proyecto1.Services
{
    public class RolService
    {
        public List<Rol> GetAllRoles()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Rol where LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<Rol> ListRoles = new List<Rol>();
            while (read.Read())
            {
                Rol rol = new Rol();
                rol.IdRol = Convert.ToInt32(read["IdRol"]);
                rol.Nombre = read["Nombre"].ToString();
                rol.Descripcion = read["Descripcion"].ToString();
                rol.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListRoles.Add(rol);

            }
            read.Close();
            conn.Close();
            return ListRoles;
        }


        public Rol GetRol(int id)
        {

            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Rol where IdRol=" + id.ToString(), conn);
            read = command.ExecuteReader();
            Console.WriteLine("Paso por aqui");
            Rol rol = new Rol();
            while (read.Read())
            {
                rol.IdRol = Convert.ToInt32(read["IdRol"]);
                rol.Nombre = read["Nombre"].ToString();
                rol.Descripcion = read["Descripcion"].ToString();
                rol.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);
            }
            read.Close();
            conn.Close();
            return rol;
        }

        public void PostRol([FromBody] Rol rol)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter Nombre = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
            Nombre.Value = rol.Nombre;

            SqlParameter Descripcion = new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar);
            Descripcion.Value = rol.Descripcion;

            command = new SqlCommand("insert into Rol(Nombre,Descripcion) VALUES (@Nombre,@Descripcion)", conn);
            command.Parameters.Add(Nombre);
            command.Parameters.Add(Descripcion);
            command.ExecuteNonQuery();
            conn.Close();

        }

        public List<String> GetAllRolesN()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT Nombre  from Rol where LogicDelete = 0", conn);
            read = command.ExecuteReader();
            List<String> roles = new List<String>();
            while (read.Read())
            {
                String Nombre = read["Nombre"].ToString();
                roles.Add(Nombre);

            }
            return roles;
        }

        public int GetIdRol(string nombre)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT IdRol  from Rol where  Nombre='" + nombre + "'", conn);
            read = command.ExecuteReader();
            int IdRol = -1;
            while (read.Read())
            {
                IdRol = Convert.ToInt32(read["IdRol"]);

            }
            return IdRol;
        }

        public String GetNombreRol(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT Nombre  from Rol where  IdRol=" + id.ToString(), conn);
            read = command.ExecuteReader();
            String nombre = "";
            while (read.Read())
            {
                nombre = read["Nombre"].ToString();

            }
            return nombre;
        }

        public void DeleteRol([FromBody] int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("UPDATE Rol SET LogicDelete = 1  WHERE IdRol=" + id.ToString(), conn);
            command.ExecuteNonQuery();
            conn.Close();

        }

        public void UpdateRol([FromBody] Rol rol)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            String comm = "Update Rol SET Nombre=\'" + rol.Nombre + "\',Descripcion=\'" + rol.Descripcion ;


            command = new SqlCommand(comm, conn);

            command.ExecuteNonQuery();
            conn.Close();

        }
    }
}