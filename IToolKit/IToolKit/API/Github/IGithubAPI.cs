namespace IToolKit.API.Github
{
    public interface IGitHubAPI
    {
        Task<string> GetLastReleaseVersion();
        Task<int> GetStars();
    }
}
