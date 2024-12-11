using System.Collections.ObjectModel;
using System.ComponentModel;

public class HistoryViewModel : INotifyPropertyChanged
{
    public ObservableCollection<string> History { get; set; } = new();

    public HistoryViewModel()
    {
        LoadHistory();
    }

    private void LoadHistory()
    {
        // For now, use a placeholder. Replace with database integration.
        History.Add("5 + 3 = 8");
        History.Add("10 - 7 = 3");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
