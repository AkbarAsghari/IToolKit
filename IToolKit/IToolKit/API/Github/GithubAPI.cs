using Octokit;

namespace IToolKit.API.Github
{
    public class GitHubAPI : IGitHubAPI
    {
        private readonly GitHubClient _Client;
        public GitHubAPI()
        {
            _Client = new GitHubClient(new ProductHeaderValue("IToolKit"));
        }

        public async Task<string> GetLastReleaseVersion()
        {
            try
            {
                var lastRelease = await _Client.Repository.Release.GetLatest("AkbarAsghari", "IToolKit");
                if (lastRelease != null)
                {
                    return lastRelease.TagName;
                }
            }
            catch { }
            return String.Empty;
        }

        public async Task<int> GetStars()
        {
            try
            {
                var repository = await _Client.Repository.Get("AkbarAsghari", "IToolKit");
                if (repository != null)
                {
                    return repository.StargazersCount;
                }
            }
            catch { }
            return -1;
        }
    }
}
