using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProyectoMaui.Models;
using ProyectoMaui.Services;

namespace ProyectoMaui.ViewModels;

public class UsuariosViewModel
{
    
    private readonly UsuarioService _usuarioService;
    
    
    public async Task CrearUsuarioAsync(string nombre, string usuario, string contrasena, string tipo, string telefono,string email)
    {
        try
        {
            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                NombreUsuario = usuario,
                Contrasena = contrasena,
                Telefono = telefono,
                Tipo = tipo,
                Email = email
            };

            var exito = await _usuarioService.CrearUsuarioAsync(nuevoUsuario);

            if (exito)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "usuario creado", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear el usuario", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

}