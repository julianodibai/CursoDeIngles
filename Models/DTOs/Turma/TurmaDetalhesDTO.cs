using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDeIngles.Models.DTOs
{
    public class TurmaDetalhesDTO
    {
        public int Id { get; set; }
        public string Nivel { get; set; }
        public DateTime AnoLetivo { get; set; }
        public List<AlunoDTO> Alunos { get; set; }
    }
}