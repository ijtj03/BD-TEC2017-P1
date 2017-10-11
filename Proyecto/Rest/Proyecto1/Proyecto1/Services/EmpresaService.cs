using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
namespace Proyecto1.Services
{
    public class EmpresaService
    {
        public List<Empresa> GetAllEmpresas()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Empresa where LogicDelete = 0", conn);
            read = command.ExecuteReader();
            List<Empresa> empresas = new List<Empresa>();
            while (read.Read())
            {
                Empresa empresa = new Empresa();
                empresa.IdEmpresa = Convert.ToInt32(read["IdEmpresa"]);
                empresa.Nombre = read["Nombre"].ToString();
                empresas.Add(empresa);

            }
            return empresas;
        }
        public void PostEmpresa([FromBody] Empresa empresa)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("insert  Empresa(Nombre) VALUES (@Nombre)", conn);

            command.Parameters.AddWithValue("@Nombre", empresa.Nombre);
            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}