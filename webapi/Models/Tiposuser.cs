using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Tiposuser
{
    public int IdTp { get; set; }

    public string? TipoDeUser { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
