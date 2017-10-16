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
    }
}