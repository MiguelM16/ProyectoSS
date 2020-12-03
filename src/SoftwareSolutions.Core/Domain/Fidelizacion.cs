using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class Fidelizacion
    {
        public int IdFidelizacion { get; set; }
        public int NumVisitas { get; set; }
        public int CalidadServicio { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
