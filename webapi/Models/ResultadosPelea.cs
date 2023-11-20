using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class ResultadosPelea
{
    public int IdResultado { get; set; }

    public int? IdTorneo { get; set; }

    public int? IdPelea { get; set; }

    public int? IdJuezGanador { get; set; }

    public int? IdJuezPerdedor { get; set; }

    public TimeSpan? Duracion { get; set; }

    public string? Resultado { get; set; }

    public int? IdParticipacion { get; set; }

    public virtual Juece? IdJuezGanadorNavigation { get; set; }

    public virtual Juece? IdJuezPerdedorNavigation { get; set; }

    public virtual Torneo? IdTorneoNavigation { get; set; }
}
