using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;

namespace Proyecto1.Services
{
    public class PersonaService
    {
        public List<Persona> GetAllPersonas()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Persona", conn);
            read = command.ExecuteReader();

            List<Persona> ListPersonas = new List<Persona>();
            while (read.Read())
            {
                Persona persona = new Persona();
                persona.IdCedula = Convert.ToInt32(read["IdCedula"]);
                persona.Nombre = read["Nombre"].ToString();
                persona.Apellido1 = read["Apellido1"].ToString();
                persona.Apellido2 = read["Apellido2"].ToString();
                persona.Telefono = Convert.ToInt32(read["Telefono"]);
                persona.Contraseña = read["Contraseña"].ToString();
                persona.Provincia = read["Provincia"].ToString();
                persona.Canton = read["Canton"].ToString();
                persona.Distrito = read["Distrito"].ToString();
                persona.DescripcionDireccion = read["DescripcionDireccion"].ToString();
                persona.FechaNacimiento = Convert.ToDateTime(read["FechaNacimiento"]);
                persona.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);

                ListPersonas.Add(persona);
                
            }
            read.Close();
            conn.Close();
            return ListPersonas;
        }

        public void UpdatePersona([FromBody] Persona persona)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            //conn = new SqlConnection("Data Source=MELENDEZ-JEISON\\SQLEXPRESS;Initial Catalog=Proyecto1;Integrated Security=True");
            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            String comm = "Update Persona SET Contraseña=\'" + persona.Contraseña + "\',Telefono=\'" + persona.Telefono +
                "\',DescripcionDireccion=\'" + persona.DescripcionDireccion + "\',Provincia=\'"+persona.Provincia+"\'" +
                ",Canton=\'"+persona.Canton+"\',Distrito=\'"+persona.Distrito+"\' WHERE IdCedula=" + persona.IdCedula;
            

            command = new SqlCommand(comm,conn);

            command.ExecuteNonQuery();
            conn.Close();



        }

        public Persona GetPersona(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT *  from Persona where IdCedula="+id.ToString(), conn);
            read = command.ExecuteReader();

            Persona persona = new Persona();
            while (read.Read())
            {
                persona.IdCedula = Convert.ToInt32(read["IdCedula"]);
                persona.Nombre = read["Nombre"].ToString();
                persona.Apellido1 = read["Apellido1"].ToString();
                persona.Apellido2 = read["Apellido2"].ToString();
                persona.Telefono = Convert.ToInt32(read["Telefono"]);
                persona.Contraseña = read["Contraseña"].ToString();
                persona.Provincia = read["Provincia"].ToString();
                persona.Canton = read["Canton"].ToString();
                persona.Distrito = read["Distrito"].ToString();
                persona.DescripcionDireccion = read["DescripcionDireccion"].ToString();
                persona.FechaNacimiento = Convert.ToDateTime(read["FechaNacimiento"]);
                persona.LogicDelete = Convert.ToBoolean(read["LogicDelete"]);
            }
            read.Close();
            conn.Close();
            return persona;
        }

        public void DeletePersona([FromBody] int cedula)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            Console.WriteLine("Porqui estuvo el dato");
            command = new SqlCommand("UPDATE Persona SET LogicDelete = 1  WHERE IdCedula=" + cedula.ToString(), conn);
            command.ExecuteNonQuery();
            conn.Close();

        }


        public void EliminarEmpleadosxSucursal([FromBody]int id) {

            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            /**command = new SqlCommand("UPDATE PS SET PS.IdSucursal = -1 FROM Persona AS P INNER JOIN PersonaxSucursal AS PS ON P.IdCedula = PS.IdCedula INNER JOIN Sucursal AS S ON S.IdSucursal = PS.IdSucursal INNER JOIN Empresa AS E ON E.IdEmpresa = S.IdEmpresa WHERE S.IdSucursal=" + id.ToString(), conn);
            command.ExecuteNonQuery();*/
            command = new SqlCommand("UPDATE P SET P.LogicDelete = 1 FROM Persona AS P INNER JOIN PersonaxSucursal AS PS ON P.IdCedula = PS.IdCedula INNER JOIN Sucursal AS S ON S.IdSucursal = PS.IdSucursal INNER JOIN Empresa AS E ON E.IdEmpresa = S.IdEmpresa WHERE S.IdSucursal =" + id.ToString(), conn);
            command.ExecuteNonQuery();
            conn.Close();

        }

        public void BorrarPersona([FromBody]Persona persona)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=MELENDEZ-JEISON\\SQLEXPRESS;Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = persona.IdCedula;

            command = new SqlCommand("UPDATE Persona SET LogicDelete = 1  WHERE IdCedula=@IdCedula", conn);
            command.Parameters.Add(IdCedula);
            command.ExecuteNonQuery();
            conn.Close();

        }


        public void PostPersona([FromBody] Persona persona)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            SqlParameter IdCedula = new SqlParameter("@IdCedula", System.Data.SqlDbType.Int);
            IdCedula.Value = persona.IdCedula;

            SqlParameter Nombre = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
            Nombre.Value = persona.Nombre;

            SqlParameter Apellido1 = new SqlParameter("@Apellido1", System.Data.SqlDbType.VarChar);
            Apellido1.Value = persona.Apellido1;

            SqlParameter Apellido2 = new SqlParameter("@Apellido2", System.Data.SqlDbType.VarChar);
            Apellido2.Value = persona.Apellido2;

            SqlParameter Telefono = new SqlParameter("@Telefono", System.Data.SqlDbType.Int);
            Telefono.Value = persona.Telefono;

            SqlParameter Contraseña = new SqlParameter("@Contraseña", System.Data.SqlDbType.VarChar);
            Contraseña.Value = persona.Contraseña;

            SqlParameter Provincia = new SqlParameter("@Provincia", System.Data.SqlDbType.VarChar);
            Provincia.Value = persona.Provincia;

            SqlParameter Canton = new SqlParameter("@Canton", System.Data.SqlDbType.VarChar);
            Canton.Value = persona.Canton;

            SqlParameter Distrito = new SqlParameter("@Distrito", System.Data.SqlDbType.VarChar);
            Distrito.Value = persona.Distrito;

            SqlParameter DescripcionDireccion = new SqlParameter("@DescripcionDireccion", System.Data.SqlDbType.VarChar);
            DescripcionDireccion.Value = persona.DescripcionDireccion;

            SqlParameter FechaNacimiento = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.Date);
            FechaNacimiento.Value = Convert.ToDateTime(persona.FechaNacimiento);
            
            command = new SqlCommand("insert into Persona(IdCedula,Nombre,Apellido1,Apellido2,Telefono,Contraseña,Provincia,Canton,Distrito,DescripcionDireccion,FechaNacimiento) VALUES (@IdCedula,@Nombre,@Apellido1,@Apellido2,@Telefono,@Contraseña,@Provincia,@Canton,@Distrito,@DescripcionDireccion,@FechaNacimiento)", conn);
            command.Parameters.Add(IdCedula);
            command.Parameters.Add(Nombre);
            command.Parameters.Add(Apellido1);
            command.Parameters.Add(Apellido2);
            command.Parameters.Add(Telefono);
            command.Parameters.Add(Contraseña);
            command.Parameters.Add(Provincia);
            command.Parameters.Add(Canton);
            command.Parameters.Add(Distrito);
            command.Parameters.Add(DescripcionDireccion);
            command.Parameters.Add(FechaNacimiento);

            command.ExecuteNonQuery();

            conn.Close();

        }

        public bool SignInVerification(int id, string contraseña)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            
            command = new SqlCommand("SELECT Contraseña from Persona WHERE IdCedula="+id.ToString()+" and LogicDelete=0", conn);

            read = command.ExecuteReader();

            string valor = "";
            
            while (read.Read())
            {
                valor = read["Contraseña"].ToString();
 
            }

            if (contraseña == valor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool SignInSucursalVerification(int id, string contraseña)
        {

            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();


            command = new SqlCommand("SELECT Persona.Contraseña FROM Persona INNER JOIN PersonaxRol ON Persona.IdCedula=PersonaxRol.IdCedula INNER JOIN Rol ON PersonaxRol.IdRol=Rol.IdRol WHERE Rol.Nombre != 'Administrador' AND Rol.Nombre != 'Cliente' AND Persona.LogicDelete!=1 AND Persona.IdCedula =" + id.ToString(), conn);

            read = command.ExecuteReader();

            string valor = "";

            while (read.Read())
            {
                valor = read["Contraseña"].ToString();

            }

            if (contraseña == valor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SignInAdministradorVerification(int id, string contraseña)
        {

            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();


            command = new SqlCommand("SELECT Persona.Contraseña FROM Persona INNER JOIN PersonaxRol ON Persona.IdCedula=PersonaxRol.IdCedula INNER JOIN Rol ON PersonaxRol.IdRol=Rol.IdRol WHERE Rol.Nombre = 'Administrador' AND Persona.LogicDelete!=1 AND Persona.IdCedula =" + id.ToString(), conn);

            read = command.ExecuteReader();

            string valor = "";

            while (read.Read())
            {
                valor = read["Contraseña"].ToString();

            }

            if (contraseña == valor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetSucursalPersona(int id)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();

            command = new SqlCommand("SELECT Sucursal.IdSucursal FROM Sucursal WHERE LogicDelete!=1 AND Administrador=" + id.ToString(), conn);

            read = command.ExecuteReader();

            int sucursal = 0;

            while (read.Read())
            {
                sucursal = Convert.ToInt32(read["IdSucursal"]);
            }


            return sucursal;

        }

        public List<String> GetAllAdministrador()
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT P.Nombre FROM Persona AS P INNER JOIN PersonaxRol AS PR ON  P.IdCedula = PR.IdCedula INNER JOIN Rol AS R ON PR.IdRol = R.IdRol WHERE R.Nombre = 'Administrador' and P.LogicDelete = 0", conn);
            read = command.ExecuteReader();

            List<String> ListPersonas = new List<String>();
            while (read.Read())
            {
                String Nombre = read["Nombre"].ToString();
                ListPersonas.Add(Nombre);

            }
            read.Close();
            conn.Close();
            return ListPersonas;
        }

        public int GetIdPersona(String nombre)
        {
            System.Data.SqlClient.SqlConnection conn;
            SqlCommand command;
            SqlDataReader read;

            conn = new SqlConnection("Data Source=(local);Initial Catalog=Proyecto1;Integrated Security=True");
            conn.Open();
            command = new SqlCommand("SELECT IdCedula FROM Persona WHERE LogicDelete = 0 and Nombre ='"+ nombre+"'", conn);
            read = command.ExecuteReader();

            int cedula = -1;
            while (read.Read())
            {
                cedula = Convert.ToInt32(read["IdCedula"]);

            }
            read.Close();
            conn.Close();
            return cedula;
        }


    }
}
