using System.Net.Http.Json;
using AutoHuoltoSovellus.Models;

namespace AutoHuoltoSovellus.Services;

public class SäiliöService
{
    private readonly HttpClient _httpClient;

    public SäiliöService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Säiliö>> HaeKaikki()
    {
        return await _httpClient.GetFromJsonAsync<List<Säiliö>>("api/säiliö") ?? new List<Säiliö>();
    }

    public async Task<bool> Lisaa(Säiliö säiliö)
    {
        var response = await _httpClient.PostAsJsonAsync("api/säiliö", säiliö);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Paivita(Säiliö säiliö)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/säiliö/{säiliö.SäiliöId}", säiliö);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Poista(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/säiliö/{id}");
        return response.IsSuccessStatusCode;
    }
}
