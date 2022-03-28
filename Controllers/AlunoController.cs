using AutoMapper;
using CursoDeIngles.Infra.Repository.Interfaces;
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIngles.Controllers
{
    [ApiController]
    [Route("api/Aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;
        public AlunoController(IAlunoRepository repository,IMatriculaRepository matriculaRepository,ITurmaRepository turmaRepository, IMapper mapper)
        {
            _repository = repository;
            _matriculaRepository = matriculaRepository;
            _turmaRepository = turmaRepository;
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
                        : BadRequest($"Não tem o aluno {id}");
        }   
        [HttpPost()]
        public async Task<IActionResult> Post(MatriculaAdicionarAlunoDTO aluno)
        {
            
            if(aluno == null)
                return BadRequest("Dados invalidos");
            
            var turma = await _turmaRepository.BuscarTurmaIdAsync(aluno.TurmaId);

            var turmaValidar = _mapper.Map<Turma>(turma);

            var listaAlunos = turmaValidar.Alunos.Count;
                
            if(listaAlunos >= 5)
                return BadRequest($"A turma {turmaValidar.Id} chegou em seu limite de 5 alunos");

            var alunoAdicionar = _mapper.Map<Aluno>(aluno.AlunoAdicionar);
             
            var verificarCpf = await _repository.VerificarCpfAsync(alunoAdicionar);
            
            if(verificarCpf != null)
                return BadRequest("CPF já existe");
            _repository.Add(alunoAdicionar);
            
            await _repository.SaveChangesAsync();


            var matricuaAlunoAdicionar = new MatriculaAdicionarDTO
            {
                AlunoId = alunoAdicionar.Id,
                TurmaId = aluno.TurmaId
            };

            var matriculaAdicionar = _mapper.Map<Matricula>(matricuaAlunoAdicionar);
            
            _matriculaRepository.Add(matriculaAdicionar);
            
            
            return await _matriculaRepository.SaveChangesAsync()
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
            
            var verificarCpf = await _repository.VerificarCpfAsync(alunoAtualizar);
            
            if(verificarCpf != null)
                return BadRequest("CPF já existe");

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