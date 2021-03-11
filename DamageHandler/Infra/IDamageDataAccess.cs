using DamageHandler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamageHandler.Infra
{
  public interface IDamageDataAccess
  {
    List<DamageModel> GetAllOrder(DamageDbContext context);

    bool SaveDamage(DamageModel damageModel, DamageDbContext context);
    void SaveEnemies(EnemyPositions positions, DamageDbContext context);
    void DeleteEnemy(DamageModel damageModel, DamageDbContext context);
  }
}
