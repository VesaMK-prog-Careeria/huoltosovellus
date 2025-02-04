using System.Net.Http.Json;
using AutoHuoltoSovellus.Models;

namespace AutoHuoltoSovellus.Services;

public class PerävaunuService
{
    private readonly HttpClient _httpClient;

    public PerävaunuService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Perävaunu>> HaeKaikki()
    {
        return await _httpClient.GetFromJsonAsync<List<Perävaunu>>("api/perävaunu") ?? new List<Perävaunu>();
    }

    public async Task<bool> Lisaa(Perävaunu perävaunu)
    {
        var response = await _httpClient.PostAsJsonAsync("api/perävaunu", perävaunu);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Paivita(Perävaunu perävaunu)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/perävaunu/{perävaunu.PerävaunuId}", perävaunu);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Poista(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/perävaunu/{id}");
        return response.IsSuccessStatusCode;
    }
}
