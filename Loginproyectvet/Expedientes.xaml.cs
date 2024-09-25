using Microsoft.Win32;

namespace Loginproyectvet;

public partial class Expedientes : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editExpedienteId;
    public Expedientes(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
    }

    public Expedientes(LocalDbService dbService, Registro registro)
    {
        InitializeComponent();
        _dbService = dbService;
        _editExpedienteId = registro.Id;

        // Cargar los datos del registro en los campos
        entryNombrePropietario.Text = registro.NombrePropietario;
        entryDireccion.Text = registro.Direccion;
        entryTelefono.Text = registro.Telefono;
        entryDUI.Text = registro.DUI;
        entryNombreMascota.Text = registro.MascotaNombre;
        pickerEspecie.SelectedItem = registro.Especie;
        entryEdad.Text = registro.Edad;
        pickerRaza.SelectedItem = registro.Raza;
        pickerSexo.SelectedItem = registro.MF;
    }

    private async void GuardarExpediente_Clicked(object sender, EventArgs e)
    {


        if (!int.TryParse(entryEdad.Text, out int edad) || !int.TryParse(entryTelefono.Text, out int telefono))
        {
            await DisplayAlert("Error", "La edad y el teléfono deben ser números enteros.", "Aceptar");
            return;
        }

        edad = !string.IsNullOrWhiteSpace(entryEdad.Text) ? int.Parse(entryEdad.Text) : 0;

        if (_editExpedienteId == 0)
        {
            // Crear un nuevo expediente
            await _dbService.Create(new Registro
            {
                NombrePropietario = entryNombrePropietario.Text,
                Direccion = entryDireccion.Text,
                Telefono = entryTelefono.Text,
                DUI = entryDUI.Text,
                MascotaNombre = entryNombreMascota.Text,
                Especie = pickerEspecie.SelectedItem.ToString(),
                Edad = entryEdad.Text,
                Raza = pickerRaza.SelectedItem.ToString(),
                MF = pickerSexo.SelectedItem.ToString(),


            });
            await DisplayAlert("Éxito", "Se guardado correctamente, gracias por ofrecernos sus datos, ya tendremos su expediente en nustra clinica", "Aceptar");


        }
        else
        {
            // Actualizar un expediente existente
            await _dbService.Update(new Registro
            {
                Id = _editExpedienteId,
                NombrePropietario = entryNombrePropietario.Text,
                Direccion = entryDireccion.Text,
                Telefono = entryTelefono.Text,
                DUI = entryDUI.Text,
                MascotaNombre = entryNombreMascota.Text,
                Especie = pickerEspecie.SelectedItem.ToString(),
                Edad = entryEdad.Text,
                Raza = pickerRaza.SelectedItem.ToString(),
                MF = pickerSexo.SelectedItem.ToString()

            });
            await DisplayAlert("Éxito", "La información de la mascota ha sido actualizada correctamente.", "Aceptar");

            _editExpedienteId = 0;
        }

        // Limpiar los campos
        entryNombrePropietario.Text = string.Empty;
        entryDireccion.Text = string.Empty;
        entryTelefono.Text = string.Empty;
        entryDUI.Text = string.Empty;
        entryEdad.Text = string.Empty;
        entryNombreMascota.Text = string.Empty;
        pickerEspecie.SelectedIndex = -1;
        pickerRaza.SelectedIndex = -1;
        pickerSexo.SelectedIndex = -1;

        // Navegar de vuelta a la pantalla principal o mostrar una confirmación
        await Navigation.PushAsync(new ListaExpedientes(_dbService));
    }
}