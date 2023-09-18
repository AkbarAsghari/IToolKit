using Octokit;

namespace IToolKit.API.Github
{
    public class GithubAPI : IGithubAPI
    {
        public async Task<string> GetLastReleaseVersion()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("IToolKit"));
                var releases = await client.Repository.Release.GetAll("AkbarAsghari", "IToolKit");
                var latest = releases[0];
                return latest.TagName;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
