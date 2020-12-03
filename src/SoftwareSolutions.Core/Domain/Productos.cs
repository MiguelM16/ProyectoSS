using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class Productos
    {
        public int IdProductos { get; set; }
        public string NombreProducto { get; set; }
        public string ValorUnitario { get; set; }
        public int TipoProducto { get; set; }
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdDomicilio { get; set; }

        public virtual Venta Id { get; set; }
        public virtual Domicilios IdNavigation { get; set; }
    }
}
