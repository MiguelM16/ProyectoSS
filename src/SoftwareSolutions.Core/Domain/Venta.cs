using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class Venta
    {
        public Venta()
        {
            MetodoPagoNavigation = new HashSet<MetodoPago>();
            Productos = new HashSet<Productos>();
        }

        public int IdVenta { get; set; }
        public string ValorVenta { get; set; }
        public string MetodoPago { get; set; }
        public int Cantidad { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<MetodoPago> MetodoPagoNavigation { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
