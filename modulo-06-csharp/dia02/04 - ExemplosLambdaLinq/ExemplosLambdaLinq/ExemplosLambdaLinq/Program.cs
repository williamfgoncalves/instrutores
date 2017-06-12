using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosLambdaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var alunos = new List<string>()
            {
                "Alana Weiss",
                "Alexia Pereira",
                "Bruno Aguiar",
                "Camila Batista",
                "Christopher Michel",
                "Claudia Moura",
                "Deordines Tomazi",
                "Diandra Rocha",
                "Jabel Fontoura",
                "Joao Silva",
                "Jomar Cardoso",
                "Leonardo Alves",
                "Leonardo Morais",
                "Lucas Damaceno",
                "Lucas Gaspar",
                "Lucas Muller",
                "Luis Robinson",
                "Maico Kley",
                "Mateus Silva",
                "Mathias Ody",
                "Mirela Adam",
                "Rafael Barizon",
                "Rafael Barreto",
                "Tais Silva",
                "William Goncalves"
            };

            ExemplosLambdaListaString(alunos);

            var alunosComplexos = new List<Aluno>()
            {
                new Aluno() { Nome = "Alana Weiss", Id = 1 },
                new Aluno() { Nome = "Alexia Pereira", Id = 2 },
                new Aluno() { Nome = "Bruno Aguiar", Id = 3 },
                new Aluno() { Nome = "Camila Batista", Id = 4 },
                new Aluno() { Nome = "Christopher Michel", Id = 5 },
                new Aluno() { Nome = "Claudia Moura", Id = 6 },
                new Aluno() { Nome = "Deordines Tomazi", Id = 7 },
                new Aluno() { Nome = "Diandra Rocha", Id = 1 },
                new Aluno() { Nome = "Jabel Fontoura", Id = 1 },
                new Aluno() { Nome = "Joao Silva", Id = 1 },
                new Aluno() { Nome = "Jomar Cardoso", Id = 1 },
                new Aluno() { Nome = "Leonardo Alves", Id = 1 },
                new Aluno() { Nome = "Leonardo Morais", Id = 1 },
                new Aluno() { Nome = "Lucas Damaceno", Id = 1 },
                new Aluno() { Nome = "Lucas Gaspar", Id = 1 },
                new Aluno() { Nome = "Lucas Muller", Id = 1 },
                new Aluno() { Nome = "Luis Robinson", Id = 1 },
                new Aluno() { Nome = "Maico Kley", Id = 1 },
                new Aluno() { Nome = "Mateus Silva", Id = 1 },
                new Aluno() { Nome = "Mathias Ody", Id = 1 },
                new Aluno() { Nome = "Mirela Adam", Id = 1 },
                new Aluno() { Nome = "Rafael Barizon", Id = 1 },
                new Aluno() { Nome = "Rafael Barreto", Id = 1 },
                new Aluno() { Nome = "Tais Silva", Id = 1 },
                new Aluno() { Nome = "William Goncalves", Id = 1 }
            };

            ExemplosLambdaListaAluno(alunosComplexos);

            Console.ReadKey();
        }

        private static void ExemplosLambdaListaAluno(List<Aluno> alunos)
        {
            var alunoQueContemLetraA =
                alunos.Where(aluno => aluno.Nome.Contains("J"));

            ImprimeAlunos(alunoQueContemLetraA);

            var alunosOrdenadosPorNomeEPorId =
                alunos
                .Where(aluno => aluno.Nome.Contains("J"))
                .OrderBy(aluno => aluno.Nome)
                .ThenBy(aluno => aluno.Id)
                .ToList();

            ImprimeAlunos(alunosOrdenadosPorNomeEPorId);
        }

        private static void ImprimeAlunos(IEnumerable<Aluno> alunos)
        {
            Console.WriteLine("----------------------<br>");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"{aluno.Id} {aluno.Nome}");
            }
        }

        private static void ExemplosLambdaListaString(List<string> alunos)
        {
            var alunoQueContemLetraA =
                alunos.Where(aluno => aluno.Contains("J"));

            var alunoQueContemLetraALinq = 
                from aluno in alunos
                where aluno.Contains("J")
                select aluno;

            ImprimeAlunos(alunoQueContemLetraA);

            var alunosOrdernados =
                alunos
                .Where(aluno => aluno.Contains("e"))
                .OrderBy(aluno => aluno);

            ImprimeAlunos(alunosOrdernados);

            var alunosComDaSilvaNoFinal =
                alunos.Select(aluno => aluno + " da Silva");

            ImprimeAlunos(alunosComDaSilvaNoFinal);

            var alunosProjecao =
                alunos.Select(aluno => new
                {
                    PrimeiroNome = aluno.Split(' ').First(),
                    UltimoNome = aluno.Split(' ').Last()
                });
        }

        private static void ImprimeAlunos(IEnumerable<string> alunos)
        {
            Console.WriteLine("----------------------<br>");
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }
}
