using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LottoNumbers.Models;
using LottoNumbers.Services;
using LottoNumbers.Views;
using Toast = CommunityToolkit.Maui.Alerts.Toast;
using CommunityToolkit.Maui.Core;

namespace LottoNumbers.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly ILottoGameService _lottoNumberService;

        [ObservableProperty]
        private bool _showLuckyCat = true;

        [ObservableProperty]
        private string _gameHeader = default!;

        [ObservableProperty]
        private LottoGame _selectedGame = default!;

        [ObservableProperty]
        private List<LottoGame> _lottoGames = default!;

        [ObservableProperty]
        private List<LottoNumber> _lottoNumbers = default!;

        public MainPageViewModel(ILottoGameService lottoNumberService)
        {
            _lottoNumberService = lottoNumberService;
            InitializeAsync().SafeFireAndForget();
        }

        private bool CanGenerateNumbers() => SelectedGame != null;

        [RelayCommand]
        async Task GenerateNumbers()
        {
            if (!CanGenerateNumbers())
            {
                await Toast.Make("Please select a game", ToastDuration.Short).Show();
                return;
            }

            ShowLuckyCat = false;
            var lottoNumbers = await _lottoNumberService.GenerateNumbersAsync(SelectedGame.GameKey);
            LottoNumbers = new List<LottoNumber>(lottoNumbers);
            GameHeader = $"Your {SelectedGame.DisplayName} numbers are:";
        }

        async Task InitializeAsync()
        {
            await _lottoNumberService.FetchLatestConfigAsync();
            var lottoGames = await _lottoNumberService.GetGamesAsync();
            LottoGames = new List<LottoGame>(lottoGames);
        }

        [RelayCommand]
        async Task SettingsNavigation()
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));
        }

        [RelayCommand]
        void OnShowLuckyCat()
        {
            ShowLuckyCat = true;
            GameHeader = string.Empty;
        }
    }
}
