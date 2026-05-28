using System;

namespace MauiAppHotel3.Views;

public partial class NewPage1 : ContentPage
{
    App PropriedadesApp;

	public NewPage1()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        // dtpck_checkin.Date é DateTime? (nullable). Use coalescência para evitar acessar métodos em null.
        var checkinDate = dtpck_checkin.Date ?? DateTime.Now.Date;

        dtpck_checkout.MinimumDate = checkinDate.AddDays(1);
        dtpck_checkout.MaximumDate = checkinDate.AddMonths(6);

    } 

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            Navigation.PushAsync(new HospedagemContratada());
        } catch (Exception ex)
        { 
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = (DateTime)elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}