using CursoDeIngles.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIngles.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        public AlunoController(IAlunoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repository.BuscarAlunos();

            return alunos.Any()
                        ? Ok(alunos)
                        : BadRequest("Não tem alunos");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.BuscarAlunosId(id);

            return aluno != null
                        ? Ok(aluno)
                        : BadRequest("Não tem alunos");
        }        
    }
}