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
            //cboEspecialidadMedico.ItemsSource = Enum.GetValues(typeof(Specialty));
            cboEspecialidadMedico.ItemsSource = BDConection.obtenerEspecialidades();
            cboEspecialidadMedico.SelectedIndex = 0;
        }


        // Items in Window.
        private void cboEspecialidadMedico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // load cbo NombresMedicos
            // To change doctor name's which changes the specyalty.
            cboNombresMedicos.ItemsSource = BDConection.cargarNombresMedicos(cboEspecialidadMedico.SelectedItem.ToString());
            cboNombresMedicos.SelectedIndex = 0;
        }


        // Button
        private void btnAgregarConsulta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date = (DateTime)dtFecha.SelectedDate;
                Consulta consulta = new Consulta(date);

                string rutPaciente = txtRutPaciente.Text;
                string medicoName = cboNombresMedicos.SelectedItem.ToString();

                BDConection.insertConsulta(rutPaciente, medicoName, consulta);

                MessageBox.Show("Consulta agregada con exito");
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);

            }
            catch (FormatException)
            {
                MessageBox.Show("El valor de la edad y el telefono debe ser numerico");

            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Se produjo un error no controlado");
                sb.AppendLine(ex.Message);
                sb.AppendLine("No se puede agregar a la persona");
            }
        }
    }
}
