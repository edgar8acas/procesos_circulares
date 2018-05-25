using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFO
{
    class Cola
    {
        private int _size;

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        Proceso inicio = null;
        Proceso ultimo = null;

        public Cola()
        {
            _size = 0;
        }

        public void Encolar(Proceso nuevo)
        {
            if(inicio == null)
            {
                inicio = nuevo;
                ultimo = nuevo;
                
            } else
            {
                nuevo.Siguiente = inicio;
                inicio.Anterior = nuevo;
                inicio = nuevo;
                
            }
            _size++;
        }

        public Proceso Decolar()
        {
            if(_size != 0)
            {

                Proceso eliminado = new Proceso(ultimo.Ciclos);
                if (ultimo.Anterior == null)
                {
                    ultimo = null;
                    inicio = null;
                    _size--;
                    return eliminado;
                }
                else
                {
                    ultimo = ultimo.Anterior;
                    ultimo.Siguiente = null;
                    _size--;
                    return eliminado;
                }
            } else
            {
                MessageBox.Show("Cola vacía");
            }
            return null;
        }

        public Proceso Ver()
        {
            return ultimo;
        }

        

    }
}
