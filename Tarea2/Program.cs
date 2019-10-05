using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tarea2
{
    class Program
    {
        static void Main()
        {
            List<Trabajador> listaTrabajadores = new List<Trabajador>();

            string path = @"C:\Users\Erick-PC\Downloads\PrograSistemas\Nomina.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string[] Registro = new string[5];
                        Registro = sr.ReadLine().Split(";");
                        Trabajador RegistradoTrabajador = new Trabajador()
                        {
                            Cedula = Registro[0],
                            Nombre = Registro[1],
                            Salario = Double.Parse(Registro[2]),
                            TipoNomina = Registro[3],
                            Sector = Registro[4]
                        };
                        listaTrabajadores.Add(RegistradoTrabajador);
                        //Console.WriteLine(RegistradoTrabajador.Cedula + " " + RegistradoTrabajador.Nombre + " " + RegistradoTrabajador.Salario + " " +
                        //RegistradoTrabajador.TipoNomina + " " + RegistradoTrabajador.Sector);
                    }
                    //Console.WriteLine(listaTrabajadores.Count);
                }
                
                double salariosAlajuela = listaTrabajadores.FindAll(x => x.Sector == "Alajuela").Sum(x => x.Salario);
                Console.WriteLine("La suma de salarios para la provincia de Alajuela es de: " + salariosAlajuela);
                Console.WriteLine();                

                double TotalAlajuela = listaTrabajadores.FindAll(x => x.Sector == "Alajuela").Sum(x => x.Salario);
                Console.WriteLine("Alajuela: " + TotalAlajuela);
                Console.WriteLine();

                double TotalSanJose = listaTrabajadores.FindAll(x => x.Sector == "San Jose").Sum(x => x.Salario);
                Console.WriteLine("San Jose: " + TotalSanJose);
                Console.WriteLine();

                double TotalHeredia = listaTrabajadores.FindAll(x => x.Sector == "Heredia").Sum(x => x.Salario);
                Console.WriteLine("Heredia: " + TotalHeredia);
                Console.WriteLine();

                double TotalCartago = listaTrabajadores.FindAll(x => x.Sector == "Cartago").Sum(x => x.Salario);
                Console.WriteLine("Cartago: " + TotalCartago);
                Console.WriteLine();

                double TotalPuntarenas = listaTrabajadores.FindAll(x => x.Sector == "Puntarenas").Sum(x => x.Salario);
                Console.WriteLine("Puntarenas: " + TotalPuntarenas);
                Console.WriteLine();

                double promedioTipoB = listaTrabajadores.FindAll(x => x.TipoNomina == "B").Average(x => x.Salario);
                Console.WriteLine("Promedio salarial para los tipo B: " + promedioTipoB);
                Console.WriteLine();

                var respuesta = listaTrabajadores.GroupBy(x => x.TipoNomina).Select(y => new { TipoNomina = y.Key, Quantity = y.Sum(x => x.Salario) });
                Console.WriteLine(respuesta);                
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
