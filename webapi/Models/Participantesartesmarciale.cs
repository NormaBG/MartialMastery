using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Participantesartesmarciale
{
    public int IdParticipanteartemaricial { get; set; }

    public int IdParticipante { get; set; }

    public int IdArtemarcial { get; set; }

    public int IdCinturon { get; set; }

    public virtual Artemarcial IdArtemarcialNavigation { get; set; } = null!;

    public virtual Cinturone IdCinturonNavigation { get; set; } = null!;

    public virtual Participante IdParticipanteNavigation { get; set; } = null!;
}
