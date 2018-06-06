using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFO
{
    class ListaCircular
    {
        Proceso inicio = null;
        Proceso actual = null;
        private int _size;

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public void Agregar(Proceso nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                inicio.Anterior = inicio;
                inicio.Siguiente = inicio;
                actual = inicio;
            }
            else
            {
                Proceso p = inicio;
                while (p.Siguiente != inicio)
                {
                    p = p.Siguiente;
                }
                p.Siguiente = nuevo;
                nuevo.Siguiente = inicio;
                nuevo.Anterior = p;
                inicio.Anterior = nuevo;

            }
            _size++;
        }

        public Proceso Eliminar()
        {
            if(actual == null)
            {
                MessageBox.Show("Lista vacía");
            } 
            else
            {
                Proceso eliminado = new Proceso(actual.Ciclos);
                
                if (actual == inicio)
                {
                    //Si inicio es único
                    if (inicio.Anterior == inicio && inicio.Siguiente == inicio)
                    {
                        actual = null;
                        inicio = null;
                    }
                    else
                    {
                        inicio.Anterior.Siguiente = inicio.Siguiente;
                        inicio.Siguiente.Anterior = inicio.Anterior;
                        inicio = inicio.Siguiente;
                        actual = inicio;
                    }
                    
                }
                else
                {
                    actual.Anterior.Siguiente = actual.Siguiente;
                    actual.Siguiente.Anterior = actual.Anterior;

                    
                }
                _size--;
                return eliminado;
            }

            return null;
        }

        public Proceso Ver()
        {
            /*if (actual == null)
            {
                return inicio;
            } */
            actual = actual.Siguiente;
            return actual;
        }
    }
}
