using System;

namespace CRUD
{
    class Program
    {
        static Repositorio repositorio = new Repositorio();
        static void Main(string[] args)
        {
            string opUser = ObterOp();

            while (opUser.ToUpper() != "X")
            {
                switch (opUser)
                {
                    case "1":
                        Listar();
                        break;

                    case "2":
                        Inserir();
                        break;

                    case "3":
                        AtualizarCad();
                        break;

                    case "4":
                        Excluirpessoa();
                        break;

                    case "5":
                        Visualizar();
                        break;
                    
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opUser = ObterOp();
            }
        }

        private static void Listar(){
            Console.WriteLine("Listando pessoas");

            var lista = repositorio.lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nunhuma pessoa cadastrada");
                return;
            }

            foreach (var pessoa in lista)
            {
                var excluido = pessoa.retornaExcluido();
        
                Console.WriteLine($"#ID {pessoa.retornaID()}: - {pessoa.retornarNome()}  {(excluido ? "Excluido*" : "") }");
            }
        }

        private static void Inserir(){
            Console.WriteLine("Inserir Pessoa");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Informe o seu genero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe seu nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Informe o ano de nascimento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Pessoas novaP = new Pessoas(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                nome: entradaNome,
                ano: entradaAno
            );

            repositorio.Inserir(novaP);
        }

        private static void AtualizarCad(){
            Console.Write("Digite id para atualizar: ");
            int idPessoa = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), 1));
            }

            Console.Write("Informe o seu genero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe seu nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Informe o ano de nascimento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Pessoas UpgradeP = new Pessoas(
                id: idPessoa,
                genero: (Genero)entradaGenero,
                nome: entradaNome,
                ano: entradaAno
            );

            repositorio.Atualizar(idPessoa, UpgradeP);
        }

        private static void Excluirpessoa(){
            Console.Write("Digite o id par excluir: ");
            int idPessoa = int.Parse(Console.ReadLine());

            repositorio.Excluir(idPessoa);
        }

        private static void Visualizar(){
            Console.Write("Digite id pra visualizar os dados: ");
            int idPessoa = int.Parse(Console.ReadLine());

            var Person = repositorio.RetornoId(idPessoa);

            Console.WriteLine(Person);
        }

        private static string ObterOp(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar pessoas");
            Console.WriteLine("2- Insserir nova pessoa");
            Console.WriteLine("3- Atualizar cadastro");
            Console.WriteLine("4- Excluir pessoa");
            Console.WriteLine("5- Visualizar dados da pessoa");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opUser;
        }
    }
}
