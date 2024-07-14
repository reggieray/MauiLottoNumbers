using LottoNumbers.Constants;
using LottoNumbers.Services;
namespace LottoNumbers.ViewModels
{
    public partial class SettingsPageViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;

        private bool _usePseudorandomSeed;
        public bool UsePseudorandomSeed
        {
            get { return _usePseudorandomSeed; }
            set
            {
                SetProperty(ref _usePseudorandomSeed, value);
                _settingsService.SetBool(SettingConstants.USE_PSEUDORANDOM_SEED_KEY, value);
            }
        }

        private DateTime _pseudorandomDateSeed;
        public DateTime PseudorandomDateSeed
        {
            get { return _pseudorandomDateSeed; }
            set
            {
                if (value.ToString(SettingConstants.DATE_FORMAT) == SettingConstants.DEFAULT_MIN_DATE) return;
                SetProperty(ref _pseudorandomDateSeed, value);
                _settingsService.SetString(SettingConstants.PSEUDORANDOM_SEED_KEY, value.ToString(SettingConstants.DATE_FORMAT));
            }
        }

        public SettingsPageViewModel(
           ISettingsService settingsService)
        {
            Title = "Settings";
            _settingsService = settingsService;

            Initialize();
        }

        void Initialize()
        {
            UsePseudorandomSeed = _settingsService.GetBool(SettingConstants.USE_PSEUDORANDOM_SEED_KEY, false);
            var pseudorandomDateSeed = _settingsService.GetString(SettingConstants.PSEUDORANDOM_SEED_KEY, DateTime.Now.ToString(SettingConstants.DATE_FORMAT));
            PseudorandomDateSeed = DateTime.Parse(pseudorandomDateSeed);
        }
    }
}
