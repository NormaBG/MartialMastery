using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Artemarcial
{
    public int IdArtemarcial { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Cinturone> Cinturones { get; set; } = new List<Cinturone>();

    public virtual ICollection<Participantesartesmarciale> Participantesartesmarciales { get; set; } = new List<Participantesartesmarciale>();

    public virtual ICollection<Peleadore> Peleadores { get; set; } = new List<Peleadore>();

    public virtual ICollection<Categoria> IdCategoria { get; set; } = new List<Categoria>();

    public virtual ICollection<Torneo> IdTorneos { get; set; } = new List<Torneo>();
}
