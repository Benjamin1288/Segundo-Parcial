int[,] tablero = new int[10, 10];
void paso1_crear_tablero()
{
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            tablero[i, c] = 0;

        }
    }
}
void paso2()
{
    tablero[4, 3] = 1;
    tablero[1, 1] = 1;
    tablero[2, 1] = 1;
    tablero[3, 4] = 1;
    tablero[0, 0] = 1;
    tablero[1, 9] = 1;
    tablero[7, 1] = 1;
    tablero[6, 6] = 1;
    tablero[5, 5] = 3;
    tablero[9, 9] = 1;
    tablero[8, 4] = 1;
}

void paso3()
{
    string caracterA = "";
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            switch (tablero[i, c])
            {
                case 0:
                    caracterA = "-";
                    break;
                case 1:
                    caracterA = "-";
                    break;
                case 2:
                    caracterA = "*";
                    break;
                case 3:
                    caracterA = "-";
                    break;
                case 4:
                    caracterA = "B";
                    break;
                case -1:
                    caracterA = "X";
                    break;
                default:
                    caracterA = "-";
                    break;
            }
            Console.Write(caracterA + " ");
        }
        Console.WriteLine();
    }
}
void paso4()
{
    int fila, columna;
    int intentos = 0;
    int bueno = 0, nuc = 0;
    Boolean fin = true, nuclear = true;
    Console.Clear();
    do
    {
        try 
        { 
        Console.Write("Ingresa la fila: ");
        fila = int.Parse(Console.ReadLine());
        Console.Write("Ingresa la columna: ");
        columna = int.Parse(Console.ReadLine());

        if (tablero[fila, columna] == 1)
        {
            Console.Beep();
            tablero[fila, columna] = 2;
            bueno++;
        }
        else if (tablero[fila, columna] == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(1000, 100);
            }
            tablero[fila, columna] = 4;
            tablero[4, 3] = -1;
            tablero[1, 1] = -1;
            tablero[2, 1] = -1;
            tablero[3, 4] = -1;
            tablero[0, 0] = -1;
            tablero[1, 9] = -1;
            tablero[7, 1] = -1;
            tablero[6, 6] = -1;
            tablero[9, 9] = -1;
            tablero[8, 4] = -1;
            nuc++;
        }
        else
        {
            tablero[fila, columna] = -1;
        }
        //paso 6 
        Console.Clear();
        //Paso 5
        if (tablero[fila, columna] == 2)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("  Golpeo un barco");
            Console.WriteLine("-------------------");
        }
        else if (tablero[fila, columna] == 4)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("       Boom");
            Console.WriteLine("-------------------");
        }
        else
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("      Fallo");
            Console.WriteLine("-------------------");

        }
        paso3();
        intentos++;
        //Paso 8
        if (bueno == 10)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Felicidades ganaste");
            Console.WriteLine("Te llevo " + intentos + " intentos");
            if (intentos == 10)
            {
                Console.WriteLine("Clasificacion: S");
            }
            else if (intentos <= 12)
            {
                Console.WriteLine("Clasificacion: A");
            }
            else if (intentos <= 14)
            {
                Console.WriteLine("Clasificacion: B");
            }
            else if (intentos <= 16)
            {
                Console.WriteLine("Clasificacion: C");
            }
            else if (intentos <= 18)
            {
                Console.WriteLine("Clasificacion: D");
            }
            else
            {
                Console.WriteLine("No vuelvas a jugar");
            }
            Console.WriteLine("-------------------");
            fin = false;
        }
        if (nuc == 1)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine(" Le diste a una bomba nuclear, todos los barcos fueron eliminados");
            Console.WriteLine(" pero el alcanze llego a tu base y mato a tus tropas");
            Console.WriteLine(" Nadie Gana");
            Console.WriteLine("-------------------------------------------------------------------");
            nuclear = false;
        }
        }
        catch (Exception Error)
        {
            Console.WriteLine("Ha ocurrido un error");
            Console.WriteLine("ingreso un numero alto o el programa detecto un caracter no valido" + Error.Message);
        }
    } while (fin && nuclear);
}
paso1_crear_tablero();
paso2();
paso3();
paso4();