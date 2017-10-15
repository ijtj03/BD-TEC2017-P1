using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using System.Data.SqlClient;

namespace Proyecto1.Services
{
    public class RecetaService
    {
        public List<Receta> GetRecetasId(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Receta where LogicDelete = 0 and IdCedula="+id.ToString(), conn);
            read = command.ExecuteReader();

            List<Receta> cFarmaceuticas = new List<Receta>();
            while (read.Read())
            {
                Receta cFar = new Receta();
                cFar.IdCedula = Convert.ToInt32(read["IdCedula"]);
                cFar.IdReceta = Convert.ToInt32(read["IdReceta"]);
                cFar.RecetaImage = read["RecetaImg"].ToString();

                cFarmaceuticas.Add(cFar);

            }
            read.Close();
            conn.Close();
            return cFarmaceuticas;
        }
        public int GetLastId()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select max(Receta.IdReceta) as LastId from Receta where LogicDelete = 0", conn);
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
        public void PostReceta([FromBody] Receta cFar)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("insert  Receta(IdCedula,RecetaImg) VALUES (@IdCedula,@RecetaImage)", conn);

            command.Parameters.AddWithValue("@IdCedula", cFar.IdCedula);
            command.Parameters.AddWithValue("@RecetaImage", cFar.RecetaImage);
            command.ExecuteNonQuery();

            conn.Close();

        }
        public void DeleteReceta([FromBody] Receta cFar)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("update Receta set LogicDelete=1 where IdReceta=@IdReceta", conn);

            command.Parameters.AddWithValue("@IdReceta", cFar.IdReceta);
            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}