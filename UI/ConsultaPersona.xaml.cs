using Personas.BLL;
using Personas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personas.UI
{
    /// <summary>
    /// Interaction logic for ConsultaPersona.xaml
    /// </summary>
    public partial class ConsultaPersona : Window
    {
        public ConsultaPersona()
        {
            InitializeComponent();
        }

        private void btnConsultarr_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Persona>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:

                        listado = PersonaBLL.GetList(c => true);

                        break;

                    case 1:

                        int id = Convert.ToInt32(CriterioTextBox.Text);

                        listado = PersonaBLL.GetList(p => p.PersonaId == id);

                        break;

                    case 2:

                        listado = PersonaBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                }
           

            }
            else
            {
                listado = PersonaBLL.GetList(c => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;

        }

        private void btnConsultarr1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
