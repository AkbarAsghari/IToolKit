using Octokit;

namespace IToolKit.API.Github
{
    public interface IGitHubAPI
    {
        Task<Release> GetLastRelease();
        Task<Repository> GetRepository();
    }
}
