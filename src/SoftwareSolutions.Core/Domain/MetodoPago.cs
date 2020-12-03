using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string MetodoPago1 { get; set; }
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }

        public virtual Venta Id { get; set; }
    }
}
