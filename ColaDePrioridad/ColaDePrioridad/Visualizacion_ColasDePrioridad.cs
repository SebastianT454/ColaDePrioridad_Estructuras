using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDinamicas_ColasDePrioridad
{
    public static class Visualizacion_ColasDePrioridad
    {
        /*
        public static void Menu_ColaDePrioridad(ColaDePrioridad cola)
        {
            while (true)
            {

                Console.WriteLine("Menú:");
                Console.WriteLine("1. Agregar solicitud");
                Console.WriteLine("2. Atender solicitud");
                Console.WriteLine("3. Visualizar solicitudes pendientes");
                Console.WriteLine("4. Actualizar urgencia de una solicitud");
                Console.WriteLine("5. Comparacion de Complejidades");
                Console.WriteLine("6. Salir");
                Console.Write("Ingrese la opción deseada: ");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        cola.AgregarSolicitud(cola.CrearSolicitud());
                        Console.WriteLine("-----------------------------------------------");
                        break;
                    case 2:
                        cola.AtenderSolicitud();
                        Console.WriteLine("-----------------------------------------------");
                        break;
                    case 3:
                        cola.VisualizarSolicitudes();
                        Console.WriteLine("-----------------------------------------------");
                        break;
                    case 4:
                        cola.ActualizarUrgencia();
                        Console.WriteLine("-----------------------------------------------");
                        break;
                    case 5:
                        Visualizacion_ColasDePrioridad.Comparacion_Complejidades(cola);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                        Console.WriteLine("-----------------------------------------------");
                        break;
                }
            }
        }
        */

        public static List<Solicitud> LeerArchivoSolicitudes()
        {
            string filePath = @"C:\Users\Sebastian\source\repos\ColaDePrioridad_temp\ColaDePrioridad_temp\solicitudes.txt"; // Ruta al archivo con las solicitudes
            List<Solicitud> solicitudes = new List<Solicitud>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        int id = int.Parse(parts[0]);
                        string nombreCliente = parts[1].Trim();
                        string descripcion = parts[2].Trim();
                        int nivelUrgencia = int.Parse(parts[3]);
                        Solicitud solicitud = new Solicitud(id, nombreCliente, descripcion, nivelUrgencia);
                        solicitudes.Add(solicitud);
                    }
                    else
                    {
                        Console.WriteLine("Error: El formato de cada línea no es válido.");
                    }
                }

                return solicitudes;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return solicitudes;
            }
        }

        public static void Comparacion_Complejidades(ColaDePrioridad colaDePrioridad)
        {
            // Leer el archivo de solicitudes

            List<Solicitud> solicitudes = Visualizacion_ColasDePrioridad.LeerArchivoSolicitudes();

            // Medir el tiempo de ejecución para agregar las solicitudes
            Stopwatch stopwatchAgregar = new Stopwatch();
            stopwatchAgregar.Start();

            // Agregar las solicitudes a la cola de prioridad
            foreach (Solicitud solicitud in solicitudes)
            {
                //Console.WriteLine($"Agregando solicitud #{solicitud.Id} - Nivel de Urgencia: {solicitud.NivelUrgencia}");
                colaDePrioridad.AgregarSolicitud(solicitud);
            }

            stopwatchAgregar.Stop();
            long elapsedMillisecondsAgregar = stopwatchAgregar.ElapsedMilliseconds;

            // Medir el tiempo de ejecución para atender las solicitudes
            Stopwatch stopwatchAtender = new Stopwatch();
            stopwatchAtender.Start();

            // Atender las solicitudes
            while (!colaDePrioridad.IsEmpty())
            {
                Solicitud solicitudAtendida = colaDePrioridad.AtenderSolicitud();
                //Console.WriteLine($"Atendiendo solicitud #{solicitudAtendida.Id} - Nivel de Urgencia: {solicitudAtendida.NivelUrgencia}");
            }

            stopwatchAtender.Stop();
            long elapsedMillisecondsAtender = stopwatchAtender.ElapsedMilliseconds;

            // Calcular la suma de los tiempos
            long tiempoTotalMilliseconds = elapsedMillisecondsAgregar + elapsedMillisecondsAtender;
            double tiempoTotalSeconds = tiempoTotalMilliseconds / 1000.0; // Convertir a segundos

            Console.WriteLine($"Tiempo total (agregado + atendido): {tiempoTotalMilliseconds} ms");
            Console.WriteLine($"Tiempo total (agregado + atendido): {tiempoTotalSeconds} segundos");
        }

    }

}
