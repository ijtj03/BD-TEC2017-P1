using Proyecto1.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class MedicamentoxCasaFarmaceuticaService
    {
        public List<MedicamentoxCasaFarmaceutica> GetAllMedicamentoxCasaFarmaceutica()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from MedicamentoxCasaFarmaceutica where LogicDelete = 0", conn);
            read = command.ExecuteReader();
            List<MedicamentoxCasaFarmaceutica> ListMedicamentoxCasaFarmaceutica = new List<MedicamentoxCasaFarmaceutica>();
            while (read.Read())
            {
                MedicamentoxCasaFarmaceutica mxcf = new MedicamentoxCasaFarmaceutica();
                mxcf.IdCasaFarmaceutica = Convert.ToInt32(read["IdCasaFarmaceutica"]);
                mxcf.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                mxcf.PrecioProveedor = Convert.ToInt32(read["PrecioProvedor"]);
                mxcf.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);
                ListMedicamentoxCasaFarmaceutica.Add(mxcf);

            }
            return ListMedicamentoxCasaFarmaceutica;
        }
        public void PostMedicamentoxCasaFarmaceutica([FromBody] MedicamentoxCasaFarmaceutica mxcf)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCasaFarmaceutica = new SqlParameter("@IdCasaFarmaceutica", System.Data.SqlDbType.Int);
            IdCasaFarmaceutica.Value = mxcf.IdCasaFarmaceutica;

            SqlParameter IdMedicamento = new SqlParameter("@IdMedicamento", System.Data.SqlDbType.Int);
            IdMedicamento.Value = mxcf.IdMedicamento;

            SqlParameter PrecioProveedor = new SqlParameter("@PrecioProveedor", System.Data.SqlDbType.Int);
            PrecioProveedor.Value = mxcf.PrecioProveedor;
            

            command = new SqlCommand("insert into MedicamentoxCasaFarmaceutica(IdCasaFarmaceutica,IdMedicamento,PrecioProveedor) VALUES (@IdCasaFarmaceutica,@IdMedicamento,@PrecioProveedor)", conn);

            command.Parameters.Add(IdCasaFarmaceutica);
            command.Parameters.Add(IdMedicamento);
            command.Parameters.Add(PrecioProveedor);

            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}