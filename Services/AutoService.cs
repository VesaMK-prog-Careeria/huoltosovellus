using System.Net.Http.Json;
using AutoHuoltoSovellus.Models;

namespace AutoHuoltoSovellus.Services;

public class AutoService
{
    private readonly HttpClient _httpClient;

    public AutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Auto>> HaeKaikkiAutot() // Haetaan kaikki autot apista
    {
        return await _httpClient.GetFromJsonAsync<List<Auto>>("api/auto") ?? new List<Auto>();
    }

    public async Task<bool> LisaaAuto(Auto auto) 
    {
        var response = await _httpClient.PostAsJsonAsync("api/auto", auto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> PaivitaAuto(Auto auto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/auto/{auto.AutoId}", auto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> PoistaAuto(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/auto/{id}");
        return response.IsSuccessStatusCode;
    }
}
