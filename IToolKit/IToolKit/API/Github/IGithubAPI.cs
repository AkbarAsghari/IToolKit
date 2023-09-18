using Octokit;

namespace IToolKit.API.Github
{
    public interface IGitHubAPI
    {
        Task<Release> GetLastReleaseVersion();
        Task<Repository> GetStars();
    }
}
