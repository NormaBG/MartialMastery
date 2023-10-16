using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Organizacione
{
    public int IdOrg { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Torneo> Torneos { get; set; } = new List<Torneo>();
}
