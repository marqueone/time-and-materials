using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Marqueone.TimeAndMaterials.Api.Entities;

namespace Marqueone.TimeAndMaterials.Api.DataAccess
{
  public class TamContext : DbContext
  {
    ILogger<TamContext> _logger;

    public TamContext(DbContextOptions<TamContext> options, ILogger<TamContext> logger) : base(options)
    {
      _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}