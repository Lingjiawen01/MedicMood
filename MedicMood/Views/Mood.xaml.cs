using System;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class Mood : ContentPage
    {
        private string medicineName;

        public Mood(string medicineName)
        {
            InitializeComponent();
            this.medicineName = medicineName;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var selectedEmoji = moodPicker.SelectedItem.ToString();

            // Navigate to CalendarPage and pass both selected emoji and medicine name
            await Navigation.PushAsync(new calender(medicineName, selectedEmoji));
        }
    }
}
