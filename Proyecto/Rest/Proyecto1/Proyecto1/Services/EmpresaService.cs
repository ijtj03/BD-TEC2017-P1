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

        public int GetIdEmpresa(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;
            Console.WriteLine("Numero de sucursal"+ id);
            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT E.IdEmpresa FROM Sucursal AS S INNER JOIN Empresa AS E ON S.IdEmpresa = E.IdEmpresa WHERE E.LogicDelete = 0 and S.LogicDelete = 0 and S.IdSucursal="+ id.ToString() , conn);
            read = command.ExecuteReader();
            int IDE = -1;
            while (read.Read())
            {
                IDE = Convert.ToInt32(read["IdEmpresa"]);
            }
            return IDE;
        }
    }
}