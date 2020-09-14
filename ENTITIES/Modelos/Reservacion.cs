using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Modelos
{
    public class Reservacion
    {
        public int ID_Reservacion { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public string Nombre_Cliente { get; set; }
        public int Cant_Adultos { get; set; }
        public int Cant_Ninos { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Estado { get; set; }
        public string Nombre_Estado { get; set; }
        public int? ID_Cliente { get; set; }
        public List<SGR_Reservaciones_Habitaciones> listaReservacionHabitacion { get; set; }
    }
}
