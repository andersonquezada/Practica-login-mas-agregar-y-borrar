

using System;
using System.Collections.Generic; 

class eje3
{
    public static void Main(string[] args)
    {

        List<string> alumnos = new List<string> { "Juan Perez", "Maria Garcia" };

        while (true)
        {
            Console.WriteLine("--- SISTEMA DE GESTIÓN ESCOLAR ---");
            Console.WriteLine("Ingrese su rol (1-Admin, 2-Maestro, 3-Alumno, 0-Salir):");

            if (!int.TryParse(Console.ReadLine(), out int rol))
            {
                Console.WriteLine("Error: Ingrese un número válido.");
                continue;
            }

            if (rol == 0) break;

            if (rol == 1) 
            {
                string userCorrecto = "admin";
                int passCorrecto = 1234;

                Console.Write("Usuario: ");
                string userIngresado = Console.ReadLine();
                Console.Write("Password: ");

                if (int.TryParse(Console.ReadLine(), out int passIngresado) && userIngresado == userCorrecto && passIngresado == passCorrecto)
                {
                    Console.WriteLine("\n--- MENU ADMIN ---");
                    Console.WriteLine("1. Ver lista de alumnos");
                    Console.WriteLine("2. Agregar alumno");
                    Console.WriteLine("3. Eliminar alumno");
                    string op = Console.ReadLine();

                    if (op == "1")
                    {
                        Console.WriteLine("Lista actual de alumnos:");
                        for (int i = 0; i < alumnos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {alumnos[i]}");
                        }
                    }
                    else if (op == "2")
                    {
                        Console.Write("Nombre del nuevo alumno: ");
                        string nuevo = Console.ReadLine();
                        alumnos.Add(nuevo);
                        Console.WriteLine(">> Alumno agregado con éxito.");
                    }
                    else if (op == "3")
                    {
                        Console.WriteLine("\nSeleccione el número del alumno a eliminar:");
                        for (int i = 0; i < alumnos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {alumnos[i]}");
                        }

                        if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= alumnos.Count)
                        {
                            alumnos.RemoveAt(indice - 1);
                            Console.WriteLine(">> Alumno eliminado.");
                        }
                        else { Console.WriteLine(">> Índice inválido."); }
                    }
                    else { Console.WriteLine(">> Opción inválida."); }
                }
                else { Console.WriteLine(">> Credenciales incorrectas."); }
            }
            else if (rol == 2) 
            {

                string userMaestro = "Maestro";
                int passMaestro = 5678;

                Console.Write("Usuario: ");
                string userIngresado = Console.ReadLine();
                Console.Write("Password: ");

                if (int.TryParse(Console.ReadLine(), out int passIngresado) && userIngresado == userMaestro && passIngresado == passMaestro)


                    Console.WriteLine("--- LISTA DE ALUMNOS PARA EL MAESTRO ---");
                foreach (var alu in alumnos) Console.WriteLine("- " + alu);
                Console.WriteLine("1. Ver notas | 2. Editar notas");
                Console.ReadLine(); 
            }
            else if (rol == 3) 
            {

                string userAlumno = "Alumno";
                int passAlumno = 1357;

                Console.Write("Usuario: ");
                string userIngresado = Console.ReadLine();
                Console.Write("Password: ");

                if (int.TryParse(Console.ReadLine(), out int passIngresado) && userIngresado == userAlumno && passIngresado == passAlumno)




                    Console.WriteLine("--- BIENVENIDO ALUMNO ---");
                Console.WriteLine("Solo puedes ver tus datos.");
            }
            else
            {
                Console.WriteLine(">> Rol no reconocido.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}














