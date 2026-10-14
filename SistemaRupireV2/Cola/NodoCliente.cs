using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRupireV2.Cola
{
    public class NodoCliente
    {
        public Cliente Dato { get; set; }
        public NodoCliente? Siguiente { get; set; }

        public NodoCliente(Cliente cliente)
        {
            Dato = cliente;
            Siguiente = null;
        }
    }
}
