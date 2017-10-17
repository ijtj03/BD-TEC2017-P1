using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class MedicamentoService
    {
        public List<Medicamento> GetAllMedicamentos()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT * from Medicamento", conn);
            read = command.ExecuteReader();

            List<Medicamento> ListMedicamentos = new List<Medicamento>();
            while (read.Read())
            {
                Medicamento medicamento = new Medicamento();
                medicamento.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                medicamento.Nombre = read["Nombre"].ToString();
                medicamento.NecesitaReceta = Convert.ToBoolean(read["NecesitaReceta"]);
                medicamento.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListMedicamentos.Add(medicamento);

            }
            read.Close();
            conn.Close();
            return ListMedicamentos;
        }

        public List<String> GetAllNombresMedicamentosxSucursal(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT Nombre from Medicamento AS M INNER JOIN MedicamentoxSucursal AS MS ON M.IdMedicamento = MS.IdMedicamento WHERE MS.LogicDelete = 0 and MS.IdSucursal=" + id, conn);
            read = command.ExecuteReader();

            List<String> ListMedicamentos = new List<String>();
            while (read.Read())
            {
                String Nombre = read["Nombre"].ToString();

                ListMedicamentos.Add(Nombre);

            }
            read.Close();
            conn.Close();
            return ListMedicamentos;
        }

        public int GetMedicamentoID(string nombre)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;
            
            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT IdMedicamento from Medicamento WHERE Nombre ='" + nombre.ToString()+"'", conn);
            read = command.ExecuteReader();
            int id=-1;
            while (read.Read())
            {
                id = Convert.ToInt32(read["IdMedicamento"]);

            }
            return id;
        }

        public int GetLastMedicamentoId()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select max(Medicamento.IdMedicamento) as LastId from Medicamento where LogicDelete = 0", conn);
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

        public void UpdateReceta([FromBody]Medicamento medicamento)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            //conn = new SqlConnection("Data Source=MELENDEZ-JEISON\\SQLEXPRESS;Initial Catalog=Proyecto1;Integrated Security=True");
            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            String comm = "Update Medicamento SET NecesitaReceta=" + medicamento.NecesitaReceta.ToString() + "WHERE IdMedicamento=" + medicamento.IdMedicamento.ToString();


            command = new SqlCommand(comm, conn);

            command.ExecuteNonQuery();
            conn.Close();
        }



        public void PostMedicamento([FromBody] Medicamento medicamento)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();


            SqlParameter Nombre = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
            Nombre.Value = medicamento.Nombre;

            SqlParameter NecesitaReceta = new SqlParameter("@NecesitaReceta", System.Data.SqlDbType.Bit);
            NecesitaReceta.Value = Convert.ToInt32(medicamento.NecesitaReceta);


            command = new SqlCommand("insert into Medicamento(Nombre,NecesitaReceta) VALUES (@Nombre,@NecesitaReceta)", conn);
            command.Parameters.Add(Nombre);
            command.Parameters.Add(NecesitaReceta);

            command.ExecuteNonQuery();

            conn.Close();

        }

        public List<GestionMedicamento> GetAllMedicamentosxRelacion(int IdSucursal)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT M.IdMedicamento, M.Nombre, M.NecesitaReceta, MS.IdSucursal, MS.Cantidad, MS.PrecioSucursal,CF.IdCasaFarmaceutica , CF.Nombre AS NombreCasaFarmaceutica FROM Medicamento AS M INNER JOIN MedicamentoxSucursal AS MS ON M.IdMedicamento = MS.IdMedicamento INNER JOIN MedicamentoxCasaFarmaceutica AS MC ON M.IdMedicamento = MC.IdMedicamento INNER JOIN CasaFarmaceutica AS CF ON CF.IdCasaFarmaceutica = MC.IdCasaFarmaceutica WHERE M.LogicDelete = 0 and MS.LogicDelete = 0 and MC.LogicDelete = 0 and MS.IdSucursal =" + IdSucursal.ToString(), conn);
            read = command.ExecuteReader();

            List<GestionMedicamento> ListMedicamentos = new List<GestionMedicamento>();
            while (read.Read())
            {
                GestionMedicamento medicamento = new GestionMedicamento();
                medicamento.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                medicamento.IdCasaFarmaceutica = Convert.ToInt32(read["IdCasaFarmaceutica"]);
                medicamento.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                medicamento.Nombre = read["Nombre"].ToString();
                medicamento.NombreCasaFarmaceutica = read["NombreCasaFarmaceutica"].ToString();
                medicamento.NecesitaReceta = Convert.ToBoolean(read["NecesitaReceta"]);
                medicamento.Cantidad = Convert.ToInt32(read["Cantidad"]);
                medicamento.PrecioSucursal = Convert.ToInt32(read["PrecioSucursal"]);
                ListMedicamentos.Add(medicamento);

            }
            read.Close();
            conn.Close();
            return ListMedicamentos;
        }

        public GestionMedicamento GetMedicamentosxRelacion(int idm, int ids, int idc)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();


            command = new SqlCommand("SELECT M.IdMedicamento,MC.PrecioProveedor ,M.Nombre, M.NecesitaReceta, MS.IdSucursal, MS.Cantidad, MS.PrecioSucursal,CF.IdCasaFarmaceutica , CF.Nombre AS NombreCasaFarmaceutica FROM Medicamento AS M INNER JOIN MedicamentoxSucursal AS MS ON M.IdMedicamento = MS.IdMedicamento INNER JOIN MedicamentoxCasaFarmaceutica AS MC ON M.IdMedicamento = MC.IdMedicamento INNER JOIN CasaFarmaceutica AS CF ON CF.IdCasaFarmaceutica = MC.IdCasaFarmaceutica WHERE M.LogicDelete = 0 and MS.LogicDelete = 0 and MC.LogicDelete = 0 and M.IdMedicamento =" + idm + "and MC.IdCasaFarmaceutica=" + idc + " and MS.IdSucursal=" + ids, conn);
            read = command.ExecuteReader();

            GestionMedicamento medicamento = new GestionMedicamento();
            while (read.Read())
            {
                medicamento.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                medicamento.IdCasaFarmaceutica = Convert.ToInt32(read["IdCasaFarmaceutica"]);
                medicamento.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                medicamento.Nombre = read["Nombre"].ToString();
                medicamento.NombreCasaFarmaceutica = read["NombreCasaFarmaceutica"].ToString();
                medicamento.NecesitaReceta = Convert.ToBoolean(read["NecesitaReceta"]);
                medicamento.Cantidad = Convert.ToInt32(read["Cantidad"]);
                medicamento.PrecioSucursal = Convert.ToInt32(read["PrecioSucursal"]);
                medicamento.PrecioProveedor = Convert.ToInt32(read["PrecioProveedor"]);

            }
            read.Close();
            conn.Close();
            return medicamento;
        }

        public void DeleteMedicamento([FromBody] int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("UPDATE Medicamento SET LogicDelete = 1  WHERE IdMedicamento=" + id.ToString(), conn);
            command.ExecuteNonQuery();
            conn.Close();

        }

    }
}