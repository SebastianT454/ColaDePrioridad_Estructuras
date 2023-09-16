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

        Visualizacion_ColasDePrioridad.Menu_ColaDePrioridad(ColaDePrioridad);

    }
}