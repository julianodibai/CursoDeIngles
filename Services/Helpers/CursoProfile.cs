using AutoMapper;
using CursoDeIngles.Services.DTOs;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Services.Helpers
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<Aluno, AlunoDTO>();
            CreateMap<Aluno, AlunoDetalhesDTO>();
            CreateMap<AlunoAdicionarDTO, Aluno>()
                    .ForAllMembers(
                        opts => opts.Condition(
                                        (src, dest, srcMember)
                                        => srcMember != null     
                        )
                    );
            CreateMap<Matricula, MatriculaDTO>();
            CreateMap<Matricula, MatriculaDetalhesDTO>();
            CreateMap<MatriculaAdicionarDTO, Matricula>()
                    .ForAllMembers(
                        opts => opts.Condition(
                                        (src, dest, srcMember)
                                        => srcMember != null     
                        )
                    );
            CreateMap<MatriculaAdicionarAlunoDTO, Matricula>()
                    .ForAllMembers(
                        opts => opts.Condition(
                                        (src, dest, srcMember)
                                        => srcMember != null     
                        )
                    );

            CreateMap<Turma, TurmaDTO>();
            CreateMap<Turma, TurmaIdDTO>();
            CreateMap<Turma, TurmaDetalhesDTO>();
            CreateMap<TurmaAdicionarDTO, Turma>()
                    .ForAllMembers(
                        opts => opts.Condition(
                                        (src, dest, srcMember)
                                        => srcMember != null     
                        )
                    );

        }
    }
}