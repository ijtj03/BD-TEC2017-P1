using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class PersonaxRolService
    {
        public List<PersonaxRol> GetAllPersonasxRol()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from PersonaxRol", conn);
            read = command.ExecuteReader();

            List<PersonaxRol> ListPersonas = new List<PersonaxRol>();
            while (read.Read())
            {
                PersonaxRol persona = new PersonaxRol();
                persona.IdCedula = Convert.ToInt32(read["IdCedula"]);
                persona.IdRol = Convert.ToInt32(read["IdRol"]);
                persona.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);
                ListPersonas.Add(persona);

            }
            read.Close();
            conn.Close();
            return ListPersonas;
        }

        public PersonaxRol GetPersonaxRol(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from PersonaxRol where LogicDelete = 0 and IdCedula=" + id.ToString(), conn);
            read = command.ExecuteReader();

            PersonaxRol persona = new PersonaxRol();
            while (read.Read())
            {
                persona.IdCedula = Convert.ToInt32(read["IdCedula"]);
                persona.IdRol = Convert.ToInt32(read["IdRol"]);
                persona.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);
            }
            read.Close();
            conn.Close();
            return persona;
        }

        public int GetPersonaxRolId(int cedula)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT IdRol  from PersonaxRol where LogicDelete = 0 and IdCedula=" + cedula.ToString(), conn);
            read = command.ExecuteReader();

            int persona = -1;
            while (read.Read())
            {
                persona = Convert.ToInt32(read["IdRol"]);
            }
            read.Close();
            conn.Close();
            return persona;
        }

        public void PostPersonaxRol([FromBody] PersonaxRol persona)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = persona.IdCedula;

            SqlParameter IdRol = new SqlParameter("@IdRol", System.Data.SqlDbType.Int);
            IdRol.Value = persona.IdRol;



            command = new SqlCommand("insert into PersonaxRol(IdCedula, IdRol) VALUES (@IdCedula,@IdRol)", conn);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(IdRol);
            command.ExecuteNonQuery();

            conn.Close();

        }

        public void UpdatePersonaxRol([FromBody] PersonaxRol rol)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            String comm = "Update PersonaxRol SET IdRol=" + rol.IdRol +" WHERE IdCedula=" + rol.IdCedula;


            command = new SqlCommand(comm, conn);

            command.ExecuteNonQuery();
            conn.Close();

        }

        public void DeletePersonaxRol([FromBody] int cedula)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("UPDATE PersonaxRol SET LogicDelete = 1  WHERE IdCedula=" + cedula.ToString(), conn);
            command.ExecuteNonQuery();
            conn.Close();

        }
    }


}