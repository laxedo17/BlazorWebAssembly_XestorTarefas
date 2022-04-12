using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorWebAssembly_XestorTarefas.Shared;

namespace BlazorWebAssembly_XestorTarefas.Server.Data
{
    public class BlazorWebAssembly_XestorTarefasServerContext : DbContext
    {
        public BlazorWebAssembly_XestorTarefasServerContext (DbContextOptions<BlazorWebAssembly_XestorTarefasServerContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorWebAssembly_XestorTarefas.Shared.TarefaItem> TarefaItem { get; set; }
    }
}
