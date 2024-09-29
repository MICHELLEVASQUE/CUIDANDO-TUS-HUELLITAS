namespace Loginproyectvet;

public partial class Donacion : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editDonarId;
    public Donacion(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }

    public Donacion(LocalDbService dbService, Donar donar)
    {
        InitializeComponent();
        _dbService = dbService;
        _editDonarId = donar.Id;

        // Cargar los datos del registro en los campos
        entryNombre.Text = donar.NombreFundacion;
        pickerDonar.SelectedItem = donar.CuentaActual;
        entryDui.Text = donar.DUI;
        entryDireccion.Text = donar.Direccion;
        entryNumero.Text = donar.NumeroCuenta;
        entryCantidad.Text = donar.Cantidad;

    }


    private async void Guardardonar_Clicked(object sender, EventArgs e)
    {



        if (_editDonarId == 0)
        {
            await _dbService.Create(new Donar
            {

                NombreFundacion = entryNombre.Text,
                CuentaActual = pickerDonar.SelectedItem.ToString(),
                DUI = entryDui.Text,
                Direccion = entryDireccion.Text,
                NumeroCuenta = entryNumero.Text,
                Cantidad = entryCantidad.Text,

            });

            await DisplayAlert("Éxito", "Se guardado correctamente, gracias por su linda donacion", "Aceptar");
        }
        else
        {
            await _dbService.Update(new Donar
            {
                Id = _editDonarId,
                NombreFundacion = entryNombre.Text,
                CuentaActual = pickerDonar.SelectedItem.ToString(),
                DUI = entryDui.Text,
                Direccion = entryDireccion.Text,
                NumeroCuenta = entryNumero.Text,
                Cantidad = entryCantidad.Text,



            });
            await DisplayAlert("Éxito", "La información ha sido actualizada correctamente.", "Aceptar");
            _editDonarId = 0;
        }
        // Limpiar los campos
        entryNombre.Text = string.Empty;
        pickerDonar.SelectedIndex = -1;
        entryDireccion.Text = string.Empty;
        entryNumero.Text = string.Empty;
        entryCantidad.Text = string.Empty;
        entryDui.Text = string.Empty;


        await Navigation.PushAsync(new ListaDonar(_dbService));
    }
}