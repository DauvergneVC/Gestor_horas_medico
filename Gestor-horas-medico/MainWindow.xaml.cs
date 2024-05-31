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

namespace Gestor_horas_medico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Pacientes_Click(object sender, RoutedEventArgs e)
        {
            DatosPacientes window = new DatosPacientes();
            window.Show();
        }

        private void btnVentanaVerHorasAgendadas_Click(object sender, RoutedEventArgs e)
        {
            WindowVerHoras ventana = new WindowVerHoras();
            ventana.Show();
        }

        private void btnVentanaHoras_Click(object sender, RoutedEventArgs e)
        {
            WindowsAgendarHora ventana = new WindowsAgendarHora();
            ventana.Show();
        }
    }
}