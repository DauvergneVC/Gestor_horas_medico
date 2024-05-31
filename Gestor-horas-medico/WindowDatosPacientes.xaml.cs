using Libreria_clases;
using Mysqlx.Expr;
using MySqlX.XDevAPI.Common;
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
    /// Interaction logic for DatosPacientes.xaml
    /// </summary>
    public partial class DatosPacientes : Window
    {
        public DatosPacientes()
        {
            InitializeComponent();

            //load cbos
            cboSexo.ItemsSource = Enum.GetValues(typeof(Gender));
            cboSexo.SelectedIndex = 0;
            cboProvicion.ItemsSource = Enum.GetValues(typeof(Provicion));
            cboProvicion.SelectedIndex = 0;
        }


        // Buttons
        #region buttons
        private void btnAgregarPersona_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Paciente paciente = tomarValoresPaciente();

                if (MessageBox.Show("¿Seguro que desea registrar al paciente en la \n base de datos?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    MessageBox.Show("Datos del paciente NO AGREGADOS");
                }
                else
                {
                    BDConection.agregarPacientes(paciente);
                    MessageBox.Show("Datos del paciente agregados con EXITO");
                    limpiarCampos();
                }
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);

            } //este de abajo es para las exepciones de argumentos
            catch (FormatException)
            {
                MessageBox.Show("El valor de la edad y el telefono debe ser numerico");

            } //este es para exepciones generales
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Se produjo un error no controlado");
                sb.AppendLine(ex.Message);
                sb.AppendLine("No se puede agregar a la persona");
            }
        }

        private void btnConsultarRut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Paciente paciente = BDConection.leerDatosPaciente(txtRut.Text);
                txtRut.Text = paciente.getRut;
                txtNombre.Text = paciente.getName;
                txtApellido.Text = paciente.getLastname;
                txtEdad.Text = paciente.getEdad.ToString();
                txtTelefono.Text = paciente.getPhoneNumber.ToString();

                cboSexo.SelectedIndex = selectorGender(paciente.getGender.ToString());
                cboProvicion.SelectedIndex = selectorProvicion(paciente.getProvicion.ToString());
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);

            }//este es para exepciones generales
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Se produjo un error no controlado");
                sb.AppendLine(ex.Message);
                sb.AppendLine("No se puede agregar a la persona");
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Seguro que desea actualizar los datos del paciente en la \n base de datos?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    MessageBox.Show("Datos del paciente NO ACTUALIZADOS");
                }
                else
                {
                    BDConection.actualizarPaciente(tomarValoresPaciente());
                    MessageBox.Show("Datos del paciente ACTUALIZADOS con EXITO");
                    limpiarCampos();
                }

            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);

            } //este de abajo es para las exepciones de argumentos
            catch (FormatException)
            {
                MessageBox.Show("El valor de la edad y el telefono debe ser numerico");

            } //este es para exepciones generales
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Se produjo un error no controlado");
                sb.AppendLine(ex.Message);
                sb.AppendLine("No se puede agregar a la persona");
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Seguro que desea ELIMINAR el paciente de la \n base de datos?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("paciente NO ELIMINADO");
                }
                else
                {
                    string rut = txtRut.Text;
                    BDConection.deletePaciente(rut);
                    MessageBox.Show("paciente ELIMINADO con EXITO");
                    limpiarCampos();
                }

            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);

            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Se produjo un error no controlado");
                sb.AppendLine(ex.Message);
                sb.AppendLine("No se puede agregar a la persona");
            }
        }
        #endregion


        // Helpers, slectors for cbos whit existing data, button consultar
        #region helpers
        private static int selectorGender(string valor)
        {
            int i = 0;
            foreach(Gender en in Enum.GetValues(typeof(Gender)))
            {
                if (valor == en.ToString())
                {
                    break;
                }
                else if (i > 100)
                {
                    throw new ArgumentException(string.Format("Fallo al encontrar valor en combo box"));
                }
                i++;
            }
            return i;
        }

        private static int selectorProvicion(string valor)
        {
            int i = 0;
            foreach (Provicion pr in Enum.GetValues(typeof(Provicion)))
            {
                if (valor == pr.ToString())
                {
                    break;
                }
                else if (i > 100)
                {
                    throw new ArgumentException(string.Format("Fallo al encontrar valor en combo box"));
                }
                i++;
            }
            return i;
        }

        private Paciente tomarValoresPaciente()
        {
            string rut = txtRut.Text;
            string name = txtNombre.Text;
            string lastname = txtApellido.Text;
            int edad = int.Parse(txtEdad.Text);
            string gender = cboSexo.SelectedValue.ToString();
            int phone = int.Parse(txtTelefono.Text);
            string provicion = cboProvicion.SelectedValue.ToString();

            Paciente paciente = new Paciente(rut, name, lastname, edad, gender, phone, provicion);
            return paciente;
        }

        private void limpiarCampos()
        {
            txtRut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cboSexo.SelectedIndex = 0;
            cboProvicion.SelectedIndex = 0;
        }

        #endregion

    }
}
