using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería GAG2223
    public class loto
    {
        // Definición de constantes
        private const int mAX_NUMEROS = 6;
        private const int nUMERO_MENOR = 1;
        private const int nUMERO_MAYOR = 49;

        // Numeros de la combinación
        private int[] numerosCombinacion = new int[MAX_NUMEROS];

        // Combinación válida (si es aleatoria, siempre es válida, sino, no tiene porqué)
        private bool esValida = false;

        public int[] Premiados
        {
            get => numerosCombinacion;
            set => numerosCombinacion = value;
        }

        public static int MAX_NUMEROS => mAX_NUMEROS;

        public static int NUMERO_MENOR => nUMERO_MENOR;

        public static int NUMERO_MAYOR => nUMERO_MAYOR;

        public bool EsValida { get => esValida; set => esValida = value; }

        /// <summary>
        /// Constructor que genera una combinación aleatoria correcta en el que caso de que no se introduzca ningún parámetro
        /// </summary>
        public loto()
        {
            // Clase generadora de números aleatorios
            Random numeroAleatorio = new Random();
            numerosCombinacion = GenerarCombinacionValida(numeroAleatorio);
        }

        /// <summary>
        /// Constructor de la clase para crear una combinación que recibe un array de enteros con la combinación a crear.
        /// </summary>
        /// <param name="misNumeros">Array de enteros con la combinación con la que inicializar la clase</param>
        /// <remarks>La combinación introducida no tiene porqué ser válida</remarks>
        public loto(int[] misNumeros)
        {
            bool esValida = ComprobarValidez(int[] misNumeros)
            if(esValida)
            {
                numerosCombinacion = misNumeros;
            }
            else
            {
                throw new Exception("La combinación no es válida");
            }
        }

        /// <summary>
        /// Método que comprueba el número de aciertos
        /// </summary>
        /// <param name="combinacionGanadora">Se trata de un array de enteros con la combinación ganadora</param>
        /// <returns>Devuelve un entero con el número de aciertos</returns>
        public int ComprobarAciertos(int[] combinacionGanadora)
        {
            // Número de aciertos
            int numeroAciertos = 0;

            for (int i = 0; i < MAX_NUMEROS; i++)
                for (int j = 0; j < MAX_NUMEROS; j++)
                {
                    if (combinacionGanadora[i] == Premiados[j])
                    {
                        numeroAciertos++;
                    }
                }

            return numeroAciertos;
        }

        //Método que comprueba que la combinación introducida es válida
        private bool ComprobarValidez(int[] misNumeros)
        {
            for (int i = 0; i < MAX_NUMEROS; i++)
            {
                if (misNumeros[i] >= NUMERO_MENOR && misNumeros[i] <= NUMERO_MAYOR)
                {
                    int j;

                    for (j = 0; j < i; j++)
                    {
                        if (misNumeros[i] == Premiados[j])
                        {
                            break;
                        }
                    }

                    if (i == j)
                    {
                        // validamos la combinación
                        Premiados[i] = misNumeros[i];
                    }

                    else
                    {
                        EsValida = false;
                        return;
                    }
                }
                else
                {
                    // La combinación no es válida, terminamos
                    EsValida = false;
                    return;
                }

                EsValida = true;
            }
        }

        //Método que genera una combinación aleatoria válida
        private int GenerarCombinacionValida(Random numeroAleatorio)
        {
            // Generamos la combinación
            do
            {
                // Generamos un número aleatorio del 1 al 49
                numero = numeroAleatorio.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);

                // Comprobamos que el número no está
                for (j = 0; j < i; j++)
                {
                    if (Premiados[j] == numero)
                    {
                        break;
                    }
                }

                // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                if (i == j)
                {
                    Premiados[i] = numero;
                    i++;
                }
            } while (i < MAX_NUMEROS);

            EsValida = true;
            return i;
        }
    }
}
