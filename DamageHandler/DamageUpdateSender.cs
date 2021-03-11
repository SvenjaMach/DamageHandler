using DamageHandler.ViewModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageHandler
{
  //public class DamageUpdateSender : IDamageUpdateSender
  //{
  //  private readonly string _hostname;
  //  private readonly string _password;
  //  private readonly string _queueName;
  //  private readonly string _username;
  //  private IConnection _connection;

  //  public DamageUpdateSender()
  //  {
  //    _queueName = "damagequeue";
  //    _hostname = "rabbitmq://localhost/";
  //    _username = "guest";
  //    _password = "guest";

  //    CreateConnection();
  //  }

  //  public void SendDamage(DamageModel damage)
  //  {
  //    if (ConnectionExists())
  //    {
  //      using (var channel = _connection.CreateModel())
  //      {
  //        channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

  //        var json = JsonConvert.SerializeObject(damage);
  //        var body = Encoding.UTF8.GetBytes(json);

  //        channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
  //      }
  //    }
  //  }

  //  public void CreateConnection()
  //  {
  //    try
  //    {
  //      var factory = new ConnectionFactory
  //      {
  //        HostName = _hostname,
  //        UserName = _username,
  //        Password = _password
  //      };
  //      _connection = factory.CreateConnection();
  //    }
  //    catch (Exception ex)
  //    {
  //      Console.WriteLine($"Could not create connection: {ex.Message}");
  //    }
  //  }

  //  public bool ConnectionExists()
  //  {
  //    if (_connection != null)
  //    {
  //      return true;
  //    }

  //    CreateConnection();

  //    return _connection != null;
  //  }
  //}
}