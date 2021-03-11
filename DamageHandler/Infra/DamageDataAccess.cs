using DamageHandler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamageHandler.Infra
{
  public class DamageDataAccess : IDamageDataAccess
  {
    public List<ViewModel.DamageModel> GetAllOrder(DamageDbContext context)
    {
      return context.DamageData.ToList();
    }

    public bool SaveDamage(DamageModel order, DamageDbContext context)
    {
      bool isDead = false;
      if(order.Lifepoints>=10)
      {
        context.Add<DamageModel>(new DamageModel() { EnemyID = order.EnemyID, Lifepoints = 10 });
      }
      else
      {
        var result = context.Find<DamageModel>(order.EnemyID);
        DamageModel temp;
        try
        {
          temp = context.DamageData.First(a => a.EnemyID == order.EnemyID);
        }
        catch
        {
          return false;
        }
        if (temp != null)
        {
          temp.Lifepoints -= order.Lifepoints;
          if(temp.Lifepoints<=0)
          {
            isDead = true;
          }
          context.SaveChanges();
        }
      }

      return isDead;
    }

    public void SaveEnemies(EnemyPositions positions, DamageDbContext context)
    {
      foreach(Enemy enemy in positions.Enemies)
      {
        context.Add<DamageModel>(new DamageModel() { EnemyID = enemy.Id, Lifepoints = 10 });
      }

      context.SaveChanges();
    }

    public void DeleteEnemy(DamageModel orderModel, DamageDbContext context)
    {
      context.Remove(context.DamageData.Single(a => a.EnemyID == orderModel.EnemyID));
      context.SaveChanges();
    }
  }
}
