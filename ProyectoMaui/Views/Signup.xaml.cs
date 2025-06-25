using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMaui.ViewModels;
using ProyectoMaui.Services;

namespace ProyectoMaui.Views;

public partial class SignupView : ContentPage
{
    private readonly UsuarioService _proveedoresService = new UsuarioService();
    private UsuariosViewModel viewModel;
    

    public SignupView()
    {
        InitializeComponent();
        viewModel = new UsuariosViewModel();
        BindingContext = viewModel;
        Shell.SetNavBarIsVisible(this, false);    
    }
    
    private async void OnCrearUsuarioClicked(object sender, EventArgs e)
    {
        string nombre = nombreEntry.Text;
        string usuario = usuarioEntry.Text;
        string contrasena = contrasenaEntry.Text;
        string tipo = tipoEntry.Text;
        string telefono = tipoEntry.Text;
        string email = tipoEntry.Text;
        
        if (!string.IsNullOrWhiteSpace(nombre) &&
            !string.IsNullOrWhiteSpace(usuario) &&
            !string.IsNullOrWhiteSpace(contrasena)&&
            !string.IsNullOrWhiteSpace(tipo)&&
            !string.IsNullOrWhiteSpace(telefono)&&
            !string.IsNullOrWhiteSpace(email))
            
        {
            await viewModel.CrearUsuarioAsync(nombre, usuario, contrasena, tipo, telefono, email);
            nombreEntry.Text = string.Empty;
            usuarioEntry.Text = string.Empty;
            contrasenaEntry.Text = string.Empty;
            tipoEntry.Text = string.Empty;
            telefonoEntry.Text = string.Empty;
            emailEntry.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Error", "Debes ingresar IDs válidos", "OK");
        }
    }
}