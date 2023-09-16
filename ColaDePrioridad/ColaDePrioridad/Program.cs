using EstructurasDinamicas_ColasDePrioridad;
using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {

        // Crear una cola de prioridad
        ColaDePrioridad ColaDePrioridad = new ColaDePrioridad();

        //Visualizacion_ColasDePrioridad.Menu_ColaDePrioridad(ColaDePrioridad);

        List<Solicitud> solicitudes = Visualizacion_ColasDePrioridad.LeerArchivoSolicitudes();

        foreach (Solicitud solicitud in solicitudes)
        {
            ColaDePrioridad.AgregarSolicitud(solicitud);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        List<ColaDePrioridadOrdenadaAlfabeticamente> lotes = new List<ColaDePrioridadOrdenadaAlfabeticamente>();

        List<Solicitud> solicitudes_cola = ColaDePrioridad.ObtenerSolicitudes();

        int Tipos_De_Urgencia = 5;

        for (int i = 1; i < Tipos_De_Urgencia + 1; i++)
        {
            List<Solicitud> lote = new List<Solicitud>();

            int Nivel_De_Urgencia_Actual = i;

            for (int j = 0; j < solicitudes_cola.Count; j++)
            {
                if (Nivel_De_Urgencia_Actual == solicitudes_cola[j].NivelUrgencia)
                {
                    lote.Add(solicitudes_cola[j]);
                }
            }

            ColaDePrioridadOrdenadaAlfabeticamente ColaAlfabetica = new ColaDePrioridadOrdenadaAlfabeticamente();

            foreach (Solicitud solicitud in lote)
            {
                ColaAlfabetica.AgregarSolicitud(solicitud);
            }

            lotes.Add(ColaAlfabetica);
        }

        foreach (ColaDePrioridadOrdenadaAlfabeticamente ColaAlfabetica in lotes)
        {
            ColaAlfabetica.VisualizarSolicitudes();
        }

    }
}