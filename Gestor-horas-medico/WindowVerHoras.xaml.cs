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
    /// Interaction logic for WindowVerHoras.xaml
    /// </summary>
    public partial class WindowVerHoras : Window
    {
        public WindowVerHoras()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lsvDatos.Items.Clear();

                string rut = txtRutPaciente.Text;
                MessageBox.Show("Pass1");
                List<Consulta> consultas = BDConection.readConsulta(rut);
                MessageBox.Show("Pass2");

                List<Consultas> muestra = new List<Consultas>();

                foreach (var consulta in consultas)
                {
                    Consultas consultaMostrar = new Consultas();
                    consultaMostrar.id = consulta.getConsulta_id;
                    consultaMostrar.empleado = consulta.getId_empleado;
                    consultaMostrar.fecha = consulta.getFecha_consulta.ToString();

                    muestra.Add(consultaMostrar);
                }

                lsvDatos.ItemsSource = muestra;
                MessageBox.Show("Pass3");

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

    public class Consultas()
    {
        public string id { get; set; }
        public string empleado { get; set; }
        public string fecha { get; set; }
    }

}