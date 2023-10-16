using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Juece
{
    public int IdJuez { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Edad { get; set; }

    public string? Peleasj { get; set; }

    public virtual ICollection<Juecestorneo> Juecestorneos { get; set; } = new List<Juecestorneo>();

    public virtual ICollection<ResultadosPelea> ResultadosPeleaIdJuezGanadorNavigations { get; set; } = new List<ResultadosPelea>();

    public virtual ICollection<ResultadosPelea> ResultadosPeleaIdJuezPerdedorNavigations { get; set; } = new List<ResultadosPelea>();
}
