using Plugin.Firebase.RemoteConfig;
using System.Text.Json;

namespace LottoNumbers.Services
{
    public interface IRemoteConfigService
    {
        Task FetchAndActivateAsync();

        Task<TOutput> GetAsync<TOutput>(string key);
    }

    public class RemoteConfigService : IRemoteConfigService
    {
        private readonly IFirebaseRemoteConfig _remoteConfig;

        public RemoteConfigService(IFirebaseRemoteConfig remoteConfig)
        {
            _remoteConfig = remoteConfig;
        }

        public async Task FetchAndActivateAsync()
        {
            await _remoteConfig.FetchAndActivateAsync();
        }

        public async Task<TOutput> GetAsync<TOutput>(string key)
        {
            var settingsString = _remoteConfig.GetString(key);

            return await Task.FromResult(JsonSerializer.Deserialize<TOutput>(settingsString)!);
        }
    }
}
