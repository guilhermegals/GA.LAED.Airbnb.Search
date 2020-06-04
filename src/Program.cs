using System;
using System.Diagnostics;

namespace GA.LAED.Airbnb.Search
{
    class Program
    {

        private const string SEQUENTIAL = "Pesquisa Sequencial";
        private const string BINARY = "Pesquisa Binária";
        private const string BINARY_TREE = "Pesquisa Árvore Binária";
        private const string HASH = "Pesquisa Tabela Hash";

        static void Main(string[] args)
        {
            AirbnbRepository airbnbRepository = new AirbnbRepository();
            int option, idRoom;
            do
            {
                Console.Clear();
                Console.WriteLine($"Dados coletados: {airbnbRepository.GetCount()}");
                Console.WriteLine("-------------------");
                Console.WriteLine("Escolha o tipo de pesquisa: ");
                Console.WriteLine("1- Sequencial\n2- Binária\n3- Árvore Binária\n4- Tabela Hash\n\n0- Sair ");
                Console.WriteLine("-------------------");

                // Obtem a opção digitada e caso seja inválida prossegue no loop
                Console.Write("Opção: ");
                bool validOption = int.TryParse(Console.ReadLine(), out option);
                if (!validOption) continue;

                // Obtem o Id Room digitado e caso seja inválida prossegue no loop
                Console.Write("Id Room: ");
                bool validRoom = int.TryParse(Console.ReadLine(), out idRoom);
                if (!validRoom) continue;

                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        // Pesquisa Sequencial
                        Search(SEQUENTIAL, idRoom, airbnbRepository.SequentialSearch);
                        break;

                    case 2:
                        // Pesquisa Binária
                        Search(BINARY, idRoom, airbnbRepository.BinarySearch);
                        break;

                    case 3:
                        // Pesquisa Árvore Binária
                        Search(BINARY_TREE, idRoom, airbnbRepository.BinaryTreeSearch);
                        break;

                    case 4:
                        // Pesquisa Hash
                        Search(HASH, idRoom, airbnbRepository.HashTableSearch);
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("-------------------");
                        break;
                }
                Console.Write("Enter para continuar...");
                Console.ReadKey();
            } while (true);
        }

        #region [ Search ]

        /// <summary>
        /// Delegate de pesquisa
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparsions">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        private delegate Airbnb SearchDelegate(int idRoom, out int comparsions);

        /// <summary>
        /// Efetua a pesquisa pelo delegate e registra seus logs
        /// </summary>
        /// <param name="type">Tipo de Pesquisa</param>
        /// <param name="idRoom">Id Room pesquisado</param>
        /// <param name="searchDelegate">Função de pesquisa</param>
        private static void Search(string type, int idRoom, SearchDelegate searchDelegate)
        {
            Console.Clear();
            Console.Write("Pesquisando...");

            // Salva o horario de início
            DateTime start = DateTime.Now;

            // Inicia o cronômetro
            Stopwatch watch = Stopwatch.StartNew();
            // Invoca o delegate
            Airbnb airbnb = searchDelegate.Invoke(idRoom, out int comparsions);
            // Pausa o cronômetro
            watch.Stop();

            // Salva o horario de término
            DateTime end = DateTime.Now;

            // Converte o tempo do cronômetro para segundos
            double time = watch.ElapsedMilliseconds / 1000.0;

            Console.Clear();
            Console.WriteLine("Pesquisa finalizada");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Tipo: {type}");
            Console.WriteLine($"Comparações: {comparsions}");
            Console.WriteLine($"Tempo: {time} s ({start.ToLongTimeString()} - {end.ToLongTimeString()})");
            Console.WriteLine("-------------------");

            // Mostra o objeto pesquisado
            Console.WriteLine("Objeto: ");
            if (airbnb == null)
            {
                Console.WriteLine("Não encontrado.");
            }
            else
            {
                Console.WriteLine(airbnb.ToString());
            }
            Console.WriteLine("-------------------");
        }

        #endregion
    }
}
