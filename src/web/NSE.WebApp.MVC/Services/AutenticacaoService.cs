using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static NSE.WebApp.MVC.Models.UsuarioViewModel;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(
                content: JsonSerializer.Serialize(usuarioLogin),
                encoding: Encoding.UTF8,
                mediaType: "application/json"
            );
            
            var response = await _httpClient.PostAsync("http://localhost:5100/api/identidade/autenticar", loginContent);

            // Somente teste
            var teste = await response.Content.ReadAsStringAsync();

            // Não está funcionando
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(
                content: JsonSerializer.Serialize(usuarioRegistro),
                encoding: Encoding.UTF8,
                mediaType: "application/json"
            );
            
            var response = await _httpClient.PostAsync("http://localhost:5100/api/identidade/nova-conta", registroContent);
            
            // Não está funcionando
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}