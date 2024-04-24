using System.Net;
using System.Text.Json;

namespace Cepedi.Banco.Pessoa.Dominio.Services;

public class ResponseViaCEP{
  public string? Cep;
  public string? Logradouro;
  public string? Complemento;
  public string? Bairro;
  public string? Localidade;
  public string? Uf;
  public string? Ibge;
  public string? Gia;
  public string? Ddd;
  public string? Siafi;
  public string? Error;
}

public class ViaCEPService
{
    // public async Task<object> GetCEP(string cep)
    public async Task<bool> GetCEP(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";

        var httpClient = new HttpClient();
    
        var response = await httpClient.GetAsync(url);

        if(!response.IsSuccessStatusCode)
        {
            // if(response.StatusCode == HttpStatusCode.BadRequest)
            // {
            //     var responseContentError = await response.Content.ReadAsStringAsync();
            //     return JsonSerializer.Deserialize<ResponseViaCEP>(responseContentError);
            // }
            // else
            // {
            //     throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            // }
            return false;
        }

        // var responseContent = await response.Content.ReadAsStringAsync();
        // var BulkViaCEPResponse = JsonSerializer.Deserialize<ResponseViaCEP>(responseContent);
        // return BulkViaCEPResponse;
        return true;
    }
}
