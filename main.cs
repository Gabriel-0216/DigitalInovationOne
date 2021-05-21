using System;

namespace DIO.Series
{
    class main
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "0")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSeries();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;
                    case "9":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
               OpcaoUsuario = ObterOpcaoUsuario();
            }
            


        }

        private static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine("Listando todas as séries...");
            var lista = repositorio.lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não tem nenhuma série cadastrada no sistema!");
                Console.ReadLine();
                return;
            }
                foreach(var serie in lista)
                {
                    Console.WriteLine("#ID da série: {0}: Nome da série: {1}", serie.retornaId(), serie.retornaTitulo());       
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void InserirSeries()
        {
            Console.Clear();
            Console.WriteLine("Inserindo uma nova série no registro...");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima:");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome da série:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano que a série começou:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            string descricao = Console.ReadLine();

            Serie nova = new Serie(Id: repositorio.ProximoId(), genero: (Genero)genero,
                Titulo: titulo, Ano: ano, Descricao: descricao);
            repositorio.Inserir(nova);
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void AtualizarSerie()
        {
            Console.Clear();
            ListarSeries();
            Console.WriteLine("Digite o ID da série que deseja atualizar:");
            int indice = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima:");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome da série:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano que a série começou:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            string descricao = Console.ReadLine();

            Serie atualizacao = new Serie(Id: indice, genero: (Genero)genero,
                Titulo: titulo, Ano: ano, Descricao: descricao);
            repositorio.Atualiza(indice,atualizacao);

        }

        private static void ExcluirSerie()
        {
            Console.Clear();
            ListarSeries();
            Console.ReadLine();
            Console.WriteLine("QUAL SÉRIE DESEJA APAGAR?");
            int id = int.Parse(Console.ReadLine());
            repositorio.Excluir(id);

        }
        private static void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("Digite o ID da série a ser visualizada");
            int indice = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(indice);
            Console.WriteLine(serie);
            Console.WriteLine();
            Console.ReadLine();

        }

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao cadastro de séries");
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1. LISTAR TODAS AS SÉRIES");
            Console.WriteLine("2. INSERIR UMA NOVA SÉRIE NO REGISTRO");
            Console.WriteLine("3. ATUALIZAR AS INFORMAÇÕES DE UMA SÉRIE");
            Console.WriteLine("4. EXCLUIR UMA SÉRIE DO REGISTRO");
            Console.WriteLine("5. VISUALIZAR UMA SÉRIE");
            Console.WriteLine("9. LIMPAR A TELA");
            Console.WriteLine("0. SAIR DO SISTEMA");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
