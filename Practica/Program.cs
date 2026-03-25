

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














using System;

namespace SistemaNotasEstudiantes
{
    class Program
    {
        // Definimos las variables globales para que las funciones puedan acceder a ellas
        static string[] nombres = new string[10];
        static double[] notas = new double[10];
        static int cantidadEstudiantes = 0;

        static void Main(string[] args)
        {
            RegistrarDatos();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("--- MENÚ DE OPCIONES ---");
                Console.WriteLine("1. Mostrar todos los estudiantes");
                Console.WriteLine("2. Calcular promedio del grupo");
                Console.WriteLine("3. Mostrar estudiante con mayor nota");
                Console.WriteLine("4. Mostrar estudiante con menor nota");
                Console.WriteLine("5. Contar estudiantes aprobados y reprobados");
                Console.WriteLine("6. Buscar estudiante por nombre");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: MostrarEstudiantes(); break;
                    case 2: CalcularPromedioGeneral(); break;
                    case 3: MostrarNotaExtrema(true); break; // true para mayor
                    case 4: MostrarNotaExtrema(false); break; // false para menor
                    case 5: ContarAprobadosReprobados(); break;
                    case 6: BuscarEstudiante(); break;
                    case 7: Console.WriteLine("Saliendo del sistema..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }

                if (opcion != 7)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 7);
        }

        // 1. Función para registrar datos
        static void RegistrarDatos()
        {
            do
            {
                Console.Write("Ingrese la cantidad de estudiantes (Máximo 10): ");
            } while (!int.TryParse(Console.ReadLine(), out cantidadEstudiantes) || cantidadEstudiantes < 1 || cantidadEstudiantes > 10);

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.Write($"\nNombre del estudiante {i + 1}: ");
                nombres[i] = Console.ReadLine();

                double nota;
                do
                {
                    Console.Write($"Nota final de {nombres[i]} (0 a 10): ");
                } while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10);
                notas[i] = nota;
            }
        }

        // 2. Función para mostrar estudiantes
        static void MostrarEstudiantes()
        {
            Console.WriteLine("\n--- Lista de Estudiantes ---");
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - Nota: {notas[i]}");
            }
        }

        // 3. Función para calcular promedio
        static void CalcularPromedioGeneral()
        {
            double suma = 0;
            for (int i = 0; i < cantidadEstudiantes; i++) suma += notas[i];
            double promedio = suma / cantidadEstudiantes;
            Console.WriteLine($"\nEl promedio general del grupo es: {promedio:F2}");
        }

        // 4. Función para Nota Mayor y Menor
        static void MostrarNotaExtrema(bool buscarMayor)
        {
            double extrema = notas[0];
            int indice = 0;

            for (int i = 1; i < cantidadEstudiantes; i++)
            {
                if (buscarMayor ? notas[i] > extrema : notas[i] < extrema)
                {
                    extrema = notas[i];
                    indice = i;
                }
            }
            string tipo = buscarMayor ? "mayor" : "menor";
            Console.WriteLine($"\nEstudiante con la {tipo} nota: {nombres[indice]} ({notas[indice]})");
        }

        // 5. Función Aprobados y Reprobados
        static void ContarAprobadosReprobados()
        {
            int aprobados = 0, reprobados = 0;
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                if (notas[i] >= 6) aprobados++;
                else reprobados++;
            }
            Console.WriteLine($"\nAprobados (Nota >= 6): {aprobados}");
            Console.WriteLine($"Reprobados: {reprobados}");
        }

        // 6. Función para buscar estudiante
        static void BuscarEstudiante()
        {
            Console.Write("\nIngrese el nombre a buscar: ");
            string buscar = Console.ReadLine();
            bool encontrado = false;

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                if (nombres[i].Equals(buscar, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Resultado: {nombres[i]} tiene una nota de {notas[i]}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado) Console.WriteLine("Mensaje: El estudiante no se encuentra en el registro.");
        }
    }
}
