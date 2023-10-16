using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Juecestorneo
{
    public int IdAsignacion { get; set; }

    public int? IdTorneo { get; set; }

    public int? IdJuez { get; set; }

    public virtual Juece? IdJuezNavigation { get; set; }

    public virtual Torneo? IdTorneoNavigation { get; set; }
}
