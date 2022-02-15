using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_num1
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarEmpresaEmpleado empleados = new MostrarEmpresaEmpleado();
            Console.Write("Digite el identificador de la empresa: ");
            int ide = Convert.ToInt32(Console.ReadLine());
            empleados.GetEmpleadoEmpresas(ide);
            Console.WriteLine("Otros");
            empleados.GetEmpleadosOrdenados();

            //int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //IEnumerable<int> numerosPares = from nums in numeros where nums % 2 == 0 select nums;
            //Console.WriteLine("Numeros pares: ");
            //foreach (int i in numerosPares)
            //{
            //    Console.WriteLine(i);
            //}

            //Libro[] arrayLibro = new Libro[]
            //{
            //    new Libro(1, "Las aventuras de tom soier", "William Shakespeare"),
            //    new Libro(2, "Los asesinos del emperedaor", "Santiago Posteguillo"),
            //    new Libro(3, "Circo Maximo", "Santiago Posteguillo"),
            //    new Libro(4, "Frankestein", "Santiago Posteguillo"),
            //    new Libro(5, "El origen perdido", "Matilde Asensi"),
            //};

            ////Forma 1 de usar Linq
            //var libros = from libro in arrayLibro
            //             where libro.Autor == "Santiago Posteguillo"
            //             select libro;

            //IEnumerable<Libro> libroExten = arrayLibro.Where(a => a.Autor == "Santiago Posteguillo").OrderBy(a => a.Titulo);
            //foreach (Libro i in libros)
            //{
            //    Console.WriteLine($"Nombre del libro : {i.Titulo}, Identificador {i.Id}");
            //}
        }

    }

    class MostrarEmpresaEmpleado
    {
        public List<Empresa> ListaEmpresa;
        public List<Empleado> ListaEmpleado;
        public MostrarEmpresaEmpleado()
        {
            ListaEmpresa = new List<Empresa>();
            ListaEmpleado = new List<Empleado>();

            ListaEmpresa.Add(new Empresa { Id = 1, Nombre = "Google" });
            ListaEmpresa.Add(new Empresa { Id = 2, Nombre = "Globant" });
            ListaEmpleado.Add(new Empleado { Id = 1, Nombre = "Oscar", Cargo = "Junior .Net", EmpresaId = 2, Salario = 2500000 });
            ListaEmpleado.Add(new Empleado { Id = 2, Nombre = "Javier", Cargo = "Collegue Trainee", EmpresaId = 1, Salario = 1500000 });
            ListaEmpleado.Add(new Empleado { Id = 3, Nombre = "Ever", Cargo = "Junior .Net", EmpresaId = 2, Salario = 2500000 });
            ListaEmpleado.Add(new Empleado { Id = 4, Nombre = "Sofia", Cargo = "Collegue Trainee", EmpresaId = 1, Salario = 1500000 });
        }

        public void GetCargos()
        {
            IEnumerable<Empleado> empleado1 = from empleado in ListaEmpleado where empleado.Cargo == "Junior .Net" select empleado;
        }

        public void GetEmpleadosOrdenados()
        {
            IEnumerable<Empleado> empleadoOrden = from empleOrden in ListaEmpleado orderby empleOrden.Cargo 
                                                  descending select empleOrden;

            foreach (Empleado empOrden in empleadoOrden)
            {
                empOrden.getDatosEmpleado();
            }
        }

        public void GetEmpleadoEmpresas(int id)
        {
            IEnumerable<Empleado> empEmpresas = from empleadoEmpre in ListaEmpleado join empresa in ListaEmpresa  
                                                on empleadoEmpre.EmpresaId equals empresa.Id where empresa.Id == id
                                                select empleadoEmpre;

            foreach (Empleado empEmpre in empEmpresas)
            {
                empEmpre.getDatosEmpleado();
            }
        }
    }

    class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void getDatos()
        {
            Console.WriteLine("Empresa {0} con identificador {1}", Nombre, Id);
        }
    }
    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public int EmpresaId { get; set; }

        public void getDatosEmpleado()
        {
            Console.WriteLine("Empleado {0} con identificador {1}, esta en el cargo {2} y tiene un " +
                "salario de {3} y pertenece a la empresa {4}", Nombre, Id, Cargo, Salario, EmpresaId);
        }
    }
}

