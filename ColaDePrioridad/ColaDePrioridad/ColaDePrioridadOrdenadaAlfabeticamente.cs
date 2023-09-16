using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDinamicas_ColasDePrioridad
{
    public class ColaDePrioridadOrdenadaAlfabeticamente
    {
        private List<Solicitud> solicitudes = new List<Solicitud>();
        public Solicitud CrearSolicitud()
        {
            Console.WriteLine("-----------------------------------------------");

            try
            {
                Console.Write("Ingrese el número de solicitud(id): ");
                int numero = int.Parse(Console.ReadLine());


                Console.Write("Ingrese el nombre del cliente: ");
                string nombreCliente = Console.ReadLine();

                Console.Write("Ingrese la descripción de la solicitud: ");
                string DescripcionSolicitud = Console.ReadLine();

                Console.Write("Ingrese el nivel de urgencia: ");
                int nivelUrgencia = int.Parse(Console.ReadLine());

                // Crear una nueva solicitud utilizando el constructor
                Solicitud solicitud = new Solicitud(numero, nombreCliente, DescripcionSolicitud, nivelUrgencia);

                return solicitud;

            }

            catch (FormatException ex)
            {
                Console.WriteLine("Se ha producido la siguiente excepcion: " + ex.Message);
                return CrearSolicitud();
            }

        }

        public void AgregarSolicitud(Solicitud solicitud)
        {
            solicitudes.Add(solicitud);
            solicitudes.Sort((a, b) => string.Compare(a.NombreCliente, b.NombreCliente));
        }

        public Solicitud AtenderSolicitud()
        {
            if (!IsEmpty())
            {
                Solicitud solicitud = solicitudes[0];
                solicitudes.RemoveAt(0);
                return solicitud;
            }

            return null;
        }

        public void VisualizarSolicitudes()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("Solicitudes pendientes en orden de prioridad:");
                foreach (Solicitud solicitud in solicitudes)
                {
                    Console.WriteLine($"Id: {solicitud.Id}, Cliente: {solicitud.NombreCliente}, Descripcion: {solicitud.DescripcionSolicitud}, Urgencia: {solicitud.NivelUrgencia}");
                }
            }

            else
            {
                Console.WriteLine("No hay solicitudes pendientes.");
            }

        }

        public Solicitud SolicitudPrioritaria()
        {
            if (!IsEmpty())
            {
                return solicitudes[0];
            }

            return null;

        }

        public void ActualizarUrgencia()
        {
            try
            {
                if (!IsEmpty())
                {

                    Console.Write("Ingrese el número de solicitud (id) que desea actualizar: ");
                    int id_solicitud = int.Parse(Console.ReadLine());

                    // Buscar la solicitud por número
                    Solicitud solicitud = solicitudes.Find(solicitud => solicitud.Id == id_solicitud);

                    if (solicitud != null)
                    {
                        Console.Write("Ingrese el nuevo nivel de urgencia: ");
                        int nuevoNivelUrgencia = int.Parse(Console.ReadLine());

                        // Actualizar el nivel de urgencia
                        solicitudes.Remove(solicitud);

                        // Se actualiza en la lista solicitudes
                        solicitud.NivelUrgencia = nuevoNivelUrgencia;
                        AgregarSolicitud(solicitud);

                        Console.WriteLine("Urgencia actualizada con éxito.");

                    }

                    else
                    {
                        Console.WriteLine("Solicitud no encontrada.");
                    }

                }

                else
                {
                    Console.WriteLine("No hay solicitudes");
                }

            }

            catch (FormatException ex)
            {
                Console.WriteLine("Se ha producido la siguiente excepcion: " + ex.Message);
                ActualizarUrgencia();
            }

        }

        public bool IsEmpty()
        {
            return solicitudes.Count == 0;
        }

    }
}
