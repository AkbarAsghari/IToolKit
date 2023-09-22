using Blazored.LocalStorage;
using IToolKit.API.Github;
using IToolKit.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Octokit;

namespace IToolKit.Shared.Components.GitHub;

partial class GitHubStatus
{
    [Inject] IGitHubAPI _GitHubAPI { get; set; }
    [Inject] IJSRuntime _JSRuntime { get; set; }
    [Inject] ILocalStorageService _LocalStorage { get; set; }

    Repository repository { get; set; }
    Release lastRelease { get; set; }

    bool showReleaseModal { get; set; }

    protected override async Task OnInitializedAsync()
    {
        repository = await _GitHubAPI.GetRepository();
        lastRelease = await _GitHubAPI.GetLastRelease();
        await CheckVersionWithCurrentVersion();
        StateHasChanged();
    }

    bool isLastVersion { get; set; } = true;
    const string versionKey = "CurrentVersion";
    string currentVersion { get; set; }
    private async Task CheckVersionWithCurrentVersion()
    {
        if (await _LocalStorage.ContainKeyAsync(versionKey))
        {
            currentVersion = await _LocalStorage.GetItemAsStringAsync(versionKey);
            if (lastRelease != null)
            {
                isLastVersion = currentVersion == lastRelease.TagName.ToString();
            }
        }
        else
        {
            if (lastRelease != null)
            {
                currentVersion = lastRelease.TagName;
                await _LocalStorage.SetItemAsStringAsync(versionKey, currentVersion);
                isLastVersion = true;
            }
        }
    }

    async Task Update()
    {
        await _LocalStorage.RemoveItemAsync(versionKey);
        await _JSRuntime.ClearCache();
        await _JSRuntime.Reload();
    }
}