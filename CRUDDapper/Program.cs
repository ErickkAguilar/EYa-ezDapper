using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetAll();
            //Console.WriteLine("");
            //Update();
        }

        public static void Add()
        {
            Alumno alumno = new Alumno();//instancia
            Console.WriteLine("Ingrese el nombre del alumno");
            alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del alumno");
            alumno.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del alumno");
            alumno.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del alumno");
            alumno.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese la matricula del alumno");
            alumno.Matricula = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo del alumno");
            alumno.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el email del alumno");
            alumno.Email = Console.ReadLine();

            Console.WriteLine("Ingrese el idsemetre del alumno");
            alumno.IdSemestre = byte.Parse(Console.ReadLine());

            Resultado resultado = Alumno.Add(alumno);

            if (resultado.Mensaje == "Error")
            {
                Console.WriteLine("Ocurrio un error al ingresar el registro");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Alumno insertado con exito");
                Console.ReadKey();
            }
        }
        public static void GetAll()
        {
            Resultado resultado = Alumno.GetAll();

            if (resultado.Mensaje == "Correcto")
            {
                List<Alumno> list = resultado.Objetos;
                foreach (var item in list)
                {
                    Console.WriteLine(" {IdAlumno}: " + item.IdAlumno);
                    Console.WriteLine(" {Nombre}: " + item.Nombre);
                    Console.WriteLine(" {Apellido Paterno}: " + item.ApellidoPaterno);
                    Console.WriteLine(" {Apellido Materno}: " + item.ApellidoMaterno);
                    Console.WriteLine(" {Fecha Nacimiento}: " + item.FechaNacimiento);
                    Console.WriteLine(" {Matricula}: " + item.Matricula);
                    Console.WriteLine(" {Sexo}: " + item.Sexo);
                    Console.WriteLine(" {Email}: " + item.Email);
                    Console.WriteLine(" {IdSemestre}: " + item.IdSemestre);
                    Console.WriteLine("**********************************");
                }
                Console.ReadKey();
            }
        }

        public static void Delete()
        {
            Alumno alumno = new Alumno();//instancia
            Console.WriteLine("Ingrese el Id del alumno que desea eliminar");
            alumno.IdAlumno = byte.Parse(Console.ReadLine());

            Resultado resultado = Alumno.Delete(alumno);

            if (resultado.Mensaje == "Error")
            {
                Console.WriteLine("Ocurrio un error al eliminar el registro");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Alumno eliminado con exito");
                Console.ReadKey();
            }
        }

        public static void GetById()
        {
            Alumno alumno = new Alumno();//instancia
            Console.WriteLine("Ingrese el Id del alumno que desea observar");
            alumno.IdAlumno = byte.Parse(Console.ReadLine());

            Resultado resultado = Alumno.GetById(alumno);

            if (resultado.Mensaje == "Correcto")
            {
                List<Alumno> list = resultado.Objetos;
                foreach (var item in list)
                {
                    Console.WriteLine(" {IdAlumno}: " + item.IdAlumno);
                    Console.WriteLine(" {Nombre}: " + item.Nombre);
                    Console.WriteLine(" {Apellido Paterno}: " + item.ApellidoPaterno);
                    Console.WriteLine(" {Apellido Materno}: " + item.ApellidoMaterno);
                    Console.WriteLine(" {Fecha Nacimiento}: " + item.FechaNacimiento);
                    Console.WriteLine(" {Matricula}: " + item.Matricula);
                    Console.WriteLine(" {Sexo}: " + item.Sexo);
                    Console.WriteLine(" {Email}: " + item.Email);
                    Console.WriteLine(" {IdSemestre}: " + item.IdSemestre);
                }
                Console.ReadKey();
            }
        }

        public static void Update()
        {
            Alumno alumno = new Alumno();//instancia
            Console.WriteLine("Ingrese el Id del alumno que desea actualizar");
            alumno.IdAlumno = byte.Parse(Console.ReadLine());

            Resultado busqueda = Alumno.GetById(alumno);
            List<Alumno> list = busqueda.Objetos;
            foreach (var item in list)
            {
                Console.WriteLine("Actualice el nombre del alumno: " + item.Nombre);
                alumno.Nombre = Console.ReadLine();

                Console.WriteLine("Actualice el apellido paterno del alumno: " + item.ApellidoPaterno);
                alumno.ApellidoPaterno = Console.ReadLine();

                Console.WriteLine("Actualice el apellido materno del alumno: " + item.ApellidoMaterno);
                alumno.ApellidoMaterno = Console.ReadLine();

                Console.WriteLine("Actualice la fecha de nacimiento del alumno: " + item.FechaNacimiento);
                alumno.FechaNacimiento = Console.ReadLine();

                Console.WriteLine("Actualice la matricula del alumno:" + item.Matricula);
                alumno.Matricula = Console.ReadLine();

                Console.WriteLine("Actualice el sexo del alumno: " + item.Sexo);
                alumno.Sexo = Console.ReadLine();

                Console.WriteLine("Actualice el email del alumno: " + item.Email);
                alumno.Email = Console.ReadLine();

                Console.WriteLine("Actualice el idsemestre del alumno:" + item.IdSemestre);
                alumno.IdSemestre = byte.Parse(Console.ReadLine());
            }
            Resultado resultado = Alumno.Update(alumno);
            if (resultado.Mensaje == "Error")
            {
                Console.WriteLine("Ocurrio un error al actualizar el registro");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Alumno actualizado con exito");
                Console.ReadKey();
            }
        }
    }
}
