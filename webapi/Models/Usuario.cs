using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Usuario1 { get; set; }

    public string? Contrasena { get; set; }

    public int TipoDeUser { get; set; }

    public virtual Tiposuser TipoDeUserNavigation { get; set; } = null!;
}
