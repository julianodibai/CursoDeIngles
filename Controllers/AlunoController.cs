using CursoDeIngles.Data.Repository.Interfaces;
using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIngles.Controllers
{
    [ApiController]
    [Route("api/Aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        public AlunoController(IAlunoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alunosDTO = await _repository.BuscarAlunosAsync();

            return alunosDTO.Any()
                        ? Ok(alunosDTO)
                        : BadRequest("Não tem alunos");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluno = await _repository.BuscarAlunosIdAsync(id);

            var alunoRetorno = new AlunoDetalhesDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                CPF = aluno.CPF,
                Email = aluno.Email,
                Turmas = aluno.Turmas
            };

            return alunoRetorno != null
                        ? Ok(alunoRetorno)
                        : BadRequest("Não tem alunos");
        }        
    }
}