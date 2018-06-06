using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FIFO
{
    class Procesador
    {
        private Cola cola;
        private Random random;
        private ListaCircular lista;
        private string log;

        public string Log
        {
            get { return log; }
            set { log = value; }
        }

        public string Simular()
        {
            log = "";
            lista = new ListaCircular();
            cola = new Cola();
            random = new Random();
            Proceso actual;
            int atendidos = 0;
            int ciclosVacia = 0;
            
            for (int i = 0; i < 100; i++)
            {
                //Thread.Sleep(10);
                if (random.Next(20) < 7)
                {
                    Proceso p = new Proceso();
                    lista.Agregar(p);
                    log += "(Agregado) -> " + p.ToString();
                    
                }
                
                if(lista.Size != 0)
                {
                    actual = lista.Ver();
                    actual.Ciclos--;
                    if (actual.Ciclos == 0)
                    {
                        atendidos++;
                        log += "(Eliminado) -> " + lista.Eliminar().ToString();
                    }
                    
                }
                else
                {
                    ciclosVacia++;
                }

            }

            int ciclosFaltantes = 0;
            int sizeBefore = lista.Size;
            for(int i = 0; i < lista.Size; i++)
            {
                Proceso p = lista.Eliminar();
                
                ciclosFaltantes += p.Ciclos;
            }
            
            return "Vacia: " + ciclosVacia + " ciclos \t" + "Atendidos: " + atendidos + " procesos \t" + "Pendientes " + sizeBefore + " procesos \t" + "Ciclos faltantes: " + ciclosFaltantes + "\r\n"; 
        }

        

    }
}
