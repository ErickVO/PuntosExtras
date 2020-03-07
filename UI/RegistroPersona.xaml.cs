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
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
           
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool paso = true;

            if (NombreTextBox.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre");
                NombreTextBox.Focus();
                paso = false;
            }

            
            return paso;
        }

        private Persona LlenaClase()
        {
            Persona p = new Persona();

            p.PersonaId = Convert.ToInt32(IdTextBox.Text);
            p.Nombre = NombreTextBox.Text;
 
            return p;
        }

        private bool ExisteBaseDatos()
        {
            Persona p = PersonaBLL.Buscar((int)Convert.ToInt32(IdTextBox.Text));

            return (p != null);
        }

        private void LlenaCampo(Persona persona)
        {
            IdTextBox.Text = Convert.ToString(persona.PersonaId);
            NombreTextBox.Text = persona.Nombre;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Persona p;

            if (!Validar())
            {
                return;
            }

            p = LlenaClase();

            if (IdTextBox.Text == "0")
            {
                paso = PersonaBLL.Guardar(p);
            }
            else
            {
                if (!ExisteBaseDatos())
                {
                    MessageBox.Show("No Existe en la BDD","ERROR");
                    return;
                }
                paso = PersonaBLL.Modificar(p);
            }

            Limpiar();

            if (paso)
            {
                MessageBox.Show("Guardado","Exito");
            }
            else
            {
                MessageBox.Show("No se pudo Guardar","Exito");
            }

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);

            if (PersonaBLL.Eliminar(id))
            {
                Limpiar();
                MessageBox.Show("Eliminado");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);
            Persona p = PersonaBLL.Buscar(id);

            if (p != null)
            {
                Limpiar();
                LlenaCampo(p);
            }
            else
            {
                MessageBox.Show("No Encontrado","ERROR");
            }
        }
    }
}
