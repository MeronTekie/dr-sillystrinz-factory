using System.Collections.Generic;

namespace Factory.Models
{
  public class MachineEngineer
  {
    public int MachineEngineeId { get; set; }
    public int EngineerId { get; set; }
    public int MachineId { get; set; }
    public virtual Machine Machine { get; set; }
    public virtual Engineer Engineer { get; set; }
  }
}