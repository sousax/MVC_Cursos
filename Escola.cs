using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Escola
    {
        public Curso[] Cursos { get; set; } = new Curso[5];

        public bool AdicionarCurso(Curso curso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] == null)
                {
                    Cursos[i] = curso;
                    return true;
                }
            }
            return false;
        }

        public Curso PesquisarCurso(int idCurso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == idCurso)
                {
                    return Cursos[i];
                }
            }
            return null;
        }

        public bool RemoverCurso(int idCurso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == idCurso)
                {
                    // Verifica se não há disciplinas associadas
                    bool temDisciplinas = false;
                    for (int j = 0; j < Cursos[i].Disciplinas.Length; j++)
                    {
                        if (Cursos[i].Disciplinas[j] != null)
                        {
                            temDisciplinas = true;
                            break;
                        }
                    }
                    if (!temDisciplinas)
                    {
                        Cursos[i] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public void PesquisarAluno(string nomeAluno)
        {
            bool alunoEncontrado = false;

            // Itera sobre cada curso 
            for (int i = 0; i < Cursos.Length; i++)
            {
                // Verifica se o curso existe
                if (Cursos[i] != null)
                {
                    // Itera sobre cada disciplina do curso
                    for (int j = 0; j < Cursos[i].Disciplinas.Length; j++)
                    {
                        // Verifica se a disciplina na posição j  existe
                        if (Cursos[i].Disciplinas[j] != null)
                        {
                            // Itera sobre cada aluno da disciplina
                            for (int k = 0; k < Cursos[i].Disciplinas[j].Alunos.Length; k++)
                            {
                                // Verifica se o aluno na posição k não é nulo e se o nome do aluno corresponde ao nome procurado
                                if (Cursos[i].Disciplinas[j].Alunos[k] != null && Cursos[i].Disciplinas[j].Alunos[k].Nome == nomeAluno)
                                {
                                    // Se o aluno for encontrado, imprime uma mensagem informando a disciplina em que ele está matriculado
                                    Console.WriteLine($"\nAluno {nomeAluno} está matriculado na disciplina {Cursos[i].Disciplinas[j].Descricao}.");
                                    Console.WriteLine("-----------------------------------------");
                                    alunoEncontrado = true;
                                }
                            }
                        }
                    }
                }
            }
            // Se o aluno não foi encontrado em nenhuma disciplina
            if (!alunoEncontrado)
            {
                Console.WriteLine($"\nAluno {nomeAluno} não encontrado em nenhuma disciplina.");
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
}
