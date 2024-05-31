using Libreria_clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestor_horas_medico
{
    /// <summary>
    /// Interaction logic for WindowsAgendarHora.xaml
    /// </summary>
    public partial class WindowsAgendarHora : Window
    {
        public WindowsAgendarHora()
        {
            InitializeComponent();

            // Load cbo EspecialidadMedico.
            cboEspecialidadMedico.ItemsSource = Enum.GetValues(typeof(Specialty));
            cboEspecialidadMedico.SelectedIndex = 0;
        }


        // Items in Window.
        private void cboEspecialidadMedico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // load cbo NombresMedicos
            // To change doctor name's which changes the specyalty.
            List<string> nombresMedicos = BDConection.cargarNombresMedicos(((Specialty)cboEspecialidadMedico.SelectedItem).ToString());
            cboNombresMedicos.ItemsSource = nombresMedicos;
            cboNombresMedicos.SelectedIndex = 0;
        }
    }
}
