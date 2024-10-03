namespace Loginproyectvet;

public partial class FormAdopciones : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editFormAdopcionesId;
    public FormAdopciones(LocalDbService dbService)
	{
        _dbService = dbService;
        InitializeComponent();
	}

    public FormAdopciones(LocalDbService dbService, RegistroAdopciones registroAdopciones)
    {
        InitializeComponent();
        _dbService = dbService;
        _editFormAdopcionesId = registroAdopciones.Id;

        // Cargar los datos del registro en los campos
        EntryNomAdop.Text = registroAdopciones.Nombre;
        EntryApellidoAdop.Text = registroAdopciones.Apellido;
        EntrySalarioAdop.Text = registroAdopciones.Salario.ToString();
        EntryDirecionAdop.Text = registroAdopciones.Direccion;
        EntryTellAdop.Text = registroAdopciones.Telefono.ToString();
        pickerEspecie.SelectedItem = registroAdopciones.Especie;
    }


    private void EntryNomAdop_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        var newText = e.NewTextValue;


        if (!string.IsNullOrEmpty(newText) && !System.Text.RegularExpressions.Regex.IsMatch(newText, @"^[a-zA-Z]+$"))
        {

            entry.Text = e.OldTextValue;
        }
    }

    private void EntryApellidoAdop_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        var newText = e.NewTextValue;
        if (!string.IsNullOrEmpty(newText) && !System.Text.RegularExpressions.Regex.IsMatch(newText, @"^[a-zA-Z]+$"))
        {
            entry.Text = e.OldTextValue;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (_editFormAdopcionesId == 0)
        {
            await _dbService.Create(new RegistroAdopciones
            {
                Nombre = EntryNomAdop.Text,
                Apellido = EntryApellidoAdop.Text,
                Salario = EntrySalarioAdop.Text,
                Especie = pickerEspecie.SelectedItem.ToString(),
                Direccion = EntryDirecionAdop.Text,
                Telefono = EntryTellAdop.Text,

            });
            await DisplayAlert("Éxito", "Se guardado correctamente,gracias por querer a un mejor amigo en tu vida,cuidalo mucho y amalo", "Aceptar");
        }
        else
        {
            await _dbService.Update(new RegistroAdopciones
            {
                Id = _editFormAdopcionesId,
                Nombre = EntryNomAdop.Text,
                Apellido = EntryApellidoAdop.Text,
                Salario = EntryTellAdop.Text,
                Especie = pickerEspecie.SelectedItem.ToString(),
                Direccion = EntryDirecionAdop.Text,
                Telefono = EntryTellAdop.Text,

            });
            await DisplayAlert("Éxito", "La información ha sido actualizada correctamente.", "Aceptar");


            _editFormAdopcionesId = 0;
        }
        // Limpiar los campos
        EntryNomAdop.Text = string.Empty;
        EntryApellidoAdop.Text = string.Empty;
        EntrySalarioAdop.Text = string.Empty;
        pickerEspecie.SelectedIndex = -1;
        EntryDirecionAdop.Text = string.Empty;
        EntryTellAdop.Text = string.Empty;

        await Navigation.PushAsync(new ListaAdopciones(_dbService));
    }

    private  void EntrySalarioAdop_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void EntryDirecionAdop_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void EntryTellAdop_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void pickerEspecie_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


public class Especies
{
    public string? nombre { get; set; }
}
