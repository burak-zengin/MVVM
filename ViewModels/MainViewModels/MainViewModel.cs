using System.Windows.Input;

namespace MVVM.ViewModels.MainViewModels;

public class MainViewModel : ViewModelBase
{
    private string _orderNumber;
    public string OrderNumber
    {
        get { return _orderNumber; }
        set
        {
            _orderNumber = value;

            OnPropertyChanged();
        }
    }

    private ICommand _findCommand;
    public ICommand FindCommand
    {
        get
        {
            _findCommand ??= new RelayCommand((o) =>
            {
                if (string.IsNullOrEmpty(OrderNumber))
                {
                    Message = "Lütfen geçerli bir sipariş numarası giriniz.";
                    ShowMessage = true;
                    return;
                }

                //Mock data
                var order = new OrderViewModel
                {
                    OrderNumber = OrderNumber,
                    CustomerName = "Test Test",
                    Lines = [new LineViewModel
                    {
                        Barcode = "123456",
                        Quantity = 2,
                        Name = "Türk Kahvesi",
                        PhotoUri = new Uri("pack://application:,,,/Images/Product.jpeg")
                    }]
                };

                Order = order;
                OrderNumber = string.Empty;
                ShowOrder = true;
            });

            return _findCommand;
        }
    }

    private OrderViewModel _order;
    public OrderViewModel Order
    {
        get { return _order; }
        set
        {
            _order = value;

            OnPropertyChanged();
        }
    }

    private bool _showOrder;
    public bool ShowOrder
    {
        get { return _showOrder; }
        set
        {
            _showOrder = value;

            OnPropertyChanged();
        }
    }

    private string _barcode;
    public string Barcode
    {
        get { return _barcode; }
        set
        {
            _barcode = value;

            OnPropertyChanged();
        }
    }

    private ICommand _checkCommand;
    public ICommand CheckCommand
    {
        get
        {
            _checkCommand ??= new RelayCommand((o) =>
            {
                var line = Order.Lines.FirstOrDefault(l => l.Barcode == Barcode);

                if (line is null)
                {
                    Message = "Yanlış bir ürün okuttunuz.";
                    ShowMessage = true;
                    return;
                }

                if (line.Quantity == line.CheckedQuantity)
                {
                    Message = "Fazla ürün okuttunuz.";
                    ShowMessage = true;
                    return;
                }

                line.CheckedQuantity++;

                if (Order.Lines.Any(l => l.Done == false) == false)
                {
                    ShowDone = true;
                }

                Barcode = string.Empty;
            });

            return _checkCommand;
        }
    }

    private bool _showDone;
    public bool ShowDone
    {
        get { return _showDone; }
        set
        {
            _showDone = value;

            OnPropertyChanged();
        }
    }

    private ICommand _doneCommand;
    public ICommand DoneCommand
    {
        get
        {
            _doneCommand ??= new RelayCommand((o) =>
            {
                Order = null;
                ShowDone = false;
                ShowOrder = false;
            });

            return _doneCommand;
        }
    }

    private string _message;
    public string Message
    {
        get { return _message; }
        set
        {
            _message = value;

            OnPropertyChanged();
        }
    }

    private bool _showMessage = false;
    public bool ShowMessage
    {
        get { return _showMessage; }
        set
        {
            _showMessage = value;

            OnPropertyChanged();
        }
    }

    private ICommand _closeMessageCommand;
    public ICommand CloseMessageCommand
    {
        get
        {
            _closeMessageCommand ??= new RelayCommand((o) =>
            {
                Message = string.Empty;
                ShowMessage = false;
            });

            return _closeMessageCommand;
        }
    }
}