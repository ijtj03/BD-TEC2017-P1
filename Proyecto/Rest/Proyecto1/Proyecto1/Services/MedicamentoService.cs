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

        public List<GestionMedicamento> GetAllMedicamentosxRelacion()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT M.IdMedicamento, M.Nombre, M.NecesitaReceta, MS.IdSucursal, MS.Cantidad, MS.PrecioSucursal,CF.IdCasaFarmaceutica , CF.Nombre  FROM Medicamento AS M INNER JOIN MedicamentoxSucursal AS MS ON M.IdMedicamento = MS.IdMedicamento INNER JOIN MedicamentoxCasaFarmaceutica AS MC ON M.IdMedicamento = MC.IdMedicamento INNER JOIN CasaFarmaceutica AS CF ON CF.IdCasaFarmaceutica = MC.IdCasaFarmaceutica", conn);
            read = command.ExecuteReader();

            List<GestionMedicamento> ListMedicamentos = new List<GestionMedicamento>();
            while (read.Read())
            {
                GestionMedicamento medicamento = new GestionMedicamento();
                medicamento.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                medicamento.IdCasaFarmaceutica = Convert.ToInt32(read["IdCasaFarmaceutica"]);
                medicamento.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                medicamento.Nombre = read["Nombre"].ToString();
                medicamento.NecesitaReceta = Convert.ToBoolean(read["NecesitaReceta"]);
                

                ListMedicamentos.Add(medicamento);

            }
            read.Close();
            conn.Close();
            return ListMedicamentos;
        }

    }
}