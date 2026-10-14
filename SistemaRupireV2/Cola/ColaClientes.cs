using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRupireV2.Cola
{
    public class ColaClientes
    {
        private NodoCliente? frente;
        private NodoCliente? fin;
        private int contador;

        public ColaClientes()
        {
            frente = null;
            fin = null;
            contador = 0;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public int Count => contador;

        public void Encolar(Cliente cliente)
        {
            NodoCliente nuevo = new NodoCliente(cliente);

            if (EstaVacia())
            {
                frente = nuevo;
                fin = nuevo;
            }
            else
            {
                fin!.Siguiente = nuevo;
                fin = nuevo;
            }

            contador++;
        }

        public Cliente? Atender()
        {
            if (EstaVacia())
            {
                return null;
            }

            Cliente atendido = frente!.Dato;

            frente = frente.Siguiente;
            contador--;

            if (frente == null)
            {
                fin = null;
            }

            return atendido;
        }

        public List<Cliente> ObtenerListaParaMostrar()
        {
            List<Cliente> lista = new List<Cliente>();

            NodoCliente? actual = frente;

            while (actual != null)
            {
                lista.Add(actual.Dato);
                actual = actual.Siguiente;
            }

            return lista;
        }
    }
}
