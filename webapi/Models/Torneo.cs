using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Torneo
{
    public int IdTorneo { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FehcaFin { get; set; }

    public int? Categorias { get; set; }

    public int? Nareas { get; set; }

    public int? IdOrg { get; set; }

    public DateTime? Horario { get; set; }

    public virtual Organizacione? IdOrgNavigation { get; set; }

    public virtual Categoria IdTorneoNavigation { get; set; } = null!;

    public virtual ICollection<Juecestorneo> Juecestorneos { get; set; } = new List<Juecestorneo>();

    public virtual ICollection<ResultadosPelea> ResultadosPeleas { get; set; } = new List<ResultadosPelea>();

    public virtual ICollection<Artemarcial> IdArtemarcials { get; set; } = new List<Artemarcial>();

    public virtual ICollection<Categoria> IdCategoria { get; set; } = new List<Categoria>();
}
