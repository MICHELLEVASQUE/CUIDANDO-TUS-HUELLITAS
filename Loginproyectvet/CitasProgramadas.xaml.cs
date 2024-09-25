namespace Loginproyectvet;

public partial class CitasProgramadas : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editCitaId;

    public CitasProgramadas(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;


    }

    public CitasProgramadas(LocalDbService dbService, Citas citas)
    {


        InitializeComponent();
        _dbService = dbService;
        _editCitaId = citas.Id;



        // Cargar los datos del registro en los campos
        EntryDireccion.Text = citas.Direccion;
        EntryTelefono.Text = citas.Telefono;
        EntryPropietarioNombre.Text = citas.PropietarioNombre;
        EntryDUI.Text = citas.DUI;
        EntryMascotaNombre.Text = citas.MascotaNombre;
        DatePickerFecha.Date = citas.FechaHora.Date;
        TimePickerHora.Time = citas.FechaHora.TimeOfDay;

    }



    private async void GuardarCitaBtn_Clicked(object sender, EventArgs e)
    {
        if (!int.TryParse(EntryTelefono.Text, out int telefono) || EntryTelefono.Text.Length != 8 ||
            !int.TryParse(EntryDUI.Text, out int dui) || EntryDUI.Text.Length != 9)
        {
            await DisplayAlert("Error", "El teléfono debe tener 8 dígitos y el DUI 9 dígitos.", "Aceptar");
            return;
        }


        // Combinar la fecha y la hora
        DateTime fechaHora = DatePickerFecha.Date + TimePickerHora.Time;

        if (_editCitaId == 0)
        {
            // Crear una nueva cita
            await _dbService.Create(new Citas
            {
                Direccion = EntryDireccion.Text,
                Telefono = EntryTelefono.Text,
                PropietarioNombre = EntryPropietarioNombre.Text,
                DUI = EntryDUI.Text,
                MascotaNombre = EntryMascotaNombre.Text,
                FechaHora = fechaHora
            });

            await DisplayAlert("Éxito", "Se guardado correctamente, por favor se puntual con su cita, ¡Los esperamos!", "Aceptar");
        }
        else
        {
            // Actualizar una cita existente
            await _dbService.Update(new Citas
            {
                Id = _editCitaId,
                Direccion = EntryDireccion.Text,
                Telefono = EntryTelefono.Text,
                PropietarioNombre = EntryPropietarioNombre.Text,
                DUI = EntryDUI.Text,
                MascotaNombre = EntryMascotaNombre.Text,
                FechaHora = fechaHora
            });
            await DisplayAlert("Éxito", "La información de la mascota ha sido actualizada correctamente.", "Aceptar");
            _editCitaId = 0;
        }

        // Limpiar los campos
        EntryDireccion.Text = string.Empty;
        EntryTelefono.Text = string.Empty;
        EntryPropietarioNombre.Text = string.Empty;
        EntryDUI.Text = string.Empty;
        EntryMascotaNombre.Text = string.Empty;
        DatePickerFecha.Date = DateTime.Now;
        TimePickerHora.Time = DateTime.Now.TimeOfDay;

        // Navegar de vuelta a la pantalla principal o mostrar una confirmación
        await Navigation.PushAsync(new ListaCitas(_dbService));
    }
}