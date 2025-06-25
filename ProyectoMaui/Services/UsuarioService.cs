using Newtonsoft.Json;
using System.Buffers.Text;
using ProyectoMaui.Models;
using System.Net.Http.Json;
namespace ProyectoMaui.Services;

public class UsuarioService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://7c41-177-245-247-187.ngrok-free.app/";
    //admin@techstore.com
    //admin123

    public UsuarioService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://7c41-177-245-247-187.ngrok-free.app/");

    }
    
    public async Task<bool> CrearUsuarioAsync(Usuario usuario)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/usuarios", new
            {
                usuario.Nombre,
                usuario.NombreUsuario,
                usuario.Contrasena,
                usuario.Tipo,
                usuario.Telefono,
                usuario.Email
                
            });

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"RESPUESTA POST: {content}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR EN POST: {ex.Message}");
            return false;
        }
        

    }
}

