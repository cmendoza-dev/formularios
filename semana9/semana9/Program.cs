using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1. Origen de Datos
            Persona[] personas = {new Persona("Carlos", 20),
                    new Persona("Maria", 18),
                    new Persona("Luis", 22),
                    new Persona("Carmen", 19),
                    new Persona("Ana", 17),
                    new Persona("Patricia", 21)
            };

            //int[] numeros = new int[7] { 1, 2, 3, 4, 5, 6, 7};

            //2. Creación de la consulta
            //IEnumerable<Persona> sql = from p in personas
                                       
                                       //where p.nombre.Contains("a")
                                       //where p.nombre.StartsWith("C") || p.nombre.StartsWith("c")
                                       //select p;

            var sql = from p in personas
                      select p.nombre;

            foreach (string per in sql)
            {
                Console.WriteLine(per);
            }
            Console.ReadKey();


            //IEnumerable<int> lstNumeros = from num in numeros
            //                              orderby num
            //                              select num;


            // var consulta = from num in numeros
            //      where (num % 2 == 0)
            //      select num;

            //List<int> consulta = (from num in numeros
            //                      where (num % 2 == 0)
            //                      select num).ToList();

            //var sql = (from num in numeros
            //                      where (num % 2 == 0)
            //                      select num).ToArray();

            //3. Ejecución de la consulta
            //foreach (Persona per in sql){
            //    Console.WriteLine(per.Imprime());
            //}
            //Console.ReadKey();

            //foreach (int num in lstNumeros)
            //{
            //    Console.WriteLine(num);
            //}
            //Console.ReadKey();
            //Console.WriteLine("------------");
            //foreach (int num in sql)
            //{
            //    Console.WriteLine(num);
            //}
            //Console.ReadKey();

            // int cantidad = consulta.Count();
            //Console.Write(cantidad);
            //Console.ReadKey();


            //foreach (var num in consulta)
            //{
            // Console.WriteLine(num);
            //}
            //Console.ReadLine();
        }
    }
}

