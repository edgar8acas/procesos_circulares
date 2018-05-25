using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
    class Procesador
    {
        private Cola cola;
        private Random random;

        public string Simular()
        {
            cola = new Cola();
            random = new Random();
            Proceso actual;
            int atendidos = 0;
            int ciclosVacia = 0;
            
            for (int i = 0; i < 300; i++)
            {
                if (random.Next(20) < 7)
                {
                    cola.Encolar(new Proceso());
                }
                
                if(cola.Size != 0)
                {
                    actual = cola.Ver();
                    if (actual.Ciclos == 0)
                    {
                        atendidos++;
                        actual = cola.Decolar();
                    }
                    actual.Ciclos--;
                }
                else
                {
                    ciclosVacia++;
                }

            }

            return "Vacia: " + ciclosVacia + " ciclos \t" + "Atendidos: " + atendidos + " procesos \t" + "Pendientes " + cola.Size + " procesos \r\n"; 
        }

    }
}
