using System;
using System.Collections.Generic;

namespace ProyectoTDVBE.Models;

public partial class Login
{
    public int IdLogin { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;
}
