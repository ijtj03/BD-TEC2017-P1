using Proyecto1.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class MedicamentoxSucursalService
    {
        public List<MedicamentoxSucursal> GetAllMedicamentoxSucursal()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT * from MedicamentoxSucursal where LogicDelete = 0", conn);
            read = command.ExecuteReader();
            List<MedicamentoxSucursal> ListMedicamentoxSucursal = new List<MedicamentoxSucursal>();
            while (read.Read())
            {
                MedicamentoxSucursal mxs = new MedicamentoxSucursal();
                mxs.IdSucursal = Convert.ToInt32(read["IdSucursal"]);
                mxs.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);
                mxs.PrecioSucursal = Convert.ToInt32(read["PrecioSucursal"]);
                mxs.Logicdelete = Convert.ToBoolean(read["LogicDelete"]);

                ListMedicamentoxSucursal.Add(mxs);

            }
            return ListMedicamentoxSucursal;
        }
        public List<MedicamentoId> GetMedicamentoxSucursal(int idSuc)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("select Medicamento.IdMedicamento,Medicamento.Nombre,MedicamentoxSucursal.Cantidad,MedicamentoxSucursal.PrecioSucursal from MedicamentoxSucursal inner join Medicamento on MedicamentoxSucursal.IdMedicamento=Medicamento.IdMedicamento where MedicamentoxSucursal.Cantidad>0  and  Medicamento.LogicDelete=0 and MedicamentoxSucursal.IdSucursal=" + idSuc.ToString(), conn);
            read = command.ExecuteReader();
            List<MedicamentoId> ListMedicamentoxSucursal = new List<MedicamentoId>();
            while (read.Read())
            {
                MedicamentoId mxs = new MedicamentoId();
                mxs.Cantidad = Convert.ToInt32(read["Cantidad"]);
                mxs.Precio = Convert.ToInt32(read["PrecioSucursal"]);
                mxs.Nombre = Convert.ToString(read["Nombre"]);
                mxs.IdMedicamento = Convert.ToInt32(read["IdMedicamento"]);

                ListMedicamentoxSucursal.Add(mxs);

            }
            return ListMedicamentoxSucursal;
        }
        public void PostMedicamentoxSucursal([FromBody] MedicamentoxSucursal mxs)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdSucursal = new SqlParameter("@IdCasaFarmaceutica", System.Data.SqlDbType.Int);
            IdSucursal.Value = mxs.IdSucursal;

            SqlParameter IdMedicamento = new SqlParameter("@IdMedicamento", System.Data.SqlDbType.Int);
            IdMedicamento.Value = mxs.IdMedicamento;

            SqlParameter PrecioSucursal = new SqlParameter("@PrecioSucursal", System.Data.SqlDbType.Int);
            PrecioSucursal.Value = mxs.PrecioSucursal;



            command = new SqlCommand("insert into MedicamentoxCasaFarmaceutica(IdSucursal,IdMedicamento,PrecioSucursal) VALUES (@IdSucursal,@IdMedicamento,@PrecioSucursal)", conn);

            command.Parameters.Add(IdSucursal);
            command.Parameters.Add(IdMedicamento);
            command.Parameters.Add(PrecioSucursal);

            command.ExecuteNonQuery();

            conn.Close();

        }
        public void UpdateCantidad([FromBody] UpdateCantidad mxs)
        { 
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            
            command = new SqlCommand("update MedicamentoxSucursal set Cantidad = @Cantidad where IdSucursal = @IdSucursal and IdMedicamento = @IdMedicamento", conn);

            command.Parameters.AddWithValue("@IdMedicamento", mxs.IdMedicamento);
            command.Parameters.AddWithValue("@IdSucursal", mxs.IdSucursal);
            command.Parameters.AddWithValue("@Cantidad", mxs.Cantidad);

            command.ExecuteNonQuery();
            command.ExecuteNonQuery();

            conn.Close();

        }

    }
}