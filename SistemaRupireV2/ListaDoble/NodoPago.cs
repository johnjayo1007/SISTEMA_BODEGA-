using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetera_Movil_EDD.ListaDoble
{
    public class NodoPago
    {
        public Pago Dato { get; set; }

        public NodoPago Anterior { get; set; }

        public NodoPago Siguiente { get; set; }

        public NodoPago(Pago pago)
        {
            Dato = pago;
            Anterior = null;
            Siguiente = null;
        }
    }
}
