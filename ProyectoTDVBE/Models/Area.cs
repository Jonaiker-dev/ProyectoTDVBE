using System;
using System.Collections.Generic;

namespace ProyectoTDVBE.Models;

public partial class Area
{
    public int Idarea { get; set; }

    public string Nombrearea { get; set; } = null!;

    public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();
}
