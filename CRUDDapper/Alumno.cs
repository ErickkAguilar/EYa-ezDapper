using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapper
{
    public class Alumno
    {
        public int IdAlumno { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string FechaNacimiento { get; set; }

        public string Matricula { get; set; }

        public string Sexo { get; set; }

        public string Email { get; set; }

        public int IdSemestre { get; set; }

        public static Resultado Add(Alumno alumno)
        {
            Resultado resultado = new Resultado();

            try
            {
                using (var context = new SqlConnection(Conexion.getConexion()))
                {
                    var query = context.Execute($"AlumnoAdd '{alumno.Nombre}','{alumno.ApellidoPaterno}','{alumno.ApellidoMaterno}','{alumno.FechaNacimiento}','{alumno.Matricula}','{alumno.Sexo}','{alumno.Email}','{alumno.IdSemestre}'");

                    if (query > 0)
                    {
                        resultado.Mensaje = "Correcto";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }
            return resultado;
        }
        public static Resultado GetAll()
        {
            Resultado resultado = new Resultado();
            try
            {
                using (var context = new SqlConnection(Conexion.getConexion()))
                {
                    var query = context.Query<Alumno>($"AlumnoGetAll");

                    resultado.Objetos = new List<Alumno>();
                    if (query != null)
                    {
                        foreach(var item in query)
                        {
                            resultado.Objetos.Add(item);
                        }
                        resultado.Mensaje = "Correcto";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }
            return resultado;
        }

        public static Resultado Delete(Alumno alumno)
        {
            Resultado resultado = new Resultado();

            try
            {
                using (var context = new SqlConnection(Conexion.getConexion()))
                {
                    var query = context.Execute($"AlumnoRemove '{alumno.IdAlumno}'");

                    if (query > 0)
                    {
                        resultado.Mensaje = "Correcto";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }
            return resultado;
        }

        public static Resultado Update(Alumno alumno)
        {
            Resultado resultado = new Resultado();

            try
            {
                using (var context = new SqlConnection(Conexion.getConexion()))
                {
                    var query = context.Execute($"AlumnoUpdate '{alumno.IdAlumno}', '{alumno.Nombre}','{alumno.ApellidoPaterno}','{alumno.ApellidoMaterno}','{alumno.FechaNacimiento}','{alumno.Matricula}','{alumno.Sexo}','{alumno.Email}','{alumno.IdSemestre}'");

                    if (query > 0)
                    {
                        resultado.Mensaje = "Correcto";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Mensaje = "Error" + ex;
            }
            return resultado;
        }

        public IEnumerable<Alumno> Byid(Alumno alumno)
        {
            Resultado resultado = new Resultado();

                using (var context = new SqlConnection(Conexion.getConexion()))
                {
                    var query = context.Query<Alumno>($"AlumnoGetById '{alumno.IdAlumno}'");
                    return query;
                }
        }
    }
}
