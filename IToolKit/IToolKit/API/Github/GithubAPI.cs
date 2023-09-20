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

        public async Task<Release> GetLastRelease()
        {
            try
            {
                return await _Client.Repository.Release.GetLatest("AkbarAsghari", "IToolKit");
            }
            catch { }
            return null;
        }

        public async Task<Repository> GetRepository()
        {
            try
            {
                return await _Client.Repository.Get("AkbarAsghari", "IToolKit");
            }
            catch { }
            return null;
        }
    }
}
