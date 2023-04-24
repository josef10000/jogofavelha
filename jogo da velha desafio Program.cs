using System;

class JogoDaVelha
{
    static char[,] tabuleiro = new char[3, 3];
    static char jogadorAtual;
    static bool contraComputador;
    static Random rand = new Random();

    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao jogo da velha!");

        while (true)
        {
            InicializarTabuleiro();
            jogadorAtual = 'X';
            contraComputador = PerguntarContraComputador();

            while (true)
            {
                Console.Clear();
                DesenharTabuleiro();
                RealizarJogada();
                if (VerificarVitoria())
                {
                    Console.Clear();
                    DesenharTabuleiro();
                    Console.WriteLine("Parabéns, jogador " + jogadorAtual + ", você venceu!");
                    break;
                }
                else if (VerificarEmpate())
                {
                    Console.Clear();
                    DesenharTabuleiro();
                    Console.WriteLine("Empate!");
                    break;
                }
                else
                {
                    jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
                    if (contraComputador && jogadorAtual == 'O')
                    {
                        JogarComputador();
                        jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
                    }
                }
            }

            if (!PerguntarReiniciar())
            {
                break;
            }
        }

        Console.WriteLine("Obrigado por jogar!");
    }

    static void InicializarTabuleiro()
    {
        for (int linha = 0; linha < 3; linha++)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                tabuleiro[linha, coluna] = ' ';
            }
        }
    }

    static void DesenharTabuleiro()
    {
        Console.WriteLine(" " + tabuleiro[0, 0] + " | " + tabuleiro[0, 1] + " | " + tabuleiro[0, 2] + " ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + tabuleiro[1, 0] + " | " + tabuleiro[1, 1] + " | " + tabuleiro[1, 2] + " ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + tabuleiro[2, 0] + " | " + tabuleiro[2, 1] + " | " + tabuleiro[2, 2] + " ");
    }

    static void RealizarJogada()
    {
        Console.WriteLine("É a vez do jogador " + jogadorAtual);
        int linha, coluna;
        do
        {
            Console.Write("Digite a linha (1-3): ");
            linha = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Digite a coluna (1-3): ");
            coluna = int.Parse(Console.ReadLine()) - 1;
        } while (!VerificarJogadaValida(linha, coluna));
        tabuleiro[linha, coluna] = jogadorAtual;
    }

    static bool VerificarJogadaValida(int linha, int coluna)
    {
        if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
        {
            Console.WriteLine("Jogada inválida. A linha e coluna devem estar entre 1 e 3.");
            return false;
        }
        else if (tabuleiro[linha, coluna] != ' ')
        {
            Console.WriteLine("Jogada inválida. Essa posição já está ocupada.");
            return false;
        }
        else
        {
            return true;
        }
    }

    static bool VerificarVitoria()
    {
        // Verificar linhas
        for (int linha = 0; linha < 3; linha++)
        {
            if (tabuleiro[linha, 0] == jogadorAtual && tabuleiro[linha, 1] == jogadorAtual && tabuleiro[linha, 2] == jogadorAtual)
            {
                return true;
            }
        }
        // Verificar colunas
        for (int coluna = 0; coluna < 3; coluna++)
        {
            if (tabuleiro[0, coluna] == jogadorAtual && tabuleiro[1, coluna] == jogadorAtual && tabuleiro[2, coluna] == jogadorAtual)
            {
                return true;
            }
        }
        // Verificar diagonais
        if (tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual)
        {
            return true;
        }
        else if (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool VerificarEmpate()
    {
        for (int linha = 0; linha < 3; linha++)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                if (tabuleiro[linha, coluna] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    static bool PerguntarContraComputador()
    {
        Console.Write("Deseja jogar contra o computador? (S/N) ");
        return Console.ReadLine().ToUpper() == "S";
    }

    static bool PerguntarReiniciar()
    {
        Console.Write("Deseja reiniciar o jogo? (S/N) ");
        return Console.ReadLine().ToUpper() == "S";
    }

    static void JogarComputador()
    {
        Console.WriteLine("Vez do computador");
        int linha, coluna;
        do
        {
            linha = rand.Next(0, 3);
            coluna = rand.Next(0, 3);
        } while (!VerificarJogadaValida(linha, coluna));
        tabuleiro[linha, coluna] = jogadorAtual;
    }
}
