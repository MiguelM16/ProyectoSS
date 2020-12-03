using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class Reservas
    {
        public Reservas()
        {
            EstadoReserva = new HashSet<EstadoReserva>();
        }

        public int IdReserva { get; set; }
        public int? NumPersonas { get; set; }
        public string NumMesa { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<EstadoReserva> EstadoReserva { get; set; }
    }
}
