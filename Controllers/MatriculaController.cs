
using AutoMapper;
using CursoDeIngles.Data.Repository.Interfaces;
using CursoDeIngles.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIngles.Controllers
{
    
    [ApiController]
    [Route("api/Matricula")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepository _repository;
        private readonly IMapper _mapper;
        public MatriculaController(IMatriculaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /*[HttpGet]
        public async Task<IActionResult> Get()
        {
            var MatriculasDTO = await _repository.BuscarMatriculasAsync();

            return MatriculasDTO.Any()
                        ? Ok(MatriculasDTO)
                        : BadRequest("Não tem matricula");
        }*/
        [HttpGet("{alunoId}")]
        public async Task<IActionResult> GetById(int alunoId)
        {
            var aluno = await _repository.BuscarMatriculaIdAsync(alunoId);

            var alunoRetorno = _mapper.Map<MatriculaDTO>(aluno);

            return alunoRetorno != null
                        ? Ok(alunoRetorno)
                        : BadRequest("Não tem alunos");
        } 
        /*[HttpPost]
        public async Task<IActionResult> Post(MatriculaAdicionarDTO matricula)
        {
            if(matricula == null)
                return BadRequest("Dados invalidos");

            var matriculaAdicionar = _mapper.Map<Matricula>(matricula);

            _repository.Add(matriculaAdicionar);

            return await _repository.SaveChangesAsync() 
                                        ? Ok("Matricula adicionada com sucesso")
                                        : BadRequest("Erro ao salvar Matricula");

        }  */
    }
}