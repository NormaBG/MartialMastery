using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Tiposdeusuario
{
    public int IdTp { get; set; }

    public string? NombreDelTipo { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
