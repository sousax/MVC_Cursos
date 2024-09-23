using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public bool PodeMatricular(Curso curso)
        {
            int disciplinasMatriculadas = 0;

            foreach (var disciplina in curso.Disciplinas)
            {
                bool alunoMatriculadoNaDisciplina = false;

                // Verifica cada aluno na disciplina
                for (int i = 0; i < disciplina.Alunos.Length; i++)
                {
                    // Verifica se tem um aluno na posição i
                    if (disciplina.Alunos[i] != null)
                    {
                        // Compara o ID do aluno com o ID que ta tentando se matricular
                        if (disciplina.Alunos[i].Id == this.Id)
                        {
                            // Se o aluno for encontrado, marca como matriculado
                            alunoMatriculadoNaDisciplina = true;
                            break; // Sai do loop, pois já encontramos o aluno
                        }
                    }
                }

                // Se o aluno estiver matriculado nessa disciplina, incrementa o contador
                if (alunoMatriculadoNaDisciplina)
                {
                    disciplinasMatriculadas++;
                }
            }

            // Ve se as disciplinas matriculadas é menor que 6
            return disciplinasMatriculadas < 6;
        }

    }
}
