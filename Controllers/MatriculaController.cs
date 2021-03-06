
using AutoMapper;
using CursoDeIngles.Infra.Repository.Interfaces;
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIngles.Controllers
{
    
    [ApiController]
    [Route("api/Matricula")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepository _repository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;
        public MatriculaController(IMatriculaRepository repository, ITurmaRepository turmaRepository, IMapper mapper)
        {
            _repository = repository;
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var MatriculasDTO = await _repository.BuscarMatriculasAsync();

            return MatriculasDTO.Any()
                        ? Ok(MatriculasDTO)
                        : BadRequest("Não tem matricula");
        }
        [HttpGet("{matriculaId}")]
        public async Task<IActionResult> GetById(int matriculaId)
        {
            var matricula = await _repository.BuscarMatriculaIdAsync(matriculaId);

            var matriculaRetorno = _mapper.Map<MatriculaDTO>(matricula);

            return matriculaRetorno != null
                        ? Ok(matriculaRetorno)
                        : BadRequest("Não tem essa matricula");
        } 
        [HttpPost]
        public async Task<IActionResult> Post(MatriculaAdicionarDTO matricula)
        {
            try
            {
                if(matricula == null || (matricula.AlunoId  <=0 || matricula.TurmaId <=0))
                    return BadRequest("Dados invalidos");

                var turma = await _turmaRepository.BuscarTurmaIdAsync(matricula.TurmaId);

                if(turma == null)
                    return BadRequest($"Id da turma {matricula.TurmaId} não existe");

                var turmaValidar = _mapper.Map<Turma>(turma);

                var listaAlunos = turmaValidar.Alunos.Count;
                
                if(listaAlunos >= 5)
                    return BadRequest($"A turma {turmaValidar.Id} chegou em seu limite de 5 alunos");

                var matriculaAdicionar = _mapper.Map<Matricula>(matricula);
                
                _repository.Add(matriculaAdicionar);

                return await _repository.SaveChangesAsync() 
                            ? Ok("Matricula adicionada com sucesso")
                            : BadRequest("Erro ao salvar Matricula");

            }
            catch (System.InvalidOperationException)
            {
                return BadRequest("Matricula já foi cadastrada");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            { 
                return BadRequest("aluno não existe ");
            }

        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
                return BadRequest("Matricula não existe");

            var turmaExcluir = await _repository.BuscarMatriculaIdAsync(id);

            if(turmaExcluir == null) 
                return NotFound("Matricula não encontrado");
            
            _repository.Delete(turmaExcluir);

            return await _repository.SaveChangesAsync()
                                ? Ok("Matricula Excluida com sucesso")
                                : BadRequest("Erro ao excluir Matricula");
        } 
    }
}