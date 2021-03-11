using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamageHandler.ViewModel
{
  public class DamageModel
  {
    [Key]
    public int EnemyID { get; set; }
    public int Lifepoints { get; set; }
    public int EnemySort { get; set; }
  }
}
