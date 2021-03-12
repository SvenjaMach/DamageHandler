using DamageHandler.Infra;
using DamageHandler.ViewModel;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using rabbitmq;
using rabbitmq_damagemessage;
using System;
using System.Threading.Tasks;

namespace DamageHandler.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DamageController : ControllerBase
  {
    private readonly DamageDbContext _context;
    private readonly ISendEndpointProvider _sendEndpointProvider; 
    private readonly IDamageDataAccess _damageDataAccess;

    public DamageController(
      ISendEndpointProvider sendEndpointProvider, IDamageDataAccess damageDataAccess, DamageDbContext context)
    {
      _sendEndpointProvider = sendEndpointProvider;
      _damageDataAccess = damageDataAccess;
      _context = context;
    }

    [HttpPost]
    [Route("createdamage")]
    public BoolHelper CreateDamage([FromBody] DamageModel damageModel)
    {
      BoolHelper helper = new BoolHelper();
      helper.isDead = false;
      if(_damageDataAccess.SaveDamage(damageModel, _context))
      {
        var endPoint = _sendEndpointProvider.
            GetSendEndpoint(new Uri("queue:" + BusConstants.OrderQueue)).Result;

        endPoint.Send<IEnemyMessage>(new
        {
          MessageId = 0,
          Count = 1,
          EnemySort = damageModel.EnemySort
        });

        _damageDataAccess.DeleteEnemy(damageModel, _context);
        helper.isDead = true;
      }

      return helper;
    }

    [HttpPost]
    [Route("createenemies")]
    public void CreateEnemies([FromBody] EnemyPositions positions)
    {
      _damageDataAccess.SaveEnemies(positions, _context);
    }
  }
}
