using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SeriesApp.Models;

namespace SeriesApp.Services;

class WSService : IService<Utilisateur>
{
    private readonly HttpClient _httpClient;

    public WSService() 
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7240/api/");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public Task<bool> DeleteAsync(string? nomControleur, Utilisateur? entity) => throw new NotImplementedException();
    public async Task<List<Utilisateur>> GetAllAsync(string? nomControleur)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Utilisateur>>(nomControleur);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Task<Utilisateur?> GetByIdAsync(string? nomControleur, int? id) => throw new NotImplementedException();
    public async Task<Utilisateur> GetByStringAsync(string? nomControleur, string? str)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Utilisateur>(nomControleur + "/GetUtilisateurByEmail/" + str);
        }
        catch (Exception)
        {
            return null;
        }
    }
    public Task<bool> PostAsync(string? nomControleur, Utilisateur? entity) => throw new NotImplementedException();
    public Task<bool> PutAsync(string? nomControleur, Utilisateur? entity) => throw new NotImplementedException();
}
