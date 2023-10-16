using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Tarea1._2_AndreaCastro.Models;
using Tarea1._2_AndreaCastro.Views;

namespace Tarea1._2_AndreaCastro
{
    public partial class MainPage : ContentPage
    {
        private List<Empleado> empleos = new List<Empleado>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnAgregar(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos al principio
            if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MensajeM();
                return; // Salir del evento si hay campos vacíos
            }

            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            DateTime fechaNacimiento = dpFecha.Date;
            string correo = txtCorreo.Text;

            string fCorreo = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            Regex regexC = new Regex(fCorreo);

            bool correoC = regexC.IsMatch(correo);

            if (!string.IsNullOrEmpty(nombres) && !string.IsNullOrEmpty(apellidos) && correoC)
            {
                Empleado nEmpleo = new Empleado
                {
                    nombres = nombres,
                    apellidos = apellidos,
                    fechaNacimiento = fechaNacimiento,
                    correo = correo
                };

                empleos.Add(nEmpleo);
                MensajeB();

                Navigation.PushAsync(new PageResult(empleos));

                txtNombres.Text = "";
                txtApellidos.Text = "";
                dpFecha.Date = DateTime.Now;
                txtCorreo.Text = "";
            }
            else
            {
                MensajeM();
            }
        }

        private async void MensajeM()
        {
            await DisplayAlert("Información Importante", "- Falta información, por favor llene todos los campos.", "Aceptar");
        }

        private async void MensajeB()
        {
            await DisplayAlert("Información Exitosa", "- El empleado se ha registrado de manera exitosa.", "Aceptar");
        }
    }
}