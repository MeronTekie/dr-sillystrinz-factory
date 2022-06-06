using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<MachineEngineer>();
    }
    public int MachineId { get; set; }
    [Required]
    public string Name { get; set; }
  
    public string Make { get; set; }
    public string Model { get; set; }
  
    public int Year { get; set; }
    public virtual ICollection<MachineEngineer> JoinEntities { get; set; }
  }
}