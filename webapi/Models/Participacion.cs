using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Participacion
{
    public int IdParticipacion { get; set; }

    public int IdPeleador { get; set; }

    public int IdTorneo { get; set; }

    public DateTime FechaDeRegistro { get; set; }

    public virtual Peleadore IdPeleadorNavigation { get; set; } = null!;

    public virtual Torneo IdTorneoNavigation { get; set; } = null!;

    public virtual ICollection<ResultadosPelea> ResultadosPeleas { get; set; } = new List<ResultadosPelea>();
}
