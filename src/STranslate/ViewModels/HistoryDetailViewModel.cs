using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using STranslate.Core;
using STranslate.Plugin;
using STranslate.ViewModels.Pages;

namespace STranslate.ViewModels;

public partial class HistoryDetailViewModel(HistoryModel historyModel) : ObservableObject
{
    public HistoryModel HistoryModel { get; } = historyModel;

    [RelayCommand]
    private void Delete()
    {
        Ioc.Default.GetRequiredService<SqlService>().DeleteData(HistoryModel);
        Ioc.Default.GetRequiredService<HistoryViewModel>().UpdateRemove(HistoryModel);
    }

    [RelayCommand]
    private void Copy(string text)
    {
        if (string.IsNullOrEmpty(text)) return;
        Utilities.SetText(text);
        Ioc.Default.GetRequiredService<ISnackbar>()
            .ShowSuccess(Ioc.Default.GetRequiredService<Internationalization>().GetTranslation("CopySuccess"));
    }
}
