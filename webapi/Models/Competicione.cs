using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Competicione
{
    public int IdCompetencia { get; set; }

    public int IdTorneo { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdArtemarcial { get; set; }

    public virtual ICollection<Participante> Participantes { get; set; } = new List<Participante>();
}
