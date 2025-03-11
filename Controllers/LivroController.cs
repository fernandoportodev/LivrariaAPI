using GestaoDeLivraria.Model;
using GestaoDeLivraria.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeLivraria.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _repository = new();

        public LivroController(LivroRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult CriarLivro([FromBody] Livro livro)
        {
            _repository.Adicionar(livro);
            return CreatedAtAction(nameof(ObterLivroPorId), new {id = livro.Id}, livro);
        }

        [HttpGet]
        public IActionResult BuscarTodosLivros()
        {
            var livros = _repository.ObterLivros();
            return Ok(livros);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterLivroPorId(int id)
        {
            var livro = _repository.ObterLivroPorId(id);
            if (livro == null) return NotFound("Livro não encontrado.");
            return Ok(livro);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditarLivro(int id, [FromBody] Livro livro)
        {
            var livroExistente = _repository.ObterLivroPorId(id);
            if (livroExistente == null) return NotFound("Livro não encontrado.");

            livro.Id = id;
            _repository.EditarLivro(id, livro);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarLivro(int id)
        {
            var livro = _repository.ObterLivroPorId(id);
            if (livro == null) return NotFound("Livro não encontrado");

            _repository.DeletarLivro(id);
            return NoContent();
        }
    }
}
