namespace MedicMood.Views;

public partial class Clockpage : ContentPage
{
	public Clockpage()
	{
        InitializeComponent();
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        // Navigate to the AddPage when the button is clicked
        Navigation.PushAsync(new AddPage());
    }
}