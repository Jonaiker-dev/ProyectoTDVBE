using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTDVBE.Models;

public partial class Trabajador
{
    public int Idtrabajador { get; set; }

    public string Nombre { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public int Puesto { get; set; }

    public decimal Sueldo { get; set; }

    public DateOnly FechaIngreso { get; set; }
  
    public virtual Puesto? PuestoNavigation{ get; set; } 
}
