namespace MVVM.ViewModels.MainViewModels;

public class LineViewModel : ViewModelBase
{
    public string Name { get; set; }

    public string Barcode { get; set; }

    public Uri PhotoUri { get; set; }

    public int Quantity { get; set; }

    private int _checkedQuantity;

    public int CheckedQuantity
    {
        get { return _checkedQuantity; }
        set
        {
            _checkedQuantity = value;

            if (Quantity == CheckedQuantity)
            {
                Done = true;
            }

            OnPropertyChanged();
        }
    }

    private bool _done;

    public bool Done
    {
        get { return _done; }
        set
        {
            _done = value;

            OnPropertyChanged();
        }
    }

}
