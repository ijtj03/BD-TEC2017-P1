using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;

namespace Proyecto1.Services
{
    public class CasaFarmaceuticaService
    {
        public List<CasaFarmaceutica> GetAllCasasFarmaceuticas()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from CasaFarmaceutica where LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<CasaFarmaceutica> cFarmaceuticas = new List<CasaFarmaceutica>();
            while (read.Read())
            {
                CasaFarmaceutica cFar = new CasaFarmaceutica();
                cFar.IdCasaFarmaceutica = Convert.ToInt32(read["IdCasaFarmaceutica"]);
                cFar.Nombre = read["Nombre"].ToString();

                cFarmaceuticas.Add(cFar);

            }
            read.Close();
            conn.Close();
            return cFarmaceuticas;
        }

        public void PostCasaFarmaceutica([FromBody] CasaFarmaceutica cFar)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("insert  CasaFarmaceutica(Nombre) VALUES (@Nombre)", conn);

            command.Parameters.AddWithValue("@Nombre", cFar.Nombre);
            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}