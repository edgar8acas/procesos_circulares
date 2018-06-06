using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
    class Proceso
    {
        static Random cycleGenerator = new Random();
        private int _ciclos;

        public int Ciclos
        {
            get { return _ciclos; }
            set { _ciclos = value; }
        }

        private Proceso _siguiente;

        public Proceso Siguiente
        {
            get { return _siguiente; }
            set { _siguiente = value; }
        }
        private Proceso _anterior;

        public Proceso Anterior
        {
            get { return _anterior; }
            set { _anterior = value; }
        }




        public Proceso()
        {
            
            _ciclos = cycleGenerator.Next(4, 15);
        }

        public Proceso(int ciclos)
        {
            //_anterior = anterior;
            //_siguiente = siguiente;
            _ciclos = ciclos;
        }

        public override string ToString()
        {
            return "Ciclos: \t" + _ciclos + "\r\n";
        }

    }
}
