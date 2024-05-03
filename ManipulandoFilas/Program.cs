namespace ManipulandoFilas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilaNumero f1 = new FilaNumero();
            FilaNumero f2 = new FilaNumero();
            FilaNumero f3 = new FilaNumero();

            while (true)
            {
                int opcao = Menu();

                switch (opcao)
                {
                    case 1:
                        f1.Enqueue(LerNumero());
                        break;
                    case 2:
                        f2.Enqueue(LerNumero());
                        break;
                    case 3:
                        VerificarIgualdades(f1, f2);
                        break;
                    case 4:
                        GetMaiorMenorMedia(f1, "fila 1");
                        GetMaiorMenorMedia(f2, "fila 2");
                        break;
                    case 5:
                        TrocarFilas(f1, f2, f3);
                        break;
                    case 6:
                        ExibirParesFila(f1, "Fila 1");
                        ExibirParesFila(f2, "Fila 2");
                        break;
                    case 7:
                        ExibirImparesFila(f1, "Fila 1");
                        ExibirImparesFila(f2, "Fila 2");
                        break;
                    case 8:
                        Console.WriteLine("Fila 1");
                        f1.Print();

                        Console.WriteLine("Fila 2");
                        f2.Print();

                        Console.WriteLine("Fila 3");
                        f3.Print();
                        break;
                    case 0: // EXIT
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcao inváida!");
                        break;
                }

                Console.WriteLine("===================================");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }

        }

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("======Fila de numeros======");

            Console.WriteLine("Escolha uma opcao");
            Console.WriteLine("1- Adicionar um numero na fila 1");
            Console.WriteLine("2- Adicionar um numero na fila 2");
            Console.WriteLine("3- Verificar se as filas sao iguais em tamanho");
            Console.WriteLine("4- Maior, menor e media de cada fila");
            Console.WriteLine("5- Transferir numeros de uma fila para uma terceira");
            Console.WriteLine("6- Numeros Pares de cada fila");
            Console.WriteLine("7- Numeros Impares de cada fila");
            Console.WriteLine("8- Exibir todas as filas");
            Console.WriteLine("0- Sair");
            Console.Write("R: ");

            bool conversao = int.TryParse(Console.ReadLine(), out int option);

            if (!conversao)
            {
                Console.WriteLine("Voce deve digitar um numero!");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return Menu();
            }

            return option;
        }

        static void VerificarIgualdades(FilaNumero f1, FilaNumero f2)
        {
            int sizeP1 = f1.GetTamanho();
            int sizeP2 = f2.GetTamanho();

            if (sizeP1 == sizeP2)
            {
                Console.WriteLine("As filas possuem o mesmo tamanho!");
            }
            else if (sizeP1 > sizeP2)
            {
                Console.WriteLine("A fila f1 é maior do que a fila f2!");
            }
            else
            {
                Console.WriteLine("A fila f2 é maior do que a fila f1!");
            }
        }

        static Numero LerNumero()
        {
            Console.WriteLine("======Leitura de numero======");
            Console.WriteLine("Digite o numero que deseja inserir na fila:");
            Console.Write("R: ");

            // Se foi possivel converter, o numero resultante sera armazenado em "opcao"
            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return new Numero(opcao);
            }
            else
            {
                Console.WriteLine("É preciso digitar um numero!");
                return LerNumero();
            }
        }

        static void GetMaiorMenorMedia(FilaNumero fila, string nomeFila)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"-->Fila escolhida: {nomeFila}");

            if (!fila.IsEmpty())
            {
                Console.WriteLine($"-->Menor valor: {fila.GetMenorNumero()}");
                Console.WriteLine($"-->Maior valor: {fila.GetMaiorNumero()}");
                Console.WriteLine($"-->Media: {fila.GetMedia()}");
            }
            else
            {
                Console.WriteLine("-->A fila está vazia!");
            }
        }

        static void TrocarFilas(FilaNumero f1, FilaNumero f2, FilaNumero f3)
        {

            Console.WriteLine("Digite 1 ou 2 para escolher a respectiva fila");
            Console.Write("R: ");

            bool resultadoTry = int.TryParse(Console.ReadLine(), out int opcao);

            if (!resultadoTry)
            {
                Console.WriteLine("Numero inválido!");
                Console.Write("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            if (opcao == 1)
            {
                if (f1.IsEmpty())
                {
                    Console.WriteLine("A fila está vazia!, nao foi possivel transferir");
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                while (!f1.IsEmpty())
                {
                    Numero aux = f1.Dequeue();
                    f3.Enqueue(aux);
                }
                Console.WriteLine("Estado da fila 3:");
                f3.Print();
            }

            else if (opcao == 2)
            {
                if (f2.IsEmpty())
                {
                    Console.WriteLine("A fila está vazia!, nao foi possivel transferir");
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                while (!f2.IsEmpty())
                {
                    Numero aux = f2.Dequeue();
                    f3.Enqueue(aux);
                }

                Console.WriteLine("Estado da fila 3:");
                f3.Print();
            }
        }

        static void ExibirParesFila(FilaNumero fila, string nomeFila)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"-->Fila escolhida: {nomeFila}");

            if (!fila.IsEmpty())
            {
                int qntPares = fila.GetQntPares();
                int[] pares = fila.GetPares();

                Console.WriteLine($"-->Quantidade de pares: {qntPares}");
                Console.Write($"-->");
                for (int i = 0; i < qntPares; i++)
                {
                    Console.Write($"{pares[i]} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("-->A fila está vazia!");
            }
        }

        static void ExibirImparesFila(FilaNumero fila, string nomeFila)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"-->Fila escolhida: {nomeFila}");

            if (!fila.IsEmpty())
            {
                int qntImpares = fila.GetQntImpares();
                int[] impares = fila.GetImpares();

                Console.WriteLine($"-->Quantidade de impares: {qntImpares}");
                Console.Write($"-->");
                for (int i = 0; i < qntImpares; i++)
                {
                    Console.Write($"{impares[i]} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("-->A fila está vazia!");
            }
        }
    }
}
