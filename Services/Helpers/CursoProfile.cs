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
                              /*  .ForMember(
                                        dest => dest.Turmas,
                                        opt => opt.MapFrom(
                                            src => src.Turmas
                                                .Select(t => t.Id)
                                                .ToArray()
                                                    
                                            
                                        )
                                );*/
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
                    /*.ForMember(
                        dest => dest.AlunoId,
                        opt => opt.Ignore()

                    )*/
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
           /* CreateMap<Matricula, MatriculaDetalhesDTO>()
                    .ForMember(
                        dest => dest.AlunoTurma,
                        opt => opt.MapFrom(src => src.Turma.Id)
                    );
            CreateMap<MatriculaAdicionarDTO, Matricula>()
                     .ForMember(
                        dest => dest.Turma,
                        opt => opt.Ignore()

                    )
                    .ForAllMembers(
                        opts => opts.Condition(
                                        (src, dest, srcMember)
                                        => srcMember != null     
                        )
                    );


            /*CreateMap<MatriculaAlunoDTO, Matricula>()
                    .ForMember(
                        dest => dest.Turma,
                        opt => opt.Ignore()

                    );
            CreateMap<Matricula, MatriculaAlunoDTO>()
                    .ForMember(
                        dest => dest.Turma,
                        opt => opt.MapFrom(src => src.Turma.Id)
                    );*/

        }
    }
}