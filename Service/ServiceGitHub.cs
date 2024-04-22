using System.Text.Json;
using GithubWEBAppLean.Interface;
using GithubWEBAppLean.Model;

namespace GithubWEBAppLean.Service;

public class ServiceGitHub : IServiceGitHub
{
    private readonly HttpClient _httpClient;

    public ServiceGitHub(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.github.com/");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
    }

    /// <summary>
    /// Recupera de forma assíncrona uma lista de usuários do GitHub.
    /// </summary>
    /// <returns>
    /// Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém uma lista de objetos <see cref="User"/>.
    /// Se a API do GitHub retornar um conteúdo que não possa ser deserializado para uma lista de usuários, uma lista vazia será retornada.
    /// </returns>
    /// <exception cref="ApplicationException">
    /// Lança uma <see cref="ApplicationException"/> se ocorrer um erro ao acessar a API do GitHub ou ao deserializar os dados.
    /// </exception>
    public async Task<List<User>> GetListAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("users");
            response.EnsureSuccessStatusCode();
            var usersJson = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(usersJson);
            return users ?? new List<User>();  
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException("Erro ao acessar a API do GitHub", ex);
        }
        catch (JsonException ex)
        {
            throw new ApplicationException("Erro ao deserializar os dados recebidos do GitHub", ex);
        }
    }

    /// <summary>
    /// Recupera de forma assíncrona os dados de um usuário do GitHub.
    /// </summary>
    /// <param name="login">O login do usuário a ser recuperado.</param>
    /// <returns>
    /// Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém um objeto <see cref="User"/>.
    /// </returns>
    /// <exception cref="ApplicationException">Lança uma exceção se ocorrer um erro ao acessar a API do GitHub ou ao deserializar os dados.</exception>
    public async Task<User> GetAsync(string login)
    {
        try
        {
            var response = await _httpClient.GetAsync($"users/{login}");
            response.EnsureSuccessStatusCode();
            var userJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(userJson);
            return user ?? throw new InvalidOperationException("Deserialização retornou nulo.");
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException("Erro ao acessar a API do GitHub", ex);
        }
        catch (JsonException ex)
        {
            throw new ApplicationException("Erro ao deserializar os dados recebidos do GitHub", ex);
        }
    }

    /// <summary>
    /// Recupera de forma assíncrona uma lista de repositórios do GitHub para um usuário específico.
    /// </summary>
    /// <param name="login">O login do usuário cujos repositórios devem ser recuperados.</param>
    /// <returns>
    /// Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém uma lista de objetos <see cref="RepositoryGitHub"/>.
    /// </returns>
    /// <exception cref="ApplicationException">Lança uma exceção se ocorrer um erro ao acessar a API do GitHub ou ao deserializar os dados.</exception>
    public async Task<List<RepositoryGitHub>> GetListRepositoryAsync(string login)
    {
        try
        {
            var response = await _httpClient.GetAsync($"users/{login}/repos");
            response.EnsureSuccessStatusCode();
            var reposJson = await response.Content.ReadAsStringAsync();
            var repos = JsonSerializer.Deserialize<List<RepositoryGitHub>>(reposJson);
            return repos ?? new List<RepositoryGitHub>();  
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException("Erro ao acessar a API do GitHub", ex);
        }
        catch (JsonException ex)
        {
            throw new ApplicationException("Erro ao deserializar os dados recebidos do GitHub", ex);
        }
    }

   
}
