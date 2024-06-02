using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libreria_clases
{
    public class BDConection
    {
        // establish data for bd
        private static string server = "localhost";
        private static string port = "3306";
        private static string database = "gestor_horas";
        private static string uid = "root";
        private static string password = "VHHmWDiJ";

        private static string conect = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};Pwd={password};";
        private static MySqlConnection cn = new MySqlConnection(conect);

        
        // These functions read database.
        public static List<string> cargarNombresMedicos(string especialidad) // Insert names in a cbo.
        {
            List<string> nombresEmpleados = new List<string>();
            string queryString = "SELECT e_nombre FROM empleados WHERE e_especialidad = @Especialidad";

            MySqlCommand command = new MySqlCommand(queryString, cn);
            command.Parameters.AddWithValue("@Especialidad", especialidad);

            cn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nombre = reader.GetString("e_nombre");
                nombresEmpleados.Add(nombre);
            }

            cn.Close();
            return nombresEmpleados;
        }

        public static List<string> obtenerEspecialidades()
        {
            List<string> especialidades = new List<string>();
            string queryString = "SELECT e_especialidad FROM empleados";

            MySqlCommand command = new MySqlCommand(queryString, cn);

            cn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string especialidad = reader.GetString(0);

                if (!especialidades.Contains(especialidad))
                {
                    especialidades.Add(especialidad);
                }
            }
            cn.Close();
            return especialidades;
        }

        public static Paciente leerDatosPaciente(string Rut)
        {
            if (!existeRut(Rut))
            {
                throw new ArgumentException(string.Format("El paciente no se encuentra registrado en la base de datos"));
            }
            else
            {
                string rut;
                string name;
                string lastname;
                int edad;
                string gender;
                int phone;
                string provicion;

                string queryString = "SELECT p_rut,p_nombre,p_apellido,p_edad,p_genero,p_telefono,p_provicion FROM pacientes WHERE p_rut = @rut";
                MySqlCommand command = new MySqlCommand(queryString,cn);
                command.Parameters.AddWithValue("@rut", Rut);

                cn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                reader.Read();

                rut = reader.GetString(0);
                name = reader.GetString(1);
                lastname = reader.GetString(2);
                edad = reader.GetInt32(3);
                gender = reader.GetString(4);
                phone = reader.GetInt32(5);
                provicion = reader.GetString(6);

                Paciente paciente = new Paciente(rut, name, lastname, edad, gender, phone, provicion);
                cn.Close();
                return paciente;
            }
        }


        // these functions add, delete and update db
        public static string agregarPacientes(Paciente paciente)
        {
            if (existeRut(paciente.getRut))
            {
                throw new ArgumentException(string.Format("El rut del paciente ya se encuentra registrado"));
            }
            else
            {
                string queryString = "INSERT INTO pacientes (p_rut,p_nombre,p_apellido,p_edad,p_genero,p_telefono,p_provicion) VALUES(@rut,@name,@lastname,@edad,@genero,@phone,@provicion)";
                using (MySqlCommand command = new MySqlCommand(queryString, cn))
                {
                    command.Parameters.AddWithValue("@rut", paciente.getRut);
                    command.Parameters.AddWithValue("@name", paciente.getName);
                    command.Parameters.AddWithValue("@lastname", paciente.getLastname);
                    command.Parameters.AddWithValue("@edad", paciente.getEdad);
                    command.Parameters.AddWithValue("@genero", paciente.getGender);
                    command.Parameters.AddWithValue("@phone", paciente.getPhoneNumber);
                    command.Parameters.AddWithValue("@provicion", paciente.getProvicion);

                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                return "";
            }
        }

        public static string actualizarPaciente(Paciente paciente)
        {
            if (!existeRut(paciente.getRut))
            {
                throw new ArgumentException(string.Format("El paciente no se encuentra registrado en la base de datos \n no puede actualizarce"));
            }
            else
            {
                string queryString = "UPDATE pacientes t " +
                    "JOIN pacientes p ON t.p_id = p.p_id " +
                    "SET t.p_nombre = @name," +
                    "t.p_apellido = @lastname," +
                    "t.p_edad = @age," +
                    "t.p_genero = @gender," +
                    "t.p_telefono = @phone," +
                    " t.p_provicion = @provicion " +
                    "WHERE p.p_rut = @rut ";

                using (MySqlCommand command = new MySqlCommand(queryString, cn))
                {
                    command.Parameters.AddWithValue("@rut", paciente.getRut);
                    command.Parameters.AddWithValue("@name", paciente.getName);
                    command.Parameters.AddWithValue("@lastname", paciente.getLastname);
                    command.Parameters.AddWithValue("@age", paciente.getEdad);
                    command.Parameters.AddWithValue("@gender", paciente.getGender);
                    command.Parameters.AddWithValue("@phone", paciente.getPhoneNumber);
                    command.Parameters.AddWithValue("@provicion", paciente.getProvicion);

                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                return "";
            }
        }

        public static string deletePaciente(string rut)
        {
            if (!existeRut(rut))
            {
                throw new ArgumentException(string.Format("El paciente no se encuentra registrado en la base de datos \n no puede eliminarce"));
            }
            else
            {
                string queryString1 = "SELECT p_id FROM pacientes WHERE p_rut = @rut";
                string queryString2 = "DELETE FROM pacientes WHERE p_id = @id";
                int id;

                MySqlCommand command1 = new MySqlCommand(queryString1, cn);
                command1.Parameters.AddWithValue("@rut", rut);

                cn.Open();

                using (MySqlDataReader reader = command1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    else
                    {
                        // Manejar el caso donde no se encuentra el registro
                        throw new Exception("No se encontró el registro con el rut especificado.");
                    }
                }

                MySqlCommand command2 = new MySqlCommand(queryString2, cn);
                command2.Parameters.AddWithValue("@id", id);

                command2.ExecuteNonQuery();

                cn.Close() ;
                return id.ToString();
            }
        }

        public static string insertConsulta(string rut, string nameMedico,Consulta datosConsulta)
        {
            if (!existeRut(rut))
            {
                throw new ArgumentException(string.Format("El rut del paciente no se encuentra registrado"));
            }

            int id_p, id_e;
            DateTime date = datosConsulta.getDate;

            string query1 = "select P_id from pacientes WHERE P_rut = @Rut";
            string query2 = "select e_id from empleados WHERE e_nombre = @EmpleadoName";
            string query3 = "INSERT INTO consulta (e_id,p_id,c_fecha) VALUES(@edi, @pid, @date)";

            cn.Open();

            MySqlCommand command1 = new MySqlCommand(query1, cn);
            command1.Parameters.AddWithValue("@rut", rut);
            using (MySqlDataReader reader = command1.ExecuteReader())
            {
                if (reader.Read())
                {
                    id_p = reader.GetInt32(0);
                }
                else
                {
                    // Manejar el caso donde no se encuentra el registro
                    throw new Exception("No se encontró el registro con el rut especificado.");
                }
            }

            MySqlCommand command2 = new MySqlCommand(query2, cn);
            command2.Parameters.AddWithValue("@EmpleadoName", nameMedico);
            using ( MySqlDataReader reader = command2.ExecuteReader())
            {
                if (reader.Read())
                {
                    id_e = reader.GetInt32(0);
                }
                else
                {
                    throw new Exception("No se encontró el registro del empleado especificado.");
                }
            }

            MySqlCommand command3 = new MySqlCommand(query3,cn);
            command3.Parameters.AddWithValue("@edi",id_e);
            command3.Parameters.AddWithValue("@pid",id_p);
            command3.Parameters.AddWithValue("@date",date);
            command3.ExecuteNonQuery();

            cn.Close();
            return "";
        }


        // verificar rut agregado
        public static bool existeRut(string rut)
        {
            string queryString = "SELECT COUNT(*) FROM pacientes WHERE p_rut = @rut";
            using (MySqlCommand command = new MySqlCommand(queryString,cn))
            {
                cn.Open();
                command.Parameters.AddWithValue("@rut", rut);

                int count = Convert.ToInt32(command.ExecuteScalar());
                cn.Close();

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
        }


    }
}
