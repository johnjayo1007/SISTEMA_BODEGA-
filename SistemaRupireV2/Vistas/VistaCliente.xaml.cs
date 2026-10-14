using SistemaRupireV2.Cola;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaRupireV2.Vistas
{
    /// <summary>
    /// Lógica de interacción para VistaCliente.xaml
    /// </summary>
    public partial class VistaCliente : UserControl
    {
        private ColaClientes colaClientes = new ColaClientes();
        private int siguienteCodigo = 1;
        public VistaCliente()
        {
            InitializeComponent();
            ActualizarTabla();
            GenerarNuevoCodigo();
        }
        private void GenerarNuevoCodigo()
        {
            txtCodigo.Text = $"OP-{siguienteCodigo:D3}";
        }

        private void rbEncolar_Click(object sender, RoutedEventArgs e)
        {
            string producto = txtProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(producto))
            {
                MessageBox.Show(
                    "Ingrese el nombre del producto.",
                    "Dato obligatorio",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtProducto.Focus();
                return;
            }

            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad)
                || cantidad <= 0)
            {
                MessageBox.Show(
                    "Ingrese una cantidad entera mayor que cero.",
                    "Cantidad inválida",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtCantidad.Focus();
                return;
            }

            string textoPrecio = txtPrecioU.Text.Trim();

            bool precioValido =
                decimal.TryParse(
                    textoPrecio,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out decimal precioUnitario)
                ||
                decimal.TryParse(
                    textoPrecio,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out precioUnitario);

            if (!precioValido || precioUnitario <= 0)
            {
                MessageBox.Show(
                    "Ingrese un precio válido mayor que cero.",
                    "Precio inválido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtPrecioU.Focus();
                return;
            }

            string codigoAtencion = txtCodigo.Text;

            Cliente nuevoCliente = new Cliente(
                codigoAtencion,
                producto,
                cantidad,
                precioUnitario);

            // El cliente se agrega al final de la única cola.
            colaClientes.Encolar(nuevoCliente);

            MessageBox.Show(
                $"Venta registrada correctamente.\n\n" +
                $"Código: {nuevoCliente.CodigoA}\n" +
                $"Producto: {nuevoCliente.Producto}\n" +
                $"Cantidad: {nuevoCliente.Cantidad}\n" +
                $"Precio unitario: S/. {nuevoCliente.PrecioUnitario:N2}\n" +
                $"Total: S/. {nuevoCliente.MontoTotal:N2}",
                "Bodega Rupire",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            // El código aumenta aunque ya se haya atendido una venta.
            siguienteCodigo++;
            GenerarNuevoCodigo();

            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecioU.Clear();

            ActualizarTabla();
            txtProducto.Focus();
        }

        private void ActualizarTabla()
        {
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource =
            colaClientes.ObtenerListaParaMostrar();
        }

        private void rbAtenderC_Click(object sender, RoutedEventArgs e)
        {
            Cliente? clienteAtendido = colaClientes.Atender();

            if (clienteAtendido == null)
            {
                MessageBox.Show(
                    "No hay ventas pendientes de atención.",
                    "Cola vacía",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            ActualizarTabla();

            MessageBox.Show(
                $"Venta atendida correctamente.\n\n" +
                $"Código: {clienteAtendido.CodigoA}\n" +
                $"Producto: {clienteAtendido.Producto}\n" +
                $"Cantidad: {clienteAtendido.Cantidad}\n" +
                $"Precio unitario: S/. {clienteAtendido.PrecioUnitario:N2}\n" +
                $"Total: S/. {clienteAtendido.MontoTotal:N2}",
                "Caja - Bodega Rupire",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void dgPreferencial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgRegular_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

