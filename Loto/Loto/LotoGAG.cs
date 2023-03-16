using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    public class loto
    {
        // Definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;

        // Numeros de la combinación
        private int[] numerosCombinacion = new int[MAX_NUMEROS];
        
        // Combinación válida (si es aleatoria, siempre es válida, sino, no tiene porqué)
        public bool esValida = false;      

        public int[] Premiados
        {
            get => numerosCombinacion;
            set => numerosCombinacion = value;
        }

        /// <summary>
        /// Constructor que genera una combinación aleatoria correcta en el que caso de que no se introduzca ningún parámetro
        /// </summary>
        public loto()
        {
            // Clase generadora de números aleatorios
            Random numeroAleatorio = new Random();    

            int i = 0;
            int j;
            int numero;

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

            esValida = true;
        }

        /// <summary>
        /// Constructor de la clase para crear una combinación que recibe un array de enteros con la combinación a crear.
        /// </summary>
        /// <param name="misNumeros">Array de enteros con la combinación con la que inicializar la clase</param>
        /// <remarks>La combinación introducida no tiene porqué ser válida</remarks>
        public loto(int[] misNumeros)
        {
            for (int i = 0; i < MAX_NUMEROS; i++)
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
                        esValida = false;
                        return;
                    }
                }
                else
                {
                    // La combinación no es válida, terminamos
                    esValida = false;     
                    return;
                }

            esValida = true;

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
    }
}
