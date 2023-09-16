using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDinamicas_ColasDePrioridad
{
    public class Solicitud
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string DescripcionSolicitud { get; set; }
        public int NivelUrgencia { get; set; }

        public Solicitud(int id, string nombreCliente, string DescripcionSolicitud, int nivelUrgencia)
        {
            this.Id = id;
            this.NombreCliente = nombreCliente;
            this.DescripcionSolicitud = DescripcionSolicitud;
            this.NivelUrgencia = nivelUrgencia;
        }

    }
}
