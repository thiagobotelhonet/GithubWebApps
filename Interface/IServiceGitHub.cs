using GithubWEBAppLean.Model;

namespace GithubWEBAppLean.Interface;

public interface IServiceGitHub
{
    Task<List<User>> GetListAsync();
    Task<User> GetAsync(string login);
    Task<List<RepositoryGitHub>> GetListRepositoryAsync(string login);
}
