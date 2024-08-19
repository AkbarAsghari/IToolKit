using Octokit;

namespace IToolKit.Client.API.Github
{
    public interface IGitHubAPI
    {
        Task<Release> GetLastRelease();
        Task<Repository> GetRepository();
    }
}
