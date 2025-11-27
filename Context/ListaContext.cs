using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoGerenciadorTarefasAPI.Entidades;

namespace ProjetoGerenciadorTarefasAPI.Context
{
    public class ListaContext : DbContext
    {
        public ListaContext(DbContextOptions<ListaContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get;  set; }
    }
}