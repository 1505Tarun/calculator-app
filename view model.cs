using System.ComponentModel;
using System.Windows.Input;

public class CalculatorViewModel : INotifyPropertyChanged
{
    public ICommand NavigateToHistoryCommand { get; }

public CalculatorViewModel()
{
    NavigateToHistoryCommand = new Command(async () =>
    {
        await Application.Current.MainPage.Navigation.PushAsync(new HistoryPage());
    });
}

    private readonly CalculatorModel _model = new();
    private string _input1, _input2, _result;

    public string Input1
    {
        get => _input1;
        set { _input1 = value; OnPropertyChanged(); }
    }

    public string Input2
    {
        get => _input2;
        set { _input2 = value; OnPropertyChanged(); }
    }

    public string Result
    {
        get => _result;
        set { _result = value; OnPropertyChanged(); }
    }

    public ICommand AddCommand { get; }
    public ICommand SubtractCommand { get; }
    public ICommand MultiplyCommand { get; }
    public ICommand DivideCommand { get; }

    public CalculatorViewModel()
    {
        AddCommand = new Command(ExecuteAdd);
        SubtractCommand = new Command(ExecuteSubtract);
        MultiplyCommand = new Command(ExecuteMultiply);
        DivideCommand = new Command(ExecuteDivide);
    }

    private void ExecuteAdd()
    {
        if (double.TryParse(Input1, out var a) && double.TryParse(Input2, out var b))
            Result = _model.Add(a, b).ToString();
    }

    private void ExecuteSubtract()
    {
        if (double.TryParse(Input1, out var a) && double.TryParse(Input2, out var b))
            Result = _model.Subtract(a, b).ToString();
    }

    private void ExecuteMultiply()
    {
        if (double.TryParse(Input1, out var a) && double.TryParse(Input2, out var b))
            Result = _model.Multiply(a, b).ToString();
    }

    private void ExecuteDivide()
    {
        if (double.TryParse(Input1, out var a) && double.TryParse(Input2, out var b) && b != 0)
            Result = _model.Divide(a, b).ToString();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
