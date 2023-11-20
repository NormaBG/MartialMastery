using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual Torneo? Torneo { get; set; }

    public virtual ICollection<Artemarcial> IdArteMarcials { get; set; } = new List<Artemarcial>();

    public virtual ICollection<Torneo> IdTorneos { get; set; } = new List<Torneo>();
}
