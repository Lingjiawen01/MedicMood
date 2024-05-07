using MedicMood.Views;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class ReminderPage : ContentPage
    {
        private Alarm alarm;

        public ReminderPage(Alarm alarm)
        {
            InitializeComponent();
            this.alarm = alarm;
            ShowMedicineNote();
        }

        private void ShowMedicineNote()
        {
            if (alarm != null)
            {
                medicineNoteLabel.Text = alarm.MedicineNote;
            }
        }

        private async void DismissButton_Clicked(object sender, EventArgs e)
        {
            alarm.IsRinging = false;
            await Navigation.PopAsync();
        }
    }
}