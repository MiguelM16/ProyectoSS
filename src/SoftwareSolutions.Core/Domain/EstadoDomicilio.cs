using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class EstadoDomicilio
    {
        public int IdEstadoDomicilio { get; set; }
        public string EstadoDomicilio1 { get; set; }
        public int IdDomicilio { get; set; }
        public int IdUsuario { get; set; }
        public int IdVenta { get; set; }

        public virtual Domicilios Id { get; set; }
    }
}
