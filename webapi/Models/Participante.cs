using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Participante
{
    public int IdParticipante { get; set; }

    public int IdCompetencia { get; set; }

    public string? Nombreparticipante { get; set; }

    public virtual Competicione IdCompetenciaNavigation { get; set; } = null!;

    public virtual ICollection<Participantesartesmarciale> Participantesartesmarciales { get; set; } = new List<Participantesartesmarciale>();
}
