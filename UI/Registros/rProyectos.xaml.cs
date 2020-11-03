using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrismeyriP2_Apl.BLL;
using CrismeyriP2_Apl.Entidades;

namespace CrismeyriP2_Apl.UI.Registros
{
    public partial class rProyectos : Window
    {
        private Proyectos proyectos = new Proyectos();
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = proyectos;

            // ComboBox 
            TipoTareaComboBox.ItemsSource = TareasBLL.GetTareas();
            TipoTareaComboBox.SelectedValuePath = "TareaId";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";
       
        }
        // cargar
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyectos;
        }
        // Limpiar
        private void Limpiar()
        {
            this.proyectos = new Proyectos();
            this.DataContext = proyectos;
        }
        // Validar
        private bool Validar()
        {
            bool Validado = true;
            if (ProyectoIdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        // Buscar
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectosBLL.Buscar(proyectos.ProyectoId);

            if (encontrado != null)
            {
                proyectos = encontrado;
                Cargar();
                //MessageBox.Show("Proyecto Encontrado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Este Proyecto no fue encontrado.\n\nAsegurese que existe o cree uno nuevo.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
               
                ProyectoIdTextbox.Text = "";
                ProyectoIdTextbox.Focus();
            }
        }
        // Agregar Fila
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var filaDetalle = new ProyectosDetalle
            {
                ProyectoId = this.proyectos.ProyectoId,
                TareaId = Convert.ToInt32(TipoTareaComboBox.SelectedValue.ToString()),
                tareas = ((Tareas)TipoTareaComboBox.SelectedItem),
                Requerimiento = (RequerimientoTextBox.Text),
                Tiempo = Convert.ToSingle(TiempoTextBox.Text)
            };
            //Tiempo Total
            proyectos.TiempoTotal += Convert.ToDouble(TiempoTextBox.Text.ToString());
           
            this.proyectos.Detalle.Add(filaDetalle);
            Cargar();

            TipoTareaComboBox.SelectedIndex = -1;
            RequerimientoTextBox.Clear();
            TiempoTextBox.Clear();
        }
        // Remover Fila
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var detalle = (ProyectosDetalle)DetalleDataGrid.SelectedItem;
                double total = Convert.ToDouble(TiempoTotalTextBox.Text);
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
                {
                   proyectos.TiempoTotal = proyectos.TiempoTotal - detalle.Tiempo;
                    proyectos.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                    //proyectos.TiempoTotal -= total;
                    Cargar();
                }
            }
            catch
            {
                MessageBox.Show("No has seleccionado ninguna Fila\n\nSeleccione la Fila a Remover.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        // Nuevo
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        // Guardar
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                if (ProyectoIdTextbox.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("El Campo (ProyectoId) esta vacio.\n\nDescriba el proyecto.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    ProyectoIdTextbox.Focus();
                    return;
                }

                if (DescripcionTextBox.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("El Campo (Descripcion del proyecto) esta vacio.\n\nDescriba el proyecto.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    DescripcionTextBox.Focus();
                    return;
                }

                var paso = ProyectosBLL.Guardar(this.proyectos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado Correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible guadar", "verifica e intenta de nuevo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        // Eliminar
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ProyectosBLL.Eliminar(Utilidades.ToInt(ProyectoIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro,Verifique que exista", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Tiempo
        private void TiempoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TiempoTextBox.Text.Trim() != "")
                {
                    double resultado = double.Parse(TiempoTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Tiempo) no es un numero.\n\nPorfavor, digite un numero.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                TiempoTextBox.Clear();
                TiempoTextBox.Focus();
            }
        }
    }
}