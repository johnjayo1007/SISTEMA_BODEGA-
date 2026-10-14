using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRupireV2.Cola
{
    public class Cliente
    {
        public string CodigoA { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal MontoTotal => Cantidad * PrecioUnitario;

        public Cliente(
            string codigoA,
            string producto,
            int cantidad,
            decimal precioUnitario)
        {
            CodigoA = codigoA;
            Producto = producto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
