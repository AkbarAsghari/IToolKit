namespace IToolKit.API.Github
{
    public interface IGithubAPI
    {
        Task<string> GetLastReleaseVersion();
    }
}
