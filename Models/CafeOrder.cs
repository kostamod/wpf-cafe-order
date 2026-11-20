using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CafeOrderApp.Models;

public class CafeOrder : INotifyPropertyChanged
{
    private string _dishName = "";
    private decimal _unitPrice;
    private int _quantity = 1;
    private decimal _servicePercent;

    public string DishName
    {
        get => _dishName;
        set
        {
            if (_dishName == value) return;
            _dishName = value;
            OnPropertyChanged();
        }
    }

    public decimal UnitPrice
    {
        get => _unitPrice;
        set
        {
            if (_unitPrice == value) return;
            _unitPrice = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity == value) return;
            _quantity = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    // Доля от стоимости заказа. Например, 0,10 соответствует 10 %.
    public decimal ServicePercent
    {
        get => _servicePercent;
        set
        {
            if (_servicePercent == value) return;
            _servicePercent = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    public decimal TotalPrice => UnitPrice * Quantity * (1 + ServicePercent);

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
