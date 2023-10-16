using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Torneo
{
    public int IdTorneo { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Categorias { get; set; }

    public int? Nareas { get; set; }

    public int? IdOrg { get; set; }

    public TimeSpan? Horario { get; set; }

    public virtual Organizacione? IdOrgNavigation { get; set; }

    public virtual ICollection<Juecestorneo> Juecestorneos { get; set; } = new List<Juecestorneo>();

    public virtual ICollection<Participacion> Participacions { get; set; } = new List<Participacion>();

    public virtual ICollection<ResultadosPelea> ResultadosPeleas { get; set; } = new List<ResultadosPelea>();
}
