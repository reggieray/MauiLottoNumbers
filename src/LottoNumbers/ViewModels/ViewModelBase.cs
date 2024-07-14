using CommunityToolkit.Mvvm.ComponentModel;

namespace LottoNumbers.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private string _title = default!;
    }
}
