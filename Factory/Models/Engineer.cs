using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Factory.Models
{
  public class Engineer
  {
    
    public Engineer()
    {
      this.JoinEntities = new HashSet<MachineEngineer>();
    }
    public int EngineerId { get; set; }
    [Required]
    public  string Name { get; set; }
    public string Alumni { get; set; }
    public int YearsOfExprience { get; set; }
    public virtual ICollection<MachineEngineer> JoinEntities { get; set; }
  }
}