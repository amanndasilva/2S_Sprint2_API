using System;
using System.Collections.Generic;

namespace Nyous_API.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public bool Confirmado { get; set; }
        public int IdUsuario { get; set; }
        public int IdEvento { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
