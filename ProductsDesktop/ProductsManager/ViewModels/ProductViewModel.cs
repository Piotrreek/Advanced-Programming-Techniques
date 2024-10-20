using System.Windows.Input;
using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductsManager.Models;

namespace ProductsManager.ViewModels;

public sealed class ProductViewModel : ObservableObject, IQueryAttributable
{
    private readonly IProductService _productService;

    private int? _id;
    private string? _name;
    private decimal? _price;
    private int? _quantity;
    private string? _description;

    public int? Id
    {
        get => _id;
        private set
        {
            _id = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AddButtonVisible));
            OnPropertyChanged(nameof(UpdateButtonVisible));
        }
    }

    public string? Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }

    public decimal? Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                OnPropertyChanged();
            }
        }
    }

    public int? Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Available));
            }
        }
    }

    public string? Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }

    public bool Available => _quantity > 0;
    public bool AddButtonVisible => Id is null;
    public bool UpdateButtonVisible => Id is not null;

    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }


    public ProductViewModel(IProductService productService)
    {
        _productService = productService;
        AddCommand = new AsyncRelayCommand(Add);
        UpdateCommand = new AsyncRelayCommand(Update);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var value) && int.TryParse((string)value, out var id))
        {
            LoadProduct(id).SafeFireAndForget();
        }
    }

    private async Task LoadProduct(int id)
    {
        var product = (await _productService.GetProduct(id))!;

        Id = product.Id;
        Name = product.Name;
        Price = product.Price;
        Quantity = product.Quantity;
        Description = product.Description;
    }

    private async Task Add()
    {
        await _productService.Add(_name, _quantity, _price, _description);
    }

    private async Task Update()
    
    {
        await _productService.Update(_id!.Value, _name, _quantity, _price, _description);
    }
}