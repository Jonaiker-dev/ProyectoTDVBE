using System;
using System.Collections.Generic;

namespace ProyectoTDVBE.Models;

public partial class Puesto
{
    public int Idpuesto { get; set; }

    public string Nombrepuesto { get; set; } = null!;

    public int Idarea { get; set; }

    public virtual Area IdareaNavigation { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
