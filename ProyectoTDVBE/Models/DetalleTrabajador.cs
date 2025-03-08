using System;
using System.Collections.Generic;

namespace ProyectoTDVBE.Models;

public partial class DetalleTrabajador
{
    public int Idtrabajador { get; set; }

    public string Nombre { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Area { get; set; } = null!;

    public string Puesto { get; set; } = null!;

    public decimal Sueldo { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public int Idarea { get; set; }
}
