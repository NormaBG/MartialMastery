using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Peleadore
{
    public int IdPeleador { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Edad { get; set; }

    public float? Estatura { get; set; }

    public float? Peso { get; set; }

    public int? Artemarcial { get; set; }

    public int? Cinturon { get; set; }

    public string? Organizacion { get; set; }

    public int? Peleasganadas { get; set; }

    public int? Peleasperdidas { get; set; }

    public virtual Artemarcial? ArtemarcialNavigation { get; set; }

    public virtual Cinturone? CinturonNavigation { get; set; }
}
