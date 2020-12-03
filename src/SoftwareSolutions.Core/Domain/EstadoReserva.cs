using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class EstadoReserva
    {
        public int IdEstadoReserva { get; set; }
        public string EstadoReserva1 { get; set; }
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }

        public virtual Reservas Id { get; set; }
    }
}
