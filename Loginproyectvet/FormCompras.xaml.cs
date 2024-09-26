namespace Loginproyectvet;

public partial class FormCompras : ContentPage
{
    private List<Productos> _productos;
    private Productos _selectedProduct;

    private readonly LocalDbService _dbService;
    private int _editFormComprasId;
    public FormCompras(LocalDbService dbService)
	{
		InitializeComponent();

        _dbService = dbService;

        _productos = new List<Productos>
            {
                new Productos { nombre = "Dog Relaxante", precio = 6.50 },
                new Productos { nombre = "Cat Relaxante", precio = 7.85 },
                new Productos { nombre = "Viterma", precio = 3.30 },
                new Productos { nombre = "Vitamina K+C", precio = 8.00 },
                new Productos { nombre = "CalviPet", precio = 8.90 },
                new Productos { nombre = "Complemil", precio = 10.60 },

                new Productos { nombre = "Drontal", precio = 6.50 },
                new Productos { nombre = "Advantix", precio = 7.85 },
                new Productos { nombre = "Ivergold", precio = 3.30 },
                new Productos { nombre = "Adecin", precio = 8.00 },
                new Productos { nombre = "Ortenil", precio = 8.90 },
                new Productos { nombre = "Ortenil", precio = 10.60 },

                new Productos { nombre = "Comedero", precio = 3.50 },
                new Productos { nombre = "Pechera rosa", precio = 8.85 },
                new Productos { nombre = "Pechera anaranjada", precio = 5.30 },
                new Productos { nombre = "Collar para perros", precio = 1.00 },
                new Productos { nombre = "Porta Gatos", precio = 2.90 },
                new Productos { nombre = "Juguetes", precio = 9.60 },

        };

        pickerproductos.ItemsSource = _productos;
        pickerproductos.ItemDisplayBinding = new Binding("nombre");
    }

    public FormCompras(LocalDbService dbService, CompraProductos compraProductos)
    {
        InitializeComponent();
        _dbService = dbService;
        _editFormComprasId = compraProductos.Id;

        // Cargar los datos del registro en los campos
        EntryNomCliente.Text = compraProductos.Nombre;
        EntryApellidoCli.Text = compraProductos.Apellido;
        pickerproductos.SelectedItem = compraProductos.Producto;
        EntryPrecioProdc.Text = compraProductos.Precio.ToString();
        quantityLabel.Text = compraProductos.Cantidad.ToString();
        preciofinalLabel.Text = compraProductos.Total.ToString();

        EntryNumTarjeta.Text = compraProductos.NumCuenta.ToString();
        EntryEntrega.Text = compraProductos.Direccion;
        Entrytel.Text = compraProductos.Telefono.ToString();

    }

    private void OnProductSelected(object sender, EventArgs e)
    {
        // Obtener el producto seleccionado
        _selectedProduct = pickerproductos.SelectedItem as Productos;
        if (_selectedProduct != null)
        {
            // Mostrar el precio en el Entry
            EntryPrecioProdc.Text = _selectedProduct.precio.ToString();
        }

    }

    private void OnQuantityChanged(object sender, ValueChangedEventArgs e)
    {
        // Actualizar el Label con la cantidad seleccionada
        quantityLabel.Text = " " + ((int)e.NewValue).ToString();
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        if (_selectedProduct != null)
        {
            // Obtener el precio y la cantidad
            double price = _selectedProduct.precio;
            int quantity = (int)quantityStepper.Value;

            // Calcular el total
            double total = price * quantity;

            // Mostrar el resultado

            preciofinalLabel.Text = $" {total}";
        }
        else
        {
            preciofinalLabel.Text = "Por favor, selecciona un producto.";
        }
    }

    private void EntryNomCliente_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        var newText = e.NewTextValue;

        // Verifica que el nuevo texto contenga solo letras
        if (!string.IsNullOrEmpty(newText) && !System.Text.RegularExpressions.Regex.IsMatch(newText, @"^[a-zA-Z]+$"))
        {
            // Si el texto no es válido, restablece el texto del Entry
            entry.Text = e.OldTextValue;
        }
    }

    private void EntryApellidoCli_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        var newText = e.NewTextValue;

        // Verifica que el nuevo texto contenga solo letras
        if (!string.IsNullOrEmpty(newText) && !System.Text.RegularExpressions.Regex.IsMatch(newText, @"^[a-zA-Z]+$"))
        {
            // Si el texto no es válido, restablece el texto del Entry
            entry.Text = e.OldTextValue;
        }
    }

    private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (yesRadioButton.IsChecked)
        {
            additionalOptionsLayout.IsVisible = true; // Mostrar la sección si "Sí" está seleccionado
        }
        else
        {
            additionalOptionsLayout.IsVisible = false; // Ocultar la sección si "No" está seleccionado
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (_editFormComprasId == 0)
        {
            await _dbService.Create(new CompraProductos
            {

                Nombre = EntryNomCliente.Text,
                Apellido = EntryApellidoCli.Text,
                Producto = pickerproductos.SelectedItem.ToString(),
                Precio = Convert.ToDouble(EntryPrecioProdc.Text),
                Cantidad = quantityLabel.Text,
                Total = Convert.ToDouble(preciofinalLabel.Text),
                NumCuenta = EntryNumTarjeta.Text,
                Direccion = EntryEntrega.Text,
                Telefono = Entrytel.Text,


            });
        }
        else
        {
            await _dbService.Update(new CompraProductos
            {
                Id = _editFormComprasId,
                Nombre = EntryNomCliente.Text,
                Apellido = EntryApellidoCli.Text,
                Producto = pickerproductos.SelectedItem.ToString(),
                Precio = Convert.ToDouble(EntryPrecioProdc.Text),
                Cantidad = quantityLabel.Text,
                Total = Convert.ToDouble(preciofinalLabel.Text),
                NumCuenta = EntryNumTarjeta.Text,
                Direccion = EntryEntrega.Text,
                Telefono = Entrytel.Text,
            });

            _editFormComprasId = 0;
        }
        // Limpiar los campos
        EntryNomCliente.Text = string.Empty;
        EntryApellidoCli.Text = string.Empty;
        pickerproductos.SelectedIndex = -1;
        EntryPrecioProdc.Text = string.Empty;
        quantityLabel.Text = string.Empty;
        preciofinalLabel.Text = string.Empty;
        EntryNumTarjeta.Text = string.Empty;
        EntryEntrega.Text = string.Empty;
        Entrytel.Text = string.Empty;

        await Navigation.PushAsync(new ListaCompras(_dbService));
    }
}
public class Productos
{
    public string nombre { get; set; }
    public double precio { get; set; }
}