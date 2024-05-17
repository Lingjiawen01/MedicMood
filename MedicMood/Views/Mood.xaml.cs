using System;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class Mood : ContentPage
    {
        public Mood()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var selectedEmoji = moodPicker.SelectedItem.ToString();

            // Create an instance of Calender with both moodNote and selectedEmoji parameters
            await Navigation.PushAsync(new calender("Your mood note here", selectedEmoji));

            // Navigate back to Clock page
            await Navigation.PopAsync();
        }
    }
}
