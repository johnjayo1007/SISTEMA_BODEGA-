using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetera_Movil_EDD.ListaDoble
{
    public class Pago
    {
        public string Codigo;
        public string Proveedor;
        public decimal Monto;
        public string MedioPago;
        public DateTime Hora;

        public Pago(string codigo, string proveedor, decimal monto, string medioPago)
        {
            Codigo = codigo;
            Proveedor = proveedor;
            Monto = monto;
            MedioPago = medioPago;
            Hora = DateTime.Now;
        }
    }
}
