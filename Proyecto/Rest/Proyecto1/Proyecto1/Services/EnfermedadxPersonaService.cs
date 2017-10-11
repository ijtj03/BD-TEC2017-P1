using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Data.SqlClient;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class EnfermedadxPersonaService
    {
        public List<EnfermedadxPersona> GetAllEnfermedadxPersona()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT * from EnfermedadxPersona", conn);
            read = command.ExecuteReader();

            List<EnfermedadxPersona> ListEnfermedadxPersona = new List<EnfermedadxPersona>();
            while (read.Read())
            {
                EnfermedadxPersona enfermedadxpersona = new EnfermedadxPersona();
                enfermedadxpersona.IdCedula = Convert.ToInt32(read["IdCedula"]);
                enfermedadxpersona.IdEnfermedad = Convert.ToInt32(read["IdEnfermedad"]);
                enfermedadxpersona.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

            }
            read.Close();
            conn.Close();
            return ListEnfermedadxPersona;
        }
        
        public List<MisEnfermedades> GetMisEnfermedades(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select Enfermedad.Nombre,Enfermedad.IdEnfermedad,EnfermedadxPersona.FechaEnfermedad from Persona left join EnfermedadxPersona on EnfermedadxPersona.IdCedula= Persona.IdCedula left join Enfermedad on Enfermedad.IdEnfermedad= EnfermedadxPersona.IdEnfermedad where  EnfermedadxPersona.LogicDelete=0 and Persona.IdCedula =" + id.ToString(), conn);
            read = command.ExecuteReader();

            List<MisEnfermedades> ListEnfermedadxPersona = new List<MisEnfermedades>();
            while (read.Read())
            {
                MisEnfermedades enfermedadxpersona = new MisEnfermedades();
                enfermedadxpersona.Nombre = Convert.ToString(read["Nombre"]);
                enfermedadxpersona.IdEnfermedad = Convert.ToInt32(read["IdEnfermedad"]);
                enfermedadxpersona.FechaEnfermedad = Convert.ToString(read["FechaEnfermedad"]);
                ListEnfermedadxPersona.Add(enfermedadxpersona);
            }
            read.Close();
            conn.Close();
            return ListEnfermedadxPersona;
        }
        public void PostEnfermedadxPersona([FromBody] EnfermedadxPersona exp)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();


            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = exp.IdCedula;

            SqlParameter IdEnfermedad = new SqlParameter("@IdEnfermedad", System.Data.SqlDbType.Int);
            IdEnfermedad.Value = exp.IdEnfermedad;

            SqlParameter FechaEnfermedad = new SqlParameter("@FechaEnfermedad", System.Data.SqlDbType.Date);
            FechaEnfermedad.Value = exp.FechaEnfermedad;

            command = new SqlCommand("insert into EnfermedadxPersona(IdCedula,IdEnfermedad,FechaEnfermedad) VALUES (@IdCedula,@IdEnfermedad,@FechaEnfermedad)", conn);
            command.Parameters.Add(IdEnfermedad);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(FechaEnfermedad);

            command.ExecuteNonQuery();

            conn.Close();


        }
        public void EliminarEnfxPer([FromBody] EliminarEnfxPer exp)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();


            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = exp.IdCedula;

            SqlParameter IdEnfermedad = new SqlParameter("@IdEnfermedad", System.Data.SqlDbType.Int);
            IdEnfermedad.Value = exp.IdEnfermedad;
            
            command = new SqlCommand("update EnfermedadxPersona set LogicDelete=1 where IdEnfermedad = @IdEnfermedad and IdCedula = @IdCedula", conn);
            command.Parameters.Add(IdEnfermedad);
            command.Parameters.Add(IdCedula);

            command.ExecuteNonQuery();

            conn.Close();


        }


    }
}