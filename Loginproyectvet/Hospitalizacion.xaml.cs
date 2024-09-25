namespace Loginproyectvet;

public partial class Hospitalizacion : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editHospitalizacionId;
    public Hospitalizacion(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }

    public Hospitalizacion(LocalDbService dbService, MascotaHospitalizada mascotaHospitalizada)
    {
        InitializeComponent();
        _dbService = dbService;
        _editHospitalizacionId = mascotaHospitalizada.Id;

        // Cargar los datos del registro en los campos
        entryNombreMascota.Text = mascotaHospitalizada.Nombre;
        pickerEspecie.SelectedItem = mascotaHospitalizada.Especie;
        pickerRaza.SelectedItem = mascotaHospitalizada.Raza;
        entryEdad.Text = mascotaHospitalizada.Edad;
        entryPeso.Text = mascotaHospitalizada.Peso;
        entryPropietario.Text = mascotaHospitalizada.Propietario;
        entryDUI.Text = mascotaHospitalizada.DUI;
        entryTelefono.Text = mascotaHospitalizada.Telefono;
        pickerEstado.SelectedItem = mascotaHospitalizada.EstadoHospitalizacion;
    }


    private async void GuardarMascota_Clicked(object sender, EventArgs e)
    {

        bool isEdadValid = int.TryParse(entryEdad.Text, out int edad);
        if (!isEdadValid)
        {
            await DisplayAlert("Error", "La edad debe ser un número entero válido.", "Aceptar");
            return;
        }

        // Convertir Peso a double
        bool isPesoValid = double.TryParse(entryPeso.Text, System.Globalization.NumberStyles.AllowDecimalPoint,
                                           System.Globalization.CultureInfo.InvariantCulture, out double peso);
        if (!isPesoValid)
        {
            await DisplayAlert("Error", "El peso debe ser un número válido con decimales (Ej. 12.5).", "Aceptar");
            return;
        }

        // Convertir Teléfono a int
        bool isTelefonoValid = int.TryParse(entryTelefono.Text, out int telefono);
        if (!isTelefonoValid)
        {
            await DisplayAlert("Error", "El teléfono debe ser un número válido.", "Aceptar");
            return;
        }

        if (_editHospitalizacionId == 0)
        {
            await _dbService.Create(new MascotaHospitalizada
            {

                Nombre = entryNombreMascota.Text,
                Especie = pickerEspecie.SelectedItem.ToString(),
                Raza = pickerRaza.SelectedItem.ToString(),
                Edad = entryEdad.Text,
                Peso = entryPeso.Text,
                Propietario = entryPropietario.Text,
                DUI = entryDUI.Text,
                Telefono = entryTelefono.Text,
                EstadoHospitalizacion = pickerEstado.SelectedItem.ToString()
            });


            await DisplayAlert("Éxito", "Se guardado correctamente, dentro de unos momentos nos comunicaremos con usted", "Aceptar");
        }
        else
        {
            await _dbService.Update(new MascotaHospitalizada
            {
                Id = _editHospitalizacionId,
                Nombre = entryNombreMascota.Text,
                Especie = pickerEspecie.SelectedItem.ToString(),
                Raza = pickerRaza.SelectedItem.ToString(),
                Edad = entryEdad.Text,
                Peso = entryPeso.Text,
                Propietario = entryPropietario.Text,
                DUI = entryDUI.Text,
                Telefono = entryTelefono.Text,
                EstadoHospitalizacion = pickerEstado.SelectedItem.ToString()



            });
            await DisplayAlert("Éxito", "La información de la mascota ha sido actualizada correctamente.", "Aceptar");

            _editHospitalizacionId = 0;
        }
        // Limpiar los campos
        entryNombreMascota.Text = string.Empty;
        pickerEspecie.SelectedIndex = -1;
        pickerRaza.SelectedIndex = -1;
        entryEdad.Text = string.Empty;
        entryPeso.Text = string.Empty;
        entryPropietario.Text = string.Empty;
        entryDUI.Text = string.Empty;
        entryTelefono.Text = string.Empty;
        pickerEstado.SelectedIndex = -1;

        await Navigation.PushAsync(new ListaHospitalizada(_dbService));
    }
}