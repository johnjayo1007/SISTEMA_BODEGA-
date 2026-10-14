using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetera_Movil_EDD.ListaDoble
{
    public class ListaDoblePago
    {
        private NodoPago cabeza;
        private NodoPago cola;

        public ListaDoblePago()
        {
            cabeza = null;
            cola = null;
        }

        public void InsertarFinal(Pago pago)
        {
            NodoPago nuevo = new NodoPago(pago);

            if (cabeza == null)
            {
                cabeza = nuevo;
                cola  = nuevo;
            }
            else
            {
                nuevo.Anterior = cola;
                cola.Siguiente = nuevo;
                cola = nuevo;
            }
        }
        public void Mostrar()
        {
            NodoPago actual = cabeza;
            Console.WriteLine(" === REGISTRO DE PAGO A PROVEEDORES === ");
            while (actual != null)
            {
                Console.WriteLine(
                    actual.Dato.Codigo + " | " +
                    actual.Dato.Proveedor + " | S/ " +
                    actual.Dato.Monto + " | " +
                    actual.Dato.MedioPago + " | " + 
                    actual.Dato.Hora
                );

                actual = actual.Siguiente;
            }
        }
    }
}
