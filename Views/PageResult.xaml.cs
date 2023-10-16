using Tarea1._2_AndreaCastro.Models;

namespace Tarea1._2_AndreaCastro.Views;

public partial class PageResult : ContentPage
{
	public PageResult(List<Empleado> empleos)
	{
		InitializeComponent();
		listEmpleados.ItemsSource = empleos;
    }
}