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

        public List<String> GetAllNombresCasasFarmaceuticas()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT Nombre  from CasaFarmaceutica where LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<String> cFarmaceuticas = new List<String>();
            while (read.Read())
            {
                String Nombre = read["Nombre"].ToString();
                cFarmaceuticas.Add(Nombre);

            }
            read.Close();
            conn.Close();
            return cFarmaceuticas;
        }

        public List<String> GetAllNombresCasasFarmaceuticasxMedicamento(String nombre)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT CF.Nombre  from CasaFarmaceutica AS CF INNER JOIN MedicamentoxCasaFarmaceutica AS MCF ON CF.IdCasaFarmaceutica = MCF.IdCasaFarmaceutica INNER JOIN Medicamento AS M ON MCF.IdMedicamento = M.IdMedicamento WHERE M.Nombre = '"+ nombre.ToString() + "'", conn);
            read = command.ExecuteReader();

            List<String> cFarmaceuticas = new List<String>();
            while (read.Read())
            {
                String Nombre = read["Nombre"].ToString();
                cFarmaceuticas.Add(Nombre);

            }
            read.Close();
            conn.Close();
            return cFarmaceuticas;
        }

        public int GetIdCasaFarmaceutica(string nombre)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT IdCasaFarmaceutica  from CasaFarmaceutica where  Nombre='" + nombre + "'", conn);
            read = command.ExecuteReader();
            int IdRol = -1;
            while (read.Read())
            {
                IdRol = Convert.ToInt32(read["IdCasaFarmaceutica"]);

            }
            return IdRol;
        }

        public void UpdateReceta([FromBody]Medicamento medicamento)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            String comm = "Update Medicamento SET NecesitaReceta='" + medicamento.NecesitaReceta + "WHERE IdCedula=" + medicamento.IdMedicamento;


            command = new SqlCommand(comm, conn);

            command.ExecuteNonQuery();
            conn.Close();
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