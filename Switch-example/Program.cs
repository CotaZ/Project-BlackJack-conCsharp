
using System.Runtime.ExceptionServices;

var (num, platziCoins, totalJugador, totalDealer, message, controlOtraCarta, switchControl) = (0, 0, 0d, 0d, "", "", "menu");

//Blackjack, Juntar 21 cartas, pidiendo en caso de tener menos cartas
//de 21 igual tener mayor puntuación que el dealer.
var deposito = new string[]
{   //BANCO SEGUN RECUERDO DEL MOMENTO
    "Debito BBVA",
    "Debito MATCH",
    "Debito TENPO",
    "Debito BANCO ESTADO",
    "Debito FALABELLA",
    "Debito BANCO BCI",
    "Debito ITAU",
    "Debito VISA",
    "Debito MASTERCARD",
    "Paypal",
    "MercadoPago",
    "BlockChain"
};
var premios = new string[]
{
    "No hay premio",
    "Premio nivel 1",
    "Premio nivel 2",
    "Premio nivel 3"
};

while (true)
{   // Aqui se debe empezar el reseteo del programa, para que no caigamos en el bucle del programa por cada partida finalizada este no sume las cartas anteriores.
    Console.WriteLine("\nWelcome al P L A T Z I N O");
    Console.WriteLine($"\n ¿Cuántos PlatziCoins deseas?:\n\n ¡¡¡Recuerda que necesitas una por ronda!!!\n\n ¡¡¡Solo pueden ser numeros enteros!!!\n");
    // Se debe hacer una conversion
    Console.WriteLine("\nIngresa una cantidad: ");
    platziCoins = int.Parse(Console.ReadLine());
    Console.WriteLine($"\nTotal de PlatziCoins: {platziCoins} ");

    for (int i = 0; i < platziCoins; i++)
    {
        totalJugador = 0;
        totalDealer = 0;

        switch (switchControl)
        {
            case "menu":
                Console.WriteLine("\nEscriba 21 para jugar BlackJack21\n\nEscriba 22 para desbloquear una Sorpresa!!!\n\nEscriba 23 para salir del juego y retirar el deposito.");
                switchControl = Console.ReadLine();
                i = i - 1;
                Console.WriteLine($"\nCantidad de PlatziCoins: {platziCoins}");

                break;

            case "23":
                Console.WriteLine("Has decidido salir y retirar tus PlatziCoins.");
                Console.WriteLine($"Retirando {platziCoins} PlatziCoins...");
                // Metodo tarjeta o Bitcoin
                for (int j = 0; j < deposito.Length; j++)
                {
                    Console.WriteLine($"{j}: {deposito[j]}");
                }
                int depositoElegido = int.Parse(Console.ReadLine());
                Console.WriteLine($"Has elegido el premio: {deposito[depositoElegido]}");
                Environment.Exit(0); // Sale del programa
                break;

            case "22":
                Console.WriteLine("\n¡¡¡Desbloquear premios desde 100 PlatziCoins!!!");

                if (platziCoins >= 100)
                {
                    Console.WriteLine("Has desbloqueado los premios. Elige tu premio:");
                    Console.WriteLine("Puntaje actual del jugador: " + totalJugador);
                    Console.WriteLine("Premios disponibles:");
                    for (int j = 0; j < premios.Length; j++)
                    {
                        Console.WriteLine($"{j}: {premios[j]}");
                    }
                    int premioElegido = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Has elegido el premio: {premios[premioElegido]}");
                    // Restar PlatziCoins al elegir un premio
                    platziCoins -= 100;
                    switchControl = "menu";
                    break;
                }
                else
                {
                    Console.WriteLine("No tienes suficientes PlatziCoins para desbloquear premios.");
                }

                switchControl = "menu";
                break;

            case "21":
                Console.WriteLine("\nEmpieza a jugar!!! \n");

                do
                {
                    System.Random random = new System.Random(); // Otra forma de llamar a la libreria de C# para usar la funciond random.
                    num = random.Next(1, 12);
                    totalJugador = totalJugador + num;
                    Console.WriteLine($"\nToma tu carta, jugador :D \nTe salió el número:{num}");
                    Console.WriteLine("\n¿Deseas otra carta?");
                    controlOtraCarta = Console.ReadLine();

                } while (controlOtraCarta == "Si" || // Factorización del codigo.
                    controlOtraCarta == "si" ||
                    controlOtraCarta == "yes");

                Random rand = new Random(); //Estos son las cartas random del dealer.
                totalDealer = rand.Next(10, 21);

                if (totalJugador == 21)
                {
                    Console.WriteLine($"\n¡Blackjack! Has alcanzado 21 cartas. ¡Ganaste!");
                    platziCoins++;
                    switchControl = "menu";
                    break;
                }
                else if (totalJugador >= 22)
                {
                    message = ($"\nPerdiste por weon, te dije que eran hasta 21 cartas!!!. Puntos = {totalJugador} ");
                    platziCoins--;
                    switchControl = "menu";
                    break;
                }
                else
                {
                    if (totalJugador > totalDealer)
                    {
                        message = ($"\nVenciste al dealer. Puntos = Jugador {totalJugador} vs Dealer {totalDealer}");
                        Console.WriteLine($"\n¡Blackjack! Has alcanzado 21 cartas. ¡Ganaste! ");
                        platziCoins++;
                        switchControl = "menu";
                    }

                    else
                    {
                        message = ($"\nPerdiste vs el dealer, lo siento perdedor. Puntos = Jugador {totalJugador} vs Dealer {totalDealer}");
                        platziCoins--;
                        switchControl = "menu";

                    }
                }
                Console.WriteLine(message);
                break;

            default:
                Console.WriteLine("\nValor ingresado no valido en el P L A T Z I C#");
                switchControl = "menu";
                break;
        }

    }
}
