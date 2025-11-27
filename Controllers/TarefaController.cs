using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoGerenciadorTarefasAPI.Context;
using ProjetoGerenciadorTarefasAPI.Entidades;

namespace ProjetoGerenciadorTarefasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ListaContext _context;

        public TarefaController(ListaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {

            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar(Tarefa tarefa, int id)
        {

            var tarefaDoBanco = _context.Tarefas.Find(id);
            if (tarefaDoBanco == null)
            {
                return NotFound();
            }

            tarefaDoBanco.Titulo = tarefa.Titulo;
            tarefaDoBanco.Data = tarefa.Data;
            tarefaDoBanco.Descricao = tarefa.Descricao;
            tarefaDoBanco.Status = tarefa.Status;
            

            _context.Tarefas.Update(tarefaDoBanco);
            _context.SaveChanges();
            return Ok(tarefaDoBanco);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Tarefas.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        [HttpGet("ObterPorTitulo/{titulo}")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            return Ok(tarefas);
        }

        [HttpGet("ObterPorData/{data}")]
        public IActionResult ObterPordata(DateOnly data)
        {
            var tarefas = _context.Tarefas.Where(x => x.Data == data);
            return Ok(tarefas);
        }

        [HttpGet("ObterPorStatus/{status}")]
        public IActionResult ObterPorStatus(bool status)
        {
            var tarefas = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefas);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefas = _context.Tarefas.ToList();
            return Ok(tarefas);
        }

    }
}
