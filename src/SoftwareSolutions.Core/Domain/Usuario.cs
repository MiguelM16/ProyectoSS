using System;
using System.Collections.Generic;

namespace SoftwareSolutions.Core.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Domicilios = new HashSet<Domicilios>();
            Fidelizacion = new HashSet<Fidelizacion>();
            Reservas = new HashSet<Reservas>();
            Venta = new HashSet<Venta>();
        }

        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string AspnetusersId { get; set; }

        public virtual Aspnetusers Aspnetusers { get; set; }
        public virtual ICollection<Domicilios> Domicilios { get; set; }
        public virtual ICollection<Fidelizacion> Fidelizacion { get; set; }
        public virtual ICollection<Reservas> Reservas { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
