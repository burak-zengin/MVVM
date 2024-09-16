using System.Collections.ObjectModel;

namespace MVVM.ViewModels.MainViewModels;

public class OrderViewModel : ViewModelBase
{
    public string OrderNumber { get; set; }

    public string CustomerName { get; set; }

    public ObservableCollection<LineViewModel> Lines { get; set; }
}
