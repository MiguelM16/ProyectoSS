using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class Domicilios
    {
        public Domicilios()
        {
            EstadoDomicilio = new HashSet<EstadoDomicilio>();
            Productos = new HashSet<Productos>();
        }

        public int IdDomicilio { get; set; }
        public int IdUsuario { get; set; }
        public int IdVenta { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<EstadoDomicilio> EstadoDomicilio { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
