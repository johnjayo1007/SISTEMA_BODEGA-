using SistemaRupireV2.Vistas;
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

namespace SistemaRupireV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegistrarLog("Sistema de Gestion de Bodega inicializado correctamente.");
            NavegarAInicio();
        }

        private VistaCliente? vistaCliente;
        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            if (vistaCliente == null)
            {
                vistaCliente = new VistaCliente();
            }
            MainContentControl.Content = vistaCliente;
        }
        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            NavegarAInicio();
        }
        private void RegistrarLog(string mensaje)
        {
            txtSistema.AppendText(string.Format("[{0:HH:mm:ss}] {1}\n", DateTime.Now, mensaje));
            txtSistema.ScrollToEnd();
        }
        private void NavegarAInicio()
        {
            // Instancia la vista y la asigna al ContentControl principal
            VistaInicio vista = new VistaInicio();
            MainContentControl.Content = vista;
        }
    }
}