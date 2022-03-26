using AutoMapper;
using CursoDeIngles.Models.DTOs;
using CursoDeIngles.Models.DTOs.Turma;
using CursoDeIngles.Models.Entities;

namespace CursoDeIngles.Helpers
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<Aluno, AlunoDetalhesDTO>();
            CreateMap<AlunoAdicionarDTO, Aluno>()
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
            CreateMap<MatriculaAlunoDTO, Matricula>()
                    .ForMember(
                        dest => dest.Turma,
                        opt => opt.Ignore()

                    );
            CreateMap<Matricula, MatriculaAlunoDTO>()
                    .ForMember(
                        dest => dest.Turma,
                        opt => opt.MapFrom(src => src.Turma.Id)
                    );
        }
    }
}