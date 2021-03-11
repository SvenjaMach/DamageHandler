using DamageHandler.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamageHandler.Infra
{
  public class DamageDbContext : DbContext
  {
    public DbSet<DamageModel> DamageData { get; set; }

    public DamageDbContext(DbContextOptions<DamageDbContext> options) : base(options)
    {
    }
  }
}
