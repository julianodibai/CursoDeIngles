using AutoMapper;
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
        private readonly IMapper _mapper;
        public AlunoController(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

            var alunoRetorno = _mapper.Map<AlunoDetalhesDTO>(aluno);

            return alunoRetorno != null
                        ? Ok(alunoRetorno)
                        : BadRequest("Não tem alunos");
        }   
        [HttpPost]
        public async Task<IActionResult> Post(AlunoAdicionarDTO aluno)
        {
            if(aluno == null)
                return BadRequest("Dados invalidos");

            var alunoAdicionar = _mapper.Map<Aluno>(aluno);

            _repository.Add(alunoAdicionar);

            return await _repository.SaveChangesAsync() 
                                        ? Ok("Aluno adicionado com sucesso")
                                        : BadRequest("Erro ao salvar aluno");

        }     
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,AlunoAdicionarDTO aluno)
        {
            if(id <= 0)
                return BadRequest("Aluno não informado");
            
            var alunoDb = await _repository.BuscarAlunosIdAsync(id);

            var alunoAtualizar = _mapper.Map(aluno, alunoDb);

            _repository.Update(alunoAtualizar);

            return await _repository.SaveChangesAsync()
                                ? Ok("Aluno atualizado com sucesso")
                                : BadRequest("Erro ao atualizar aluno");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
                return BadRequest("Aluno não informado");

            var alunoExcluir = await _repository.BuscarAlunosIdAsync(id);

            if(alunoExcluir == null) 
                return NotFound("Aluno não encontrado");
            
            _repository.Delete(alunoExcluir);

            return await _repository.SaveChangesAsync()
                                ? Ok("Aluno Excluido com sucesso")
                                : BadRequest("Erro ao excluir aluno");
        }

        

    }
}