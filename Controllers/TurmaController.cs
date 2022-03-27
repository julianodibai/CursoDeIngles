
using AutoMapper;
using CursoDeIngles.Data.Repository.Interfaces;
using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIngles.Controllers
{
    [ApiController]
    [Route("api/Turma")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repository;
        private readonly IMapper _mapper;
        public TurmaController(ITurmaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var turmasDTO = await _repository.BuscarTurmasAsync();

            return turmasDTO.Any()
                        ? Ok(turmasDTO)
                        : BadRequest("Não tem turmas");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var turma = await _repository.BuscarTurmaIdAsync(id);

            var turmaRetorno = _mapper.Map<TurmaDetalhesDTO>(turma);

            return turmaRetorno != null
                        ? Ok(turmaRetorno)
                        : BadRequest("Não tem essa turma");
        }   
        [HttpPost]
        public async Task<IActionResult> Post(TurmaAdicionarDTO turma)
        {
            if(turma == null)
                return BadRequest("Dados invalidos");

            var turmaAdicionar = _mapper.Map<Turma>(turma);

            _repository.Add(turmaAdicionar);

            return await _repository.SaveChangesAsync() 
                                        ? Ok("Turma adicionada com sucesso")
                                        : BadRequest("Erro ao salvar turma");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,TurmaAdicionarDTO turma)
        {
            if(id <= 0)
                return BadRequest("Turma não existe");
            
            var turmaDb = await _repository.BuscarTurmaIdAsync(id);

            var turmaAtualizar = _mapper.Map(turma, turmaDb);

            _repository.Update(turmaAtualizar);

            return await _repository.SaveChangesAsync()
                                ? Ok("Turma atualizado com sucesso")
                                : BadRequest("Erro ao atualizar turma");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
                return BadRequest("Turma não existe");

            var turmaExcluir = await _repository.BuscarTurmaIdAsync(id);

            if(turmaExcluir == null) 
                return NotFound("Turma não encontrado");
            
            _repository.Delete(turmaExcluir);

            return await _repository.SaveChangesAsync()
                                ? Ok("Turma Excluida com sucesso")
                                : BadRequest("Erro ao excluir turma");
        } 
    }
}