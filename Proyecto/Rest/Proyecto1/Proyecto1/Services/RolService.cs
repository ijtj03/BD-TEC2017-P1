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
                rol.IdCedula = Convert.ToInt32(read["IdCedula"]);
                rol.Nombre = read["Nombre"].ToString();
                rol.Descripcion = read["Descripcion"].ToString();
                rol.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListRoles.Add(rol);

            }
            read.Close();
            conn.Close();
            return ListRoles;
        }

        public void PostRol([FromBody] Rol rol)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = rol.IdCedula;

            SqlParameter Nombre = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
            Nombre.Value = rol.Nombre;

            SqlParameter Descripcion = new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar);
            Descripcion.Value = rol.Descripcion;


            command = new SqlCommand("insert into Rol(IdCedula,Nombre,Descripcion) VALUES (@IdCedula,@Nombre,@Descripcion)", conn);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(Nombre);
            command.Parameters.Add(Descripcion);
            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}