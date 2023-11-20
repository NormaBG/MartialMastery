using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Cinturone
{
    public int IdCinturon { get; set; }

    public int IdArtemarcial { get; set; }

    public string Color { get; set; } = null!;

    public virtual Artemarcial IdArtemarcialNavigation { get; set; } = null!;

    public virtual ICollection<Participantesartesmarciale> Participantesartesmarciales { get; set; } = new List<Participantesartesmarciale>();

    public virtual ICollection<Peleadore> Peleadores { get; set; } = new List<Peleadore>();
}
